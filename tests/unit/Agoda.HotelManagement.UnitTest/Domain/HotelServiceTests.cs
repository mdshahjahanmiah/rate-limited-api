using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
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
        public void ShouldReturnEmptyListOfHotelsByCity()
        {
            var _hotelService = _serviceProvider.GetService<IHotelService>();
            var response = _hotelService.GetByCity("Hasan", null);

            Assert.Empty(response);
        }

        [Fact]
        public void ShouldReturnEmptyListOfHotelsByRoom()
        {
            var _hotelService = _serviceProvider.GetService<IHotelService>();
            var response = _hotelService.GetByRoom("Hasan", null);

            Assert.Empty(response);
        }
    }
}
