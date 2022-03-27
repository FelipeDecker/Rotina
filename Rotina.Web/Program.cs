using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;

namespace Rotina.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // So para uma classe de startup
                    //webBuilder.UseStartup<Startup>();

                    // Para varias classes de startup Staging / Production / Test
                    // Alterar la no lounchSetting.json -> ServicoBanco.Web -> ASPNETCORE_ENVIRONMENT -> Nome do ambiente
                    webBuilder.UseStartup(typeof(Startup).Assembly.FullName);
                });
        }
    }
}
