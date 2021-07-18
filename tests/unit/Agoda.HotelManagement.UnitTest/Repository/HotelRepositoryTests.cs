using Agoda.HotelManagement.Api;
using Agoda.HotelManagement.Infrastructure.Domain;
using Agoda.HotelManagement.UnitTest.Helpers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
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
        public async Task ShouldReturnEmptyListOfHotelsByCity()
        {
            var _hotelRepository = _serviceProvider.GetService<IHotelManagementRepository>();
            var response = await _hotelRepository.GetByCity("Hasan");

            Assert.Empty(response);
        }

        [Fact]
        public async Task ShouldReturnEmptyListOfHotelsByRoom()
        {
            var _hotelRepository = _serviceProvider.GetService<IHotelManagementRepository>();
            var response = await _hotelRepository.GetByRoom("Hasan");

            Assert.Empty(response);
        }
    }

}
