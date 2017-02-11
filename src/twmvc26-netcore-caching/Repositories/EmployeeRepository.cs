using System.Collections.Generic;
using twmvc26_netcore_caching.Models;

namespace twmvc26_netcore_caching.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public List<Employee> Get()
        {
            return new EmployeesDatabase();
        }
    }
}