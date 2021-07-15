using Agoda.RateLimiter.Interfaces;
using Agoda.RateLimiter.Services;
using Moq;
using System;
using Xunit;

namespace Agoda.HotelManagement.UnitTest
{
    public class RateLimiterTests
    {
        private readonly Mock<ITimestamp> _mockTimestamp = new Mock<ITimestamp>();

        private long GetElapsedTimeInTicks(int elapsedTimeMs)
        {
            return elapsedTimeMs * TimeSpan.TicksPerMillisecond;
        }
        /*
         * Calculates the minimum elapsed time required for a request to conform, assuming the previous request met the request limit
         * This equation is based on the one used by Rate Limiter
         */
        private long GetMinimumElapsedTimeInTicks(int requestLimit, int requestIntervalMs, int currentRequestCount)
        {
            var elapsedTime = GetElapsedTimeInTicks(-1 * (requestIntervalMs * (requestLimit - currentRequestCount - 1) / requestLimit - requestIntervalMs));
            return elapsedTime;
        }
        private long SaturateRequest(RateLimiter.Services.RateLimiter rateLimiter, int requestLimit, long incrementTicks, long timeElapsedTicks)
        {
            var isRequestConforms = false;
            for (int i = 0; i < requestLimit; i++)
            {
                _mockTimestamp.Setup(x => x.GetTimestamp()).Returns(timeElapsedTicks);
                isRequestConforms = rateLimiter.RequestConforms();
                Assert.True(isRequestConforms);

                timeElapsedTicks += incrementTicks;
            }

            isRequestConforms = rateLimiter.RequestConforms();
            Assert.False(isRequestConforms);

            return timeElapsedTicks;
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        public void InvalidConstructorThrowsArgumentException(int requestLimit, int requestIntervalMs)
        {
            Assert.Throws<ArgumentException>(() => new RateLimiter.Services.RateLimiter(_mockTimestamp.Object, requestLimit, requestIntervalMs));
        }

        [Fact]
        public void InitialRequestLimitedByUnweightedRequestCount()
        {
            var requestIntervalMs = 1000;
            var requestLimit = 10;
            var rateLimiter = new RateLimiter.Services.RateLimiter(_mockTimestamp.Object, requestLimit, requestIntervalMs);

            SaturateRequest(rateLimiter, requestLimit, 0, 0);
        }

        [Theory]
        [InlineData(5, 1000)]
        [InlineData(50, 1500)]
        [InlineData(100, 2000)]
        public void PreviousRequestImpactsCurrent(int requestLimit, int requestIntervalMs)
        {
            var incrementTicks = GetElapsedTimeInTicks(requestIntervalMs / requestLimit);
            var rateLimiter = new RateLimiter.Services.RateLimiter(_mockTimestamp.Object, requestLimit, requestIntervalMs);

            long timeElapsedTicks = SaturateRequest(rateLimiter, requestLimit, incrementTicks, 0);
            var minimumElapsedTime = GetMinimumElapsedTimeInTicks(requestLimit, requestIntervalMs, 0);

            /*
             * Increment the elapsed time by some value less than the minimum elapsed time (1/2 is used here) calculated above
             * If the rate limiter is functioning properly, the previous request's request count will prevent the next incoming request from conforming
            */
            timeElapsedTicks += minimumElapsedTime / 2;
            _mockTimestamp.Setup(x => x.GetTimestamp()).Returns(timeElapsedTicks);

            Assert.False(rateLimiter.RequestConforms());

            /*
             * Increment the elapsed time again so the next the minimum elapsed time will have passed when the call to get the time is made
             * If the rate limiter is functioning properly, the request will conform
             */
            timeElapsedTicks += minimumElapsedTime / 2;

            _mockTimestamp.Setup(x => x.GetTimestamp()).Returns(timeElapsedTicks);
            Assert.True(rateLimiter.RequestConforms());

            // Because we have not advanced the elapsed time, the next request should not conform
            Assert.False(rateLimiter.RequestConforms());
        }

        [Fact]
        public void PreviousRequestDoesNotImpactCurrent()
        {
            var requestIntervalMs = 1000;
            var requestLimit = 50;
            var incrementTicks = GetElapsedTimeInTicks(requestIntervalMs / requestLimit);
            var slidingWindow = new RateLimiter.Services.RateLimiter(_mockTimestamp.Object, requestLimit, requestIntervalMs);

            // Saturate initial request and hit request limit
            long timeElapsedTicks = SaturateRequest(slidingWindow, requestLimit, incrementTicks, 0);

            // Delay by twice the request length to ensure the previous request has no impact
            timeElapsedTicks += GetElapsedTimeInTicks(requestIntervalMs * 2);

            // Verify that the current request is unimpacted by the previously tracked request
            SaturateRequest(slidingWindow, requestLimit, incrementTicks, timeElapsedTicks);
        }
    }
}
