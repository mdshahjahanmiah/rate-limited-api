using Agoda.RateLimiter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agoda.RateLimiter.Processor
{
    public interface IRateLimitProcessor
    {
        Task<RateLimitResponse> ProcessAsync(string endpoint, string identifier, CancellationToken cancellationToken = default);
    }
}
