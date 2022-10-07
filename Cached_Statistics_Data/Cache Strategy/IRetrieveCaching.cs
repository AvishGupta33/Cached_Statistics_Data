namespace Cached_Statistics_Data.Cache_Strategy
{
    public interface IRetrieveCaching
    {
        dynamic GetCacheValue(string cacheKey);
    }
}