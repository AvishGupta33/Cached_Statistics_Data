using Cached_Statistics_Data.Cache_Factory;
using Cached_Statistics_Data.Cache_Strategy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;


namespace Cached_Statistics_Data.Controllers
{
    //Home controller to have caching mechanism
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICacheFactory _cacheFactory;
        private readonly IRetrieveCaching _retrieveCaching;
        private readonly ILogger<HomeController> _logger; //Library to log caching scenarios

        //Dependency Injection
        public HomeController(IConfiguration config,ICacheFactory cacheFactory,
            IRetrieveCaching retrieveCaching, ILogger<HomeController> logger)
        {
            _config = config;
            _cacheFactory = cacheFactory;
            _retrieveCaching = retrieveCaching;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var IsCacheEnabled = _config.GetValue<string>("IsCacheEnabled").ToLower() == "true" ? true : false;
            List<int> data = new List<int>();

            //Add the list of statistics data in the cache
            //when caching is enabled from configurations
            if (IsCacheEnabled)
            {
                _logger.LogInformation($"{nameof(HomeController)} (#{DateTime.Now}): Caching the data recieved for web application call.");
                _cacheFactory.DataCaching(data);
            }

            //Retrieve the data from cache based on the key provided, here "Caching1"
            //when caching is enabled from configurations
            if (IsCacheEnabled)
            { 
                var result = _retrieveCaching.GetCacheValue("Caching1");
                _logger.LogInformation($"{nameof(HomeController)} (#{DateTime.Now}): Retried the Cached data.");
            }
            return View();
        }
    }
}
