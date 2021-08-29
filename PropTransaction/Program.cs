using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PropTransaction.Common;
using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SeriLog = Serilog.Log;

namespace PropTransaction
{
    public class Program
    {
        public static readonly string LogPath = CommonUtil.LogPath;

        public static void Main(string[] args)
        {
            // Initiliaze Serilog
            SeriLog.Logger = new LoggerConfiguration()
              .MinimumLevel.Verbose()
              .Filter.ByExcluding((le) => le.Level == LogEventLevel.Debug)
              .Filter.ByExcluding((le) => le.Level == LogEventLevel.Verbose)
              .WriteTo.File(LogPath, rollingInterval: RollingInterval.Day)
              .CreateLogger();

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
