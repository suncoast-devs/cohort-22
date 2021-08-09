using System;

namespace FirstBankOfSuncoast
{
  class Program
  {
    //            1) NAME
    //                            2) INPUT
    //     3) OUTPUT
    static string PromptForString(string prompt)
    {
      // 4) WORK
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    static int PromptForInteger(string prompt)
    {
      var isThisGoodInput = false;
      do
      {
        var stringInput = PromptForString(prompt);

        int numberInput;
        isThisGoodInput = Int32.TryParse(stringInput, out numberInput);

        if (isThisGoodInput)
        {
          return numberInput;
        }
        else
        {
          Console.WriteLine("Sorry, that isn't a valid input");
        }
      } while (!isThisGoodInput);

      // We shouldn't get here, but this makes C# happy
      return 0;
    }

    static void Main(string[] args)
    {
      var keepGoing = true;

      while (keepGoing)
      {
        Console.WriteLine();
        Console.WriteLine("Chose an option from this menu:");
        Console.WriteLine();
        Console.WriteLine("[W]ithdraw");
        Console.WriteLine("[D]eposit");
        Console.WriteLine("[S]how Transactions");
        Console.WriteLine("[B]alances");
        Console.WriteLine("[Q]uit");
        Console.WriteLine();
        // Console.Write("> ");
        // var menuOption = Console.ReadLine().ToUpper();

        var menuOption = PromptForString("> ");

        if (menuOption == "W")
        {
        }
        else
        if (menuOption == "D")
        {
        }
        else
        if (menuOption == "S")
        {
        }
        else
        if (menuOption == "B")
        {
        }
        else
        if (menuOption == "Q")
        {
          keepGoing = false;
        }
        else
        {
          Console.WriteLine("Unknown menu option");
        }
      }
    }
  }
}