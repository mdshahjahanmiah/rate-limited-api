using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Entities;
using Agoda.HotelManagement.Infrastructure.Base;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.Repository
{
    public class GenericRepositoryTests
    {
        private DependencyResolverHelper _serviceProvider;

        public GenericRepositoryTests()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public void ShouldReturnListHotels()
        {
            var _repository = _serviceProvider.GetService<IRepository<Hotel>>();
            var response = _repository.Get();

            Assert.NotEmpty(response);
        }
    }
}
