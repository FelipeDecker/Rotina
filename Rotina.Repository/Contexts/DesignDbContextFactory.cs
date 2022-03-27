using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Rotina.Repository.Contexts
{
    public class DesignDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var enviromentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var fileName = Directory.GetCurrentDirectory() + $"/../Rotina.Web/appsettings.{enviromentName}.json";

            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();

            var connectionString = configuration.GetConnectionString("TestingConnection");

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseNpgsql(connectionString);

            return new ApplicationDbContext(builder.Options);
        }
    }
}
