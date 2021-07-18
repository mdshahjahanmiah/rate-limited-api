using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.HotelManagement.UnitTest.Helpers
{
    public class DependencyResolverHelper
    {
        private readonly IWebHost _webHost;
        public DependencyResolverHelper(IWebHost WebHost)
        {
            _webHost = WebHost;
        }

        public T GetService<T>()
        {
            var serviceScope = _webHost.Services.CreateScope();
            var services = serviceScope.ServiceProvider;
            try
            {
                var scopedService = services.GetRequiredService<T>();
                return scopedService;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
