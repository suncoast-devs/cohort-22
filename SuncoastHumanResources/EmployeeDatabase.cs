using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
  class EmployeeDatabase
  {
    private List<Employee> Employees { get; set; } = new List<Employee>();

    private string FileName = "employees.csv";

    // Method to load employees (doesn't return anything, just populates Employees list)
    public void LoadEmployees()
    {
      if (File.Exists(FileName))
      {
        var fileReader = new StreamReader(FileName);

        var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);

        // Replace our BLANK list of employees with the ones that are in the CSV file
        Employees = csvReader.GetRecords<Employee>().ToList();

        fileReader.Close();
      }
    }

    // Write the list Employee to a file
    public void SaveEmployees()
    {
      var fileWriter = new StreamWriter(FileName);

      var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

      csvWriter.WriteRecords(Employees);

      fileWriter.Close();
    }

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
