using Microsoft.Extensions.DependencyInjection;
using Rotina.DomainService.IRepositories;
using Rotina.DomainService.IServices;
using Rotina.Repository.Repositories;
using Rotina.Service.Services;

namespace Rotina.CrossCutting.DependecyRegisters
{
    public static class DependencyRegister
    {
        public static void RegisterApiServives(this IServiceCollection services)
        {
            #region Note

            // AddTransient - Created every time they are requested
            // AddScoped - Created once per request
            // AddSingleton - Created when executed, each subsequent request uses the created instance

            #endregion

            #region Services

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IMessageService, MessageService>();

            #endregion

            #region Repositories

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion
        }
    }
}
