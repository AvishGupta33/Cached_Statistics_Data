namespace Cached_Statistics_Data.Cache_Strategy
{
    public interface IRemovingCache
    {
        void DeleteCache(string cacheKey);
    }
}