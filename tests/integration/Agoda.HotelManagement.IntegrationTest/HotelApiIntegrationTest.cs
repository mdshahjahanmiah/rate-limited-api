using FluentAssertions;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Agoda.HotelManagement.IntegrationTest
{
    public class HotelApiIntegrationTest
    {
        [Fact]
        public async Task GetHotelsByCity()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/api/v1/Hotel/city/Bangkok");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetHotelsByRoom()
        {
            var client = new TestClientProvider().Client;
            var response = await client.GetAsync("/api/v1/Hotel/room/Deluxe");
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    } 
}
