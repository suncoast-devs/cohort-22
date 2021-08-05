using System;

namespace SuncoastHumanResources
{
  class Program
  {
    static void DisplayGreeting()
    {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("    Welcome to Our Employee Database    ");
      Console.WriteLine("----------------------------------------");
      Console.WriteLine();
      Console.WriteLine();
    }

    static string PromptForString(string prompt)
    {
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    static int PromptForInteger(string prompt)
    {
      Console.Write(prompt);
      int userInput;
      var isThisGoodInput = Int32.TryParse(Console.ReadLine(), out userInput);

      if (isThisGoodInput)
      {
        return userInput;
      }
      else
      {
        Console.WriteLine("Sorry, that isn't a valid input, I'm using 0 as your answer.");
        return 0;
      }
    }

    static void Main(string[] args)
    {
      // Make a new database
      var database = new EmployeeDatabase();
      database.LoadEmployees();

      DisplayGreeting();

      // Should we keep showing the menu?
      var keepGoing = true;

      // While the user hasn't said QUIT yet
      while (keepGoing)
      {
        // Insert a blank line then prompt them and get their answer (force uppercase)
        Console.WriteLine();
        Console.Write("What do you want to do?\n(A)dd an employee\n(D)elete an employee\n(F)ind an employee\n(S)how all the employees\n(U)pdate an employee\n(Q)uit\n: ");
        var choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
          case "Q":
            keepGoing = false;
            break;
          case "D":
            DeleteEmployee(database);
            break;
          case "F":
            ShowEmployee(database);
            break;
          case "S":
            ShowAllEmployees(database);
            break;
          case "U":
            UpdateEmployee(database);
            break;
          case "A":
            AddEmployee(database);
            break;
          default:
            Console.WriteLine("NOPE! ☠️");
            break;
        }
      }

      database.SaveEmployees();
    }

    private static void DeleteEmployee(EmployeeDatabase database)
    {
      // DELETE - out of (CREATE, READ, UPDATE, DELETE)

      // Get the employee name we are searchign for
      var nameToSearchFor = PromptForString("What name are you looking for? ");

      // Search the database to see if they exist!
      Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

      // If we didn't find anyone
      if (foundEmployee == null)
      {
        //  Show that the person doesn't exist
        Console.WriteLine("No such employee!");
      }
      // If we found an employee
      else
      {
        //  - We did find the employee
        //  - Show the details
        Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");

        //  - Ask to confirm "Are you sure you want to delete them?"
        var confirm = PromptForString("Are you sure? [Y/N] ").ToUpper();

        if (confirm == "Y")
        {
          //    - Delete them
          database.DeleteEmployee(foundEmployee);
        }
      }
    }

    private static void ShowEmployee(EmployeeDatabase database)
    {
      // - Prompt for the name
      var nameToSearchFor = PromptForString("What name are you looking for? ");

      Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

      // - After the loop, `foundEmployee` is either `null` (not found) or refers to the matching item
      if (foundEmployee == null)
      {
        // - Show a message if `null`
        Console.WriteLine("No such person!");
      }
      else
      {
        // - otherwise show the details.
        Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
      }
    }

    private static void UpdateEmployee(EmployeeDatabase database)
    {
      // UPDATE - from CREATE, READ, UPDATE, DELETE

      // Get the employee name we are searchign for
      var nameToSearchFor = PromptForString("What name are you looking for? ");

      // Search the database to see if they exist!
      Employee foundEmployee = database.FindOneEmployee(nameToSearchFor);

      // If we didn't find anyone
      if (foundEmployee == null)
      {
        //  Show that the person doesn't exist
        Console.WriteLine("No such employee!");
      }
      // If we found an employee
      else
      {
        Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes ${foundEmployee.Salary}");
        var changeChoice = PromptForString("What do you want to change [Name/Department/Salary]? ").ToUpper();

        // -- What do we want to change?
        //    - if name
        if (changeChoice == "NAME")
        {
          //      - prompt for a new name
          foundEmployee.Name = PromptForString("What is the new name? ");
        }
        //    - if the department
        if (changeChoice == "DEPARTMENT")
        {
          //      - prompt for a new department
          foundEmployee.Department = PromptForInteger("What is the new department? ");
        }
        //   - if salary
        if (changeChoice == "SALARY")
        {
          //      - prompt for new salary
          foundEmployee.Salary = PromptForInteger("What is the new salary? ");
        }
      }
    }

    private static void AddEmployee(EmployeeDatabase database)
    {
      // CREATE (out of CREATE - READ - UPDATE - DELETE)

      // Make a new employee object
      var employee = new Employee();

      // Prompt for values and save them in the employee's properties
      employee.Name = PromptForString("What is your name? ");
      employee.Department = PromptForInteger("What is your department number? ");
      employee.Salary = PromptForInteger("What is your yearly salary (in dollars)? ");

      // Add it to the list
      database.AddEmployee(employee);
    }

    private static void ShowAllEmployees(EmployeeDatabase database)
    {
      // READ (out of CREATE - READ - UPDATE - DELETE)
      foreach (var employee in database.GetAllEmployees())
      {
        Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}");
      }
    }
  }
}
