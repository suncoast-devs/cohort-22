using System;

namespace FirstBankOfSuncoast
{
  class Program
  {
    //            1) NAME
    //                            2) INPUT
    //     3) OUTPUT
    string PromptForString(string prompt)
    {
      // 4) WORK
      Console.Write(prompt);
      var userInput = Console.ReadLine();

      return userInput;
    }

    int PromptForInteger(string prompt)
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


    // Name      ShowMenu
    // Input     none (void)
    // Output    none (void)
    // Work      A bunch of WriteLines
    void ShowMenu()
    {
      Console.WriteLine();
      Console.WriteLine("Choose an option from this menu:");
      Console.WriteLine();
      Console.WriteLine("[W]ithdraw");
      Console.WriteLine("[D]eposit");
      Console.WriteLine("[S]how Transactions");
      Console.WriteLine("[B]alances");
      Console.WriteLine("[Q]uit");
      Console.WriteLine();
    }

    void RunTheAppPlease()
    {
      var keepGoing = true;

      while (keepGoing)
      {
        ShowMenu();

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











































































































    static void Main(string[] args)
    {
      var newProgram = new Program();
      newProgram.RunTheAppPlease();
    }
  }
}