using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Rotina.DomainService.Helpers;
using Rotina.Repository.Contexts;
using System.Text;

namespace Rotina.Web.Services
{
    public static class AplicationExtensions
    {
        public static void ConfigureAuthentication(this IServiceCollection service)
        {
            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Helper.ApiSecret())),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        public static void ConfigureAuthorization(this IServiceCollection service)
        {
            service.AddAuthorization(options =>
            {
                options.AddPolicy("Admin", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Gerente", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Coordenador", policy => policy.RequireRole("maneger"));
                options.AddPolicy("Funcionario", policy => policy.RequireRole("maneger"));
            });
        }

        public static void ConfigureDbContext(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("TestingConnection"),
                    assembly => assembly.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
        }
    }
}
