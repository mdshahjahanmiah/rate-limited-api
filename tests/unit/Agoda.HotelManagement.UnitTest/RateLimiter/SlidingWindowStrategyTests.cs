using Agoda.RateLimiter.Extensions;
using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Store;
using Agoda.RateLimiter.Strategy;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Agoda.HotelManagement.UnitTest.RateLimiter
{
    public class SlidingWindowStrategyTests
    {
        private Mock<IRateLimitStore<RateLimitRequestCounter>> _store;
        private SlidingWindowStrategy _strategy;

        private const string TestEndpoint = "/api/v1/Hotel/city";
        private const string TestIdentifier = "test-ip-address";
        private RateLimitRule TestRule;
        public SlidingWindowStrategyTests()
        {
            _store = new Mock<IRateLimitStore<RateLimitRequestCounter>>();
            _strategy = new SlidingWindowStrategy(_store.Object);

            TestRule = new RateLimitRule
            {
                WindowSize = new TimeInterval(TimeUnit.Second, 1),
                Capacity = 5
            };
        }

        [Fact]
        public async Task ShouldAcceptAndRecordRequestIfNoCounterPersists()
        {
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default)).ReturnsAsync((RateLimitRequestCounter)null);

            var response = await _strategy.ApplyRateLimitAsync(TestEndpoint, TestIdentifier, TestRule);

            Assert.True(response.IsWithinRateLimit);
            _store.Verify(x => x.SaveAsync(It.Is<string>(k => k.Contains(TestEndpoint) && k.Contains(TestIdentifier)),
                It.IsAny<RateLimitRequestCounter>(), It.IsAny<TimeSpan?>(), default));
        }

        [Fact]
        public async Task ShouldAcceptAndRecordRequestIfNoRecentRecordPersists()
        {
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default)).ReturnsAsync(
                new RateLimitRequestCounter
                {
                    Records = new List<RequestCount> { new RequestCount { Timestamp = DateTime.Now.AddDays(-100).GetEpochTime() } }
                });

            var response = await _strategy.ApplyRateLimitAsync(TestEndpoint, TestIdentifier, TestRule);

            Assert.True(response.IsWithinRateLimit);
            _store.Verify(x => x.SaveAsync(It.Is<string>(k => k.Contains(TestEndpoint) && k.Contains(TestIdentifier)),
                It.IsAny<RateLimitRequestCounter>(), It.IsAny<TimeSpan?>(), default));
        }

        [Fact]
        public async Task ShouldAcceptRequestIfTotalRequestCountIsWithinCapacity()
        {
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default)).ReturnsAsync(
                new RateLimitRequestCounter
                {
                    Records = new List<RequestCount> { new RequestCount { Timestamp = DateTime.Now.GetEpochTime(), Count = TestRule.Capacity - 1 } }
                });

            var response = await _strategy.ApplyRateLimitAsync(TestEndpoint, TestIdentifier, TestRule);

            Assert.True(response.IsWithinRateLimit);
        }

        [Fact]
        public async Task ShouldDenyRequestIfNoCapacity()
        {
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default)).ReturnsAsync(
              new RateLimitRequestCounter
              {
                  Records = new List<RequestCount> { new RequestCount { Timestamp = DateTime.Now.GetEpochTime(), Count = TestRule.Capacity } }
              });

            var response = await _strategy.ApplyRateLimitAsync(TestEndpoint, TestIdentifier, TestRule);
            Assert.False(response.IsWithinRateLimit);
        }
    }
}
