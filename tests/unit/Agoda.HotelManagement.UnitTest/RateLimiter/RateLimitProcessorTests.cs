using Agoda.RateLimiter.Models;
using Agoda.RateLimiter.Processor;
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
    public class RateLimitProcessorTests
    {
        private Mock<IRateLimitStore<RateLimitPolicy>> _store;
        private Mock<IRateLimitStrategy> _strategy;
        private RateLimitProcessor _service;

        private const string TestEndpoint = "/api/v1/Hotel/city";
        private const string TestIdentifier = "test-ip-address";

        public RateLimitProcessorTests()
        {
            _store = new Mock<IRateLimitStore<RateLimitPolicy>>();
            _strategy = new Mock<IRateLimitStrategy>();
            _service = new RateLimitProcessor(_strategy.Object, _store.Object);
        }

        [Fact]
        public async Task ShouldAllowRequestIfNoRateLimitPolicy()
        {
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default)).ReturnsAsync((RateLimitPolicy)null);
            var response = await _service.ProcessAsync(TestEndpoint, TestIdentifier);
            
            Assert.True(response.IsWithinRateLimit);
        }

        [Fact]
        public async Task ShouldApplyAllPolicyRules()
        {
            _strategy.Setup(x => x.ApplyRateLimitAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<RateLimitRule>(), default)).ReturnsAsync(RateLimitResponse.Accepted());
            _store.Setup(x => x.GetAsync(It.IsAny<string>(), default))
                .ReturnsAsync(new RateLimitPolicy
                {
                    Rules = new List<RateLimitRule>
                    {
                       new RateLimitRule { WindowSize = new TimeInterval(TimeUnit.Hour, 24), Capacity = 1000 },
                       new RateLimitRule { WindowSize = new TimeInterval(TimeUnit.Minute, 60), Capacity = 100 }
                    }
                });

            var response = await _service.ProcessAsync(TestEndpoint, TestIdentifier);

            _strategy.Verify(x => x.ApplyRateLimitAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<RateLimitRule>(r => r.WindowSize.Unit == TimeUnit.Hour), default));
            _strategy.Verify(x => x.ApplyRateLimitAsync(It.IsAny<string>(), It.IsAny<string>(), It.Is<RateLimitRule>(r => r.WindowSize.Unit == TimeUnit.Minute), default));
        }
    }
}
