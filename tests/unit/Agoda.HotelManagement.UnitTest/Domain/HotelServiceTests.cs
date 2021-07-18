using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.Domain
{
    public class HotelServiceTests
    {
        private DependencyResolverHelper _serviceProvider;

        public HotelServiceTests()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public async Task ShouldReturnEmptyListOfHotelsByCity()
        {
            var _hotelService = _serviceProvider.GetService<IHotelService>();
            var response = await _hotelService.GetByCity("Hasan");

            Assert.Empty(response);
        }

        [Fact]
        public async Task ShouldReturnEmptyListOfHotelsByRoom()
        {
            var _hotelService = _serviceProvider.GetService<IHotelService>();
            var response = await _hotelService.GetByRoom("Hasan");

            Assert.Empty(response);
        }
    }
}
