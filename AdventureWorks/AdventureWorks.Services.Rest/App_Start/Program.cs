using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AdventureWorks.Services.Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostCtx, cfg) =>
                {
                    cfg.SetBasePath(Directory.GetCurrentDirectory());
                    cfg.AddXmlFile("db.config", optional: false, reloadOnChange: false);
                })
                .UseStartup<Startup>();
    }
}
