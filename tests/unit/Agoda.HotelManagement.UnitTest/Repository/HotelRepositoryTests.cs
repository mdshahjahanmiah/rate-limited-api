using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Infrastructure.Domain;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.Repository
{
    public class HotelRepositoryTests
    {
        private DependencyResolverHelper _serviceProvider;

        public HotelRepositoryTests()
        {
            var webHost = WebHost.CreateDefaultBuilder().UseStartup<Startup>().Build();
            _serviceProvider = new DependencyResolverHelper(webHost);
        }

        [Fact]
        public void ShouldReturnEmptyListOfHotelsByCity()
        {
            var _hotelRepository = _serviceProvider.GetService<IHotelManagementRepository>();
            var response = _hotelRepository.GetByCity("Hasan", null);

            Assert.Empty(response);
        }

        [Fact]
        public void ShouldReturnEmptyListOfHotelsByRoom()
        {
            var _hotelRepository = _serviceProvider.GetService<IHotelManagementRepository>();
            var response = _hotelRepository.GetByRoom("Hasan", null);

            Assert.Empty(response);
        }
    }

}
