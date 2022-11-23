using Dapper;
using System.Collections.Generic;
using System.Data;
using Testing.Models;

namespace Testing
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _conn;
        public EmployeeRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _conn.Query<Employee>("SELECT * FROM Employees;");
        }

        public Employee GetEmployee(int id)
        {
            return _conn.QuerySingle<Employee>("SELECT * FROM employees WHERE EMPLOYEEID = @id", new { id = id });
        }

        public void InsertEmployee(Employee employeeToInsert)
        {
            _conn.Execute("INSERT INTO employees (firstname, lastname, employeeID, title, phonenumber) VALUES (@firstname, @lastname, @title, @employeeID, @phonenumber);",
                new { EmployeeID = employeeToInsert.EmployeeID, firstName = employeeToInsert.FirstName, lastName = employeeToInsert.LastName, title = employeeToInsert.Title, phonenumber = employeeToInsert.PhoneNumber });
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }
        public Employee AssignCategory()
        {
            var categoryList = GetCategories();
            var employee = new Employee();
            employee.Categories = categoryList;
            return employee;
        }
        public void DeleteEmployee(Employee employee)
        {
            
            _conn.Execute("DELETE FROM Sales WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
            _conn.Execute("DELETE FROM Employees WHERE EmployeeID = @id;", new { id = employee.EmployeeID });
        }
    }
}
