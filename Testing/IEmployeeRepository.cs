using System.Collections.Generic;
using Testing.Models;

namespace Testing
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetAllEmployees();
        public Employee GetEmployee(int id);

        public void InsertEmployee(Employee employeeToInsert);
        public IEnumerable<Category> GetCategories();
        public Employee AssignCategory();

        public void DeleteEmployee(Employee employee);
    }
}
