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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseSentry();
                });
        }

        public static void MigrateDatabase(IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var dbContext = scope.ServiceProvider.GetRequiredService<Models.dbContext>();
            var databaseIsUp = false;
            while (!databaseIsUp)
            {
                try
                {
                    var isFirstRun = dbContext.Database.CanConnect() == false;
                    databaseIsUp = true;

                    // migrate database
                    dbContext.Database.Migrate();
                    Console.WriteLine("[DATABASE] Migration(s) were applied.");

                    if (isFirstRun)
                    {
                        // seed
                    }
                }
                catch (Npgsql.NpgsqlException npgex)
                {
                    if ((npgex.InnerException != null && npgex.InnerException is System.Net.Sockets.SocketException) ||
                        (!string.IsNullOrWhiteSpace(npgex.Message) && npgex.Message.StartsWith("57P03")))
                    {
                        // wait a moment for next try
                        Console.WriteLine("[DATABASE] Database service is not running yet. Trying to connect again ...");
                        System.Threading.Thread.Sleep(1000);
                    }
                    else throw;
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}