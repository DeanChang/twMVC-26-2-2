using System.Collections.Generic;
using twmvc26_netcore_caching.Models;
using twmvc26_netcore_caching.Repositories;

namespace twmvc26_netcore_caching.Servies
{
    public class EmployeeService : IService<Employee>
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeRepository.Get();
        }
    }
}