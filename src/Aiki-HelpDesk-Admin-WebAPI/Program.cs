using System;
using System.Diagnostics;
using System.IO;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Http;
using Serilog;
using Serilog.Events;

namespace AIKI.CO.HelpDesk.WebAPI
{
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            MigrateDatabase(host);
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddJsonFile($"appsettings.{hostContext.HostingEnvironment.EnvironmentName}.json", true);
                    configApp.AddEnvironmentVariables("ASPNETCORE_");
                    configApp.AddCommandLine(args);
                })
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        public static void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            var databaseIsUp = false;
            while (!databaseIsUp)
            {
                try
                {
                    using var dbContext = scope.ServiceProvider.GetRequiredService<Models.dbContext>();
                    var isFirstRun = dbContext.Database.CanConnect() == false;
                    databaseIsUp = true;

                    // migrate database
                    dbContext.Database.Migrate();

                    if (isFirstRun)
                    {
                        // seed
                    }
                }
                catch (System.Net.Sockets.SocketException)
                {
                    // wait a moment for next try
                    var logger = scope.ServiceProvider.GetRequiredService<Serilog.ILogger>();
                    logger.Warning("Database service is not running yet. Trying to connect again ...");
                    System.Threading.Thread.Sleep(1000);
                }
                catch (Exception ex)
                {
                    //Log errors or do anything you think it's needed
                    throw;
                }
            }
        }
    }
}