using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Implement_Onion_Arctech
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigurationLogger();
            Log.Information(messageTemplate: "Application started");
            try
            {
                CreateHostBuilder(args).Build().Run();
            }
           finally
            {
                Log.CloseAndFlush();            
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
           
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });
        public static void ConfigurationLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(path: @"log.txt")              
                .Enrich.WithMachineName()
                .CreateLogger();
        }
    }
}
