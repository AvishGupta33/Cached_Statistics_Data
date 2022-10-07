using Cached_Statistics_Data.Cache_Strategy;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace Cached_Statistics_Data.Cache_Factory
{
    /* Factory Class to Cache data based on condition environment */
    public class CacheFactory : ICacheFactory
    {
        private readonly IAddCaching _cacheData;
        private readonly IHostEnvironment _hosting;
        private readonly IRetrieveCaching _getCache;

        //dependency Injection
        public CacheFactory(IAddCaching cacheData, IHostEnvironment host, IRetrieveCaching getCache)
        {
            _cacheData = cacheData;
            _hosting = host;
            _getCache = getCache;
        }

        public void DataCaching(List<int> value)
        {
            //Caching data as "Caching1" for the development environment
            if (_hosting.IsDevelopment())
            {
                _cacheData.Add("Caching1", value);
            }
            else
            //Caching data as "Caching2" for production environment
           if (_hosting.IsProduction())
            {
                _cacheData.Add("Caching2", value);
            }
        }
    }
}
