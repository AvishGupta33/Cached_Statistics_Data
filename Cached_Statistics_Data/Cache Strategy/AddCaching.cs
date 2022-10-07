using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Cached_Statistics_Data.Cache_Strategy
{
    /* Strategic class to add the restective data to cache (Single Responsibility)*/
    public class AddCaching : IAddCaching
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<AddCaching> _logger;

        public AddCaching(IMemoryCache memoryCache, ILogger<AddCaching> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public void Add(string key, List<int> value)
        {
            var cachedExpiryOptions = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(30),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(20)
            };

            _logger.LogInformation($"{nameof(AddCaching)} (#{DateTime.Now}): Adding the Data to Cache.");
            _memoryCache.Set(key, value, cachedExpiryOptions);
        }
    }
}
