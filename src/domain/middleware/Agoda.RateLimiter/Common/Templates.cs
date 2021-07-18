using System;
using System.Collections.Generic;
using System.Text;

namespace Agoda.RateLimiter.Common
{
    public class Templates
    {
        public static string POLICY_ID_FORMAT(string endpoint, string identifier)
        {
            var result = string.Format("policy-{0}-{1}", endpoint, identifier);
            return result;
        }

        public static string COUNTER_ID_FORMAT(string endpoint, string identifier)
        {
            var result = string.Format("counter-{0}-{1}", endpoint, identifier);
            return result;
        }
    }
}
