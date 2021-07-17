using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Domain.Interfaces;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.Domain
{
    public class HotelManagerTests
    {
        private DependencyResolverHelper _serviceProvider;

        public HotelManagerTests()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public void ShouldReturnEmptyListByCity()
        {
            var _hotelManager = _serviceProvider.GetService<IHotelManager>();
            var response = _hotelManager.GetByCity("Hasan", "ASC");
            Assert.True(response.Count == 0);
        }

        [Fact]
        public void ShouldReturnListOfHotelsByCity()
        {
            var _hotelManager = _serviceProvider.GetService<IHotelManager>();
            var response = _hotelManager.GetByCity("Bangkok","ASC");
            Assert.True(response.Count > 0);
        }

        [Fact]
        public void ShouldReturnEmptyListByRoomType()
        {
            var _hotelManager = _serviceProvider.GetService<IHotelManager>();
            var response = _hotelManager.GetByRoom("Comfortable", "ASC");
            Assert.True(response.Count == 0);
        }

        [Fact]
        public void ShouldReturnListOfHotelsByRoomType()
        {
            var _hotelManager = _serviceProvider.GetService<IHotelManager>();
            var response = _hotelManager.GetByRoom("Superior", "ASC");
            Assert.True(response.Count > 0);
        }
    }
}
