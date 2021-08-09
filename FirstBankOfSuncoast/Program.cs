using System;
using System.Collections.Generic;
using System.Linq;

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

      // list of SAMPLE transactions
      var transactions = new List<Transaction>()
      {
        new Transaction()
        {
          Amount = 10,
          Account = "Savings",
          Type = "Deposit"
        },
        new Transaction()
        {
          Amount = 8,
          Account = "Savings",
          Type = "Withdraw"
        },
        new Transaction()
        {
          Amount = 25,
          Account = "Checking",
          Type = "Deposit"
        }
      };

      while (keepGoing)
      {
        ShowMenu();

        // Console.Write("> ");
        // var menuOption = Console.ReadLine().ToUpper();

        var menuOption = PromptForString("> ");

        if (menuOption == "W")
        {
          int totalChecking = ComputeCheckingBalance(transactions);

          int totalSavings = ComputeSavingsBalance(transactions);

        }
        else
        if (menuOption == "D")
        {
        }
        else
        if (menuOption == "S")
        {
          // A:
          // Print the number of transactions?
          Console.WriteLine($"There are {transactions.Count} transactions");

          // For each transaction in our list of transactions
          foreach (var transaction in transactions)
          {
            // - Make a description of that transaction
            var descriptionOfTransaction = transaction.Description();

            // - print that description to the user
            Console.WriteLine(descriptionOfTransaction);
          }
        }
        else
        if (menuOption == "B")
        {
          // ALGORITHM
          //
          // Need to show the result of the checking account deposits and withdraws
          // Need to show the result of the savings account deposits and withdraws
          //
          // We know that transaction amounts are always POSITIVE
          //
          // Total up the checking account deposits and call that TotalCheckingDeposits
          // - Make a total equal to 0
          // var total = 0;
          // // - for each transaction
          // foreach (var transaction in transactions)
          // {
          //   // -   if the transaction is a checking transaction AND it is a deposit
          //   if (transaction.Account == "Checking" && transaction.Type == "Deposit")
          //   {
          //     //       add the transaction amount to the total
          //     total = total + transaction.Amount;
          //   }
          // }
          int totalChecking = ComputeCheckingBalance(transactions);

          int totalSavings = ComputeSavingsBalance(transactions);

          Console.WriteLine($"Your checking account has ${totalChecking} and your savings has ${totalSavings}");
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

        // Here is where we will do the CSV for "transactions"
      }
    }

    private int ComputeSavingsBalance(List<Transaction> transactions)
    {
      var totalSavingsDeposits = transactions.
                                    Where(transaction => transaction.Account == "Savings" && transaction.Type == "Deposit").
                                    Sum(transaction => transaction.Amount);
      var totalSavingsWithdraw = transactions.
                                    Where(transaction => transaction.Account == "Savings" && transaction.Type == "Withdraw").
                                    Sum(transaction => transaction.Amount);
      var totalSavings = totalSavingsDeposits - totalSavingsWithdraw;
      return totalSavings;
    }

    private int ComputeCheckingBalance(List<Transaction> transactions)
    {
      var totalCheckingDeposits = transactions.
                                    Where(transaction => transaction.Account == "Checking" && transaction.Type == "Deposit").
                                    Sum(transaction => transaction.Amount);
      // Total up the checking account withdraws and call that TotalCheckingWithdraws
      var totalCheckingWithdraw = transactions.
                                    Where(transaction => transaction.Account == "Checking" && transaction.Type == "Withdraw").
                                    Sum(transaction => transaction.Amount);
      // Subtract TotalCheckingWithdraws from TotalCheckingDeposits  to get TotalChecking
      var totalChecking = totalCheckingDeposits - totalCheckingWithdraw;
      return totalChecking;
    }

    static void Main(string[] args)
    {
      var newProgram = new Program();
      newProgram.RunTheAppPlease();
    }
  }
}