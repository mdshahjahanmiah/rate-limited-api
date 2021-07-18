using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.RateLimiter.Models
{
    public enum TimeUnit
    {
        Second,
        Minute,
        Hour
    }

    public class TimeInterval
    {
        public TimeInterval(TimeUnit unit, int value)
        {
            Unit = unit;
            Value = value;
        }

        public TimeUnit Unit { get; set; }
        public int Value { get; set; }
    }
}
