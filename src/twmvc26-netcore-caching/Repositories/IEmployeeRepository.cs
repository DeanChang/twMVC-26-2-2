using System.Collections.Generic;
using twmvc26_netcore_caching.Models;

namespace twmvc26_netcore_caching.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> Get();
    }
}