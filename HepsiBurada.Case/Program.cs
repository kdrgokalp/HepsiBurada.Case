using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Serilog;
using Serilog.Events;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiBurada.Case
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(loggingConfiguration => loggingConfiguration.ClearProviders())
                .UseSerilog((_, config) =>
                {
                    config
                        .Enrich.WithProperty("Application", "Hepsiburada Case Api")
                        .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                        .MinimumLevel.Override("System", LogEventLevel.Fatal)
                        .MinimumLevel.Debug()
                        .WriteTo.Logger(a => a.Filter.ByIncludingOnly(x => x.Level == Serilog.Events.LogEventLevel.Debug)
                            .WriteTo.File($"{_.Configuration.GetValue<string>("Logging:BaseDirectory")}\\DEBUG\\debug.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj} {Properties}{NewLine}{NewLine}"))
                        .WriteTo.Logger(a => a.Filter.ByIncludingOnly(x => x.Level == Serilog.Events.LogEventLevel.Warning)
                            .WriteTo.File($"{_.Configuration.GetValue<string>("Logging:BaseDirectory")}\\WARN\\warn.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj} {Properties}{NewLine}{NewLine}"))
                        .WriteTo.Logger(a => a.Filter.ByIncludingOnly(x => x.Level == Serilog.Events.LogEventLevel.Information)
                            .WriteTo.File($"{_.Configuration.GetValue<string>("Logging:BaseDirectory")}\\INFO\\info.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj} {Properties}{NewLine}{NewLine}"))
                        .WriteTo.Logger(a => a.Filter.ByIncludingOnly(x => x.Level == Serilog.Events.LogEventLevel.Error)
                            .WriteTo.File($"{_.Configuration.GetValue<string>("Logging:BaseDirectory")}\\ERROR\\error.txt", rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] [{SourceContext}] {Message:lj} {Properties}{NewLine}{NewLine}"));
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                    
                });
    }
}
