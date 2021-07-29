using System;
using System.Collections.Generic;

namespace Methods
{

  //
  // class keyword
  // |
  // |    Name of class (PascalCase)
  // |    |
  // v    v
  class Employee
  {
    // public means "this can be seen outside of the class"
    // |
    // |   Type
    // |   |
    // |   |      Name of property
    // |   |      |
    // |   |      |
    // |   |      |
    // v   v      v
    public string Name { get; set; }
    public int Department { get; set; }
    public int Salary { get; set; }
    public int MonthlySalary { get; set; }

    // // This is a *special* method known as a "constructor"
    // // The constructor is called when we write a line like: `var bob = new Employee(`
    // // The arguments to the method should line up to those below
    // //
    // //              This will become the employee's name
    // //              |               This will become the employee's department
    // //              |               |                  This will become the employee's salary
    // //              |               |                  |              This will become the employee's monthly salary
    // //              |               |                  |              |
    // //              v               v                  v              v
    // public Employee(string newName, int newDepartment, int newSalary, int newMonthlySalary)
    // {
    //   // In the constructor we should setup the values for any of the properties.
    //   // Here we will *copy* the values given by the arguments to the corresponding property.

    //   Name = newName;
    //   Department = newDepartment;
    //   Salary = newSalary;
    //   MonthlySalary = newMonthlySalary;
    // }
  }


  class Program
  {
    static void DisplayGreeting()
    {
      Console.WriteLine("--------------------------------");
      Console.WriteLine("Welcome to Our Employee Database");
      Console.WriteLine("--------------------------------");
      Console.WriteLine();
      Console.WriteLine();
    }

    static string PromptForString(string prompt)
    {
      Console.WriteLine("🚀🚀🚀🚀");
      // Use the argument, whatever the caller sent us.
      Console.Write(prompt);

      // Get some user input
      var userInput = Console.ReadLine();

      // RETURN that value as the output of this method.
      // The value in `userInput` will go wherever the
      // *CALLER* of the method has specified.
      return userInput;
    }

    static int PromptForInteger(string prompt)
    {
      var userInput = PromptForString(prompt);

      int inputAsInteger;
      var isThisGoodInput = int.TryParse(userInput, out inputAsInteger);

      if (isThisGoodInput)
      {
        return inputAsInteger;
      }
      else
      {
        Console.WriteLine("That isn't an integer. You get a 0");
        return 0;
      }
    }

    static int ComputeMonthlySalaryFromYearly(int yearlySalary)
    {
      return yearlySalary / 12;
    }

    static void Main(string[] args)
    {
      var scores = new List<int>() { 42, 100, 55, 99, 200 };

      var graceHopper = new Employee()
      {
        Name = "Grace Hopper",
        Salary = 240_000,
        MonthlySalary = 20_000,
        Department = 100,
      };

      // Braces free creation of a new object
      var elonMusk = new Employee();
      elonMusk.Name = "Elon Musk";

      // Braces using creation of a new object
      // Creates *AND* initializes the object.
      //
      // Just like:
      // var scores = new List<int>() { 1, 2, 3, 4};
      //
      // Creates new list and puts a few numbers in it.
      var gavin = new Employee()
      {
        Name = "Gavin Stark"
      };

      // Braces initialization of a list containing three employees
      //
      // var scores = new List<int>() { 1, 2, 3};
      var employees = new List<Employee>()
      {
        gavin,
        elonMusk,
        graceHopper
      };

      var employeesNoBraces = new List<Employee>();
      employeesNoBraces.Add(gavin);
      employeesNoBraces.Add(elonMusk);
      employeesNoBraces.Add(graceHopper);

      // Complex syntax to make a new list and three
      // employees ALL AT ONCE.
      var allInOne = new List<Employee>() {
        new Employee() {
          Name = "Elon Musk"
        },

        new Employee() {
          Name = "Grace Hopper"
        },

        new Employee() {
          Name = "Gavin"
        }
      };



      DisplayGreeting();

      var name = PromptForString("What is your name? ");

      var department = PromptForInteger("What is your department number? ");

      var salary = PromptForInteger("What is your yearly salary (in dollars)? ");

      var salaryPerMonth = ComputeMonthlySalaryFromYearly(salary);

      Console.WriteLine($"Hello, {name} you make {salaryPerMonth} a month.");
    }
  }
}
