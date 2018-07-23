using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog.Config;
using NLog.Web;

namespace WBS.API
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }

        public static void Main(string[] args)
        {
            Configuration = new ConfigurationBuilder().Build();
            var logger = NLogBuilder.ConfigureNLog(Configuration.GetValue<string>("NLogConfigName")).GetCurrentClassLogger();
            try
            {
                logger.Info("Init Web API");
                BuildWebHost(args).Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Web API stopped because was exception");
                throw;
            }
            finally
            {
                // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
                NLog.LogManager.Shutdown();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .ConfigureLogging(logging =>
                {
                    //logging.AddConfiguration(Configuration.GetSection("Logging"));
                    logging.ClearProviders();
                    logging.SetMinimumLevel(LogLevel.Information);
                })
                .Build();
    }
}
