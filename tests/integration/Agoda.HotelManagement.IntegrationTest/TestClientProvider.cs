using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.DataObjects.Settings;
using Agoda.RateLimiter.Common;
using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Store;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Agoda.HotelManagement.IntegrationTest
{
    public class TestClientProvider
    {
        public HttpClient Client { get; private set; }
        public TestClientProvider()
        {
            var server = new TestServer(new WebHostBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json");
                })
                .UseStartup<Startup>());
            
            Seed(server.Services);
            Client = server.CreateClient();
        }

        private static void Seed(IServiceProvider services)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            AppSettings appSettings = new AppSettings();
            config.GetSection("AppSettings").Bind(appSettings);

            var store = (IRateLimitStore<RateLimitPolicy>)services.GetService(typeof(IRateLimitStore<RateLimitPolicy>));
            foreach (var rule in appSettings.RateLimiting.Rules)
            {
                store.SaveAsync(Templates.POLICY_ID_FORMAT(rule.Endpoint, string.Empty), new RateLimitPolicy
                {
                    Rules = new List<RateLimitRule> {
                    new RateLimitRule { Capacity = rule.Limit <= 0 ? appSettings.RateLimiting.Default.Limit : rule.Limit, WindowSize = new TimeInterval(TimeUnit.Second, rule.Period <= 0 ? appSettings.RateLimiting.Default.Period : rule.Period) }
                }

                }).Wait();
            }
        }
    }
}
