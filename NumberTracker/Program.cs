using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace NumberTracker
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Welcome to Number Tracker");

      // - Create an empty list of numbers.
      var numbers = new List<int>();

      // Controls if we are still running our loop asking for more numbers
      var isRunning = true;

      // While we are running
      while (isRunning)
      {
        // Show the list of numbers
        Console.WriteLine("------------------");
        foreach (var number in numbers)
        {
          Console.WriteLine(number);
        }
        Console.WriteLine($"Our list has: {numbers.Count()} entries");
        Console.WriteLine("------------------");

        // Ask for a new number or the word quit to end
        Console.Write("Enter a number to store, or 'quit' to end: ");
        var input = Console.ReadLine().ToLower();

        if (input == "quit")
        {
          // If the input is quit, turn off the flag to keep looping
          isRunning = false;
        }
        else
        {
          // Parse the number and add it to the list of numbers
          var number = int.Parse(input);
          numbers.Add(number);
        }
      }

      //               A new stream of information to WRITE
      //                |
      //                |               Name of file to write to
      //                |               |
      //                |               |
      //                v               v
      var fileWriter = new StreamWriter("numbers.csv");

      //                  A new stream of CSV data
      //                  |
      //                  |         The stream to write to
      //                  |         |
      //                  |         |           Rules about formatting
      //                  |         |           |
      //                  |         |           |
      //                  v         v           v
      var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

      //
      //  Where to write
      //  |
      //  |                     What data to write
      //  |                     |
      //  v                     v
      csvWriter.WriteRecords(numbers);

      //
      //  Tell the object that writes to the file
      //  |
      //  |         That we are done and close
      //  |         |
      //  v         v
      fileWriter.Close();

    }
  }
}
