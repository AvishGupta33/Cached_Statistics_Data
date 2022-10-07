using System.Collections.Generic;

namespace Cached_Statistics_Data.Cache_Strategy
{
    //different interfaces created as a part of interrface segregation
    public interface IAddCaching
    {
        void Add(string key, List<int> value);
    }
}