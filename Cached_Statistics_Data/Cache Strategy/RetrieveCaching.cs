using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;

namespace Cached_Statistics_Data.Cache_Strategy
{
    /* Strategic class to retrieve data from cache (Single Responsibility)*/
    public class RetrieveCaching : IRetrieveCaching
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<RetrieveCaching> _logger;

        public RetrieveCaching(IMemoryCache memoryCache, ILogger<RetrieveCaching> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public dynamic GetCacheValue(string cacheKey)
        {
            var result = _memoryCache.Get(cacheKey);
            _logger.LogInformation($"{nameof(RetrieveCaching)} (#{DateTime.Now}): Retrieved the cached data with key {cacheKey}.");
            return result;
        }
    }
}
