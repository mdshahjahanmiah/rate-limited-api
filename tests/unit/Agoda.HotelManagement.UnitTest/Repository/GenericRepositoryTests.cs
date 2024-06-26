﻿using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Entities;
using Agoda.HotelManagement.Infrastructure.Base;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
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
        public async Task ShouldReturnListHotels()
        {
            var _repository = _serviceProvider.GetService<IRepository<Hotel>>();
            var response = await _repository.Get();

            Assert.NotEmpty(response);
        }
    }
}
