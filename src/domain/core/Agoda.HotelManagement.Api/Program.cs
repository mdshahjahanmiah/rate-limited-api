using Agoda.HotelManagement.DataObjects.Settings;
using Agoda.HotelManagement.Infrastructure;
using Agoda.RateLimiter.Common;
using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace Agoda.HotelManagement.Api
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        private static string _environmentName;
        public static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{_environmentName}.json", optional: true, reloadOnChange: true)
                .Build();
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();

            try 
            {
                IHost webHost = CreateHostBuilder(args).Build().MigrateDatabase();

                // Seed initial test data
                Seed(webHost.Services);

                // Start the application
                webHost.Run();
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal("Error during application run : " + ex);
                return;
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void Seed(IServiceProvider services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            AppSettings appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);

            var store = (IRateLimitStore<RateLimitPolicy>)services.GetService(typeof(IRateLimitStore<RateLimitPolicy>));
            foreach (var rule in appSettings.RateLimiting.Rules)
            {
                store.SaveAsync(Templates.POLICY_ID_FORMAT(rule.Endpoint, "::1"), new RateLimitPolicy
                {
                    Rules = new List<RateLimitRule> {
                    new RateLimitRule { Capacity = rule.Limit <= 0 ? appSettings.RateLimiting.Default.Limit : rule.Limit, WindowSize = new TimeInterval(TimeUnit.Second, rule.Period <= 0 ? appSettings.RateLimiting.Default.Period : rule.Period) }
                }

                }).Wait();
            }
        }
    }
}
