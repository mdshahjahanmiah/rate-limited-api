using Agoda.RateLimiter.Filters;
using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Processor;
using Agoda.RateLimiter.Store;
using Agoda.RateLimiter.Strategy;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.RateLimiter.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRateLimit(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton(typeof(IRateLimitStrategy), typeof(SlidingWindowStrategy));
            services.AddSingleton(typeof(IRateLimitStore<RateLimitPolicy>), typeof(InMemoryStore<RateLimitPolicy>));
            services.AddSingleton(typeof(IRateLimitStore<RateLimitRequestCounter>), typeof(InMemoryStore<RateLimitRequestCounter>));
            services.AddSingleton(typeof(IRateLimitProcessor), typeof(RateLimitProcessor));
            services.AddSingleton<RateLimitFilter>();

            return services;
        }
    }
}
