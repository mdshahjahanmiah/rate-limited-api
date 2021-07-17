using Agoda.HotelManagement.DataObjects.Settings;
using Agoda.HotelManagement.Infrastructure;
using Agoda.RateLimiter.Common;
using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;

namespace Agoda.HotelManagement.Api
{
    public class Program
    {
        public IConfiguration Configuration { get; }
        public static void Main(string[] args)
        {
            IHost webHost = CreateHostBuilder(args).Build().MigrateDatabase();

            // Seed initial test data
            Seed(webHost.Services);

            // Start the application
            webHost.Run();
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
                    new RateLimitRule { Capacity = rule.Limit, WindowSize = new TimeInterval(TimeUnit.Second, rule.Period) }
                }

                }).Wait();
            }
        }
    }
}
