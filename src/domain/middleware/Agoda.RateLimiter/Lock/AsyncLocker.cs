using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Agoda.RateLimiter.Lock
{
    /// <summary>
    /// Prevent multiple threads from accessing same code concurrently.
    /// </summary>
    public class AsyncLocker
    {
        private static readonly ConcurrentDictionary<string, SemaphoreSlim> _locker = new ConcurrentDictionary<string, SemaphoreSlim>();

        private class Unlock : IDisposable
        {
            private readonly string _lockerKey;

            public Unlock(string lockerKey)
            {
                _lockerKey = lockerKey;
            }

            /// <summary>
            /// Automatically invoked if <see cref="GetLockAsync(string)"/> is obtained with `using` statement 
            /// </summary>
            public void Dispose()
            {
                if (_locker.TryGetValue(_lockerKey, out SemaphoreSlim semaphore))
                {
                    semaphore.Release();
                }
            }
        }

        /// <summary>
        /// Obtains a lock with specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Returns a <see cref="IDisposable"/> to release lock</returns>
        public async Task<IDisposable> GetLockAsync(string key)
        {
            await _locker.GetOrAdd(key, new SemaphoreSlim(1, 1)).WaitAsync();
            return new Unlock(key);
        }
    }
}
