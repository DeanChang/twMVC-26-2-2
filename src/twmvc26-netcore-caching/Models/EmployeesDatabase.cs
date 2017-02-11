using System.Collections.Generic;

namespace twmvc26_netcore_caching.Models
{
    public class EmployeesDatabase : List<Employee>
    {
        public EmployeesDatabase()
        {
            Add(new Employee() { EmpNo = 1, EmpName = "AAA" });
            Add(new Employee() { EmpNo = 2, EmpName = "BBB" });
            Add(new Employee() { EmpNo = 3, EmpName = "CCC" });
            Add(new Employee() { EmpNo = 4, EmpName = "DDD" });
            Add(new Employee() { EmpNo = 5, EmpName = "EEE" });
            Add(new Employee() { EmpNo = 6, EmpName = "FFF" });
        }
    }
}