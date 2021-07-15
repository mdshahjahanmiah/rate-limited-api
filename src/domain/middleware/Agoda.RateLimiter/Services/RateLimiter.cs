using Agoda.RateLimiter.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.RateLimiter.Services
{
    public class RateLimiter
    {
        private readonly object _syncObject = new object();

        private readonly ITimestamp _timestamp;
        private readonly long _requestIntervalTicks;
        private readonly int _requestLimit;

        private long? _requestStartTime;
        private int _previousRequestCount;
        private int _requestCount;

        public RateLimiter(ITimestamp timestamp, int requestLimit, int requestIntervalMs)
        {
            if (requestLimit < 1)
            {
                throw new ArgumentException($"Received invalid value for {nameof(requestLimit)}, {requestLimit}. Input must be one or greater.");
            }

            if (requestIntervalMs <= 0)
            {
                throw new ArgumentException($"Received invalid value for {nameof(requestIntervalMs)}, {requestIntervalMs}. Input must be greater than zero.");
            }

            _timestamp = timestamp;
            _requestLimit = requestLimit;
            _requestIntervalTicks = requestIntervalMs * TimeSpan.TicksPerMillisecond;
        }

        public bool RequestConforms()
        {
            var requestConforms = false;

            lock (_syncObject)
            {
                var currentTime = _timestamp.GetTimestamp();
                var elapsedTime = _requestStartTime.HasValue ? (currentTime - _requestStartTime.Value) : 0;

                // Request was started previously
                if (_requestStartTime.HasValue)
                {
                    // We have reached the end of the current request
                    if (elapsedTime >= _requestIntervalTicks)
                    {
                        // We exceeded the current request by two or more request lengths
                        // We can treat this as though it is the first request as the previous request should have no bearing on incoming requests
                        if (elapsedTime >= _requestIntervalTicks * 2)
                        {
                            _requestStartTime = currentTime;
                            _previousRequestCount = 0;
                            _requestCount = 0;

                            elapsedTime = 0;
                        }
                        // We exceeded or met the current request's end time since our last request
                        // The current will become the previous and we can calculate our location within the new current
                        else
                        {
                            _requestStartTime += _requestIntervalTicks;
                            _previousRequestCount = _requestCount;
                            _requestCount = 0;

                            elapsedTime = currentTime - _requestStartTime.Value;
                        }
                    }
                }
                // This is the first request
                else
                {
                    _requestStartTime = currentTime;
                }

                var weightedRequestCount = _previousRequestCount * ((double)(_requestIntervalTicks - elapsedTime) / _requestIntervalTicks) + _requestCount + 1;
                if (weightedRequestCount <= _requestLimit)
                {
                    _requestCount++;
                    requestConforms = true;
                }
            }

            return requestConforms;
        }
    }
}
