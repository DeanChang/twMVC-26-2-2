using System.Collections.Generic;

namespace twmvc26_netcore_caching.Servies
{
    public interface IService<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}