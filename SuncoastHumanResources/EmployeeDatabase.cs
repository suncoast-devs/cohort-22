using System.Collections.Generic;
using System.Linq;

namespace SuncoastHumanResources
{
  class EmployeeDatabase
  {
    private List<Employee> Employees { get; set; } = new List<Employee>();

    // CREATE Add Employee
    public void AddEmployee(Employee newEmployee)
    {
      Employees.Add(newEmployee);
    }

    // READ Get all the employees
    public List<Employee> GetAllEmployees()
    {
      return Employees;
    }

    // READ Find One Employee
    public Employee FindOneEmployee(string nameToFind)
    {
      Employee foundEmployee = Employees.FirstOrDefault(employee => employee.Name.ToUpper().Contains(nameToFind.ToUpper()));

      return foundEmployee;
    }

    // DELETE Delete Employee
    public void DeleteEmployee(Employee employeeToDelete)
    {
      Employees.Remove(employeeToDelete);
    }

    // UPDATE? 
  }
}
