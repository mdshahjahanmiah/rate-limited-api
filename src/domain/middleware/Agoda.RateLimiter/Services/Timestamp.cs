using Agoda.RateLimiter.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Agoda.RateLimiter.Services
{
    public class Timestamp : ITimestamp
    {
        public long GetTimestamp()
        {
            return Stopwatch.GetTimestamp();
        }
    }
}
