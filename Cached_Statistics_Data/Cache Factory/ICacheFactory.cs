using System.Collections.Generic;

namespace Cached_Statistics_Data.Cache_Factory
{
    public interface ICacheFactory
    {
        void DataCaching(List<int> value);
    }
}