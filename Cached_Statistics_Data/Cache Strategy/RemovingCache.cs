using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Cached_Statistics_Data.Cache_Strategy
{
    /* Strategic class to remove respective data from cache (Single Responsibility)*/
    public class RemovingCache : IRemovingCache
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<RemovingCache> _logger;

        public RemovingCache(IMemoryCache memoryCache, ILogger<RemovingCache> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public void DeleteCache(string cacheKey)
        {
            _logger.LogInformation($"{nameof(RemovingCache)} (#{DateTime.Now}): Removing the Cached Data with cache key {cacheKey}.");
            _memoryCache.Remove(cacheKey);
        }
    }
}
