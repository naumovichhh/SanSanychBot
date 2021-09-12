using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VitalyBot.Bot;

namespace VitalyBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            SetWebHook(host);
            host.Run();
        }

        private static void SetWebHook(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var sanSanychBot = scope.ServiceProvider.GetRequiredService<SanSanychBot>();
                sanSanychBot.SetWebHook();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddScoped<SanSanychBot>();
                });
    }
}
