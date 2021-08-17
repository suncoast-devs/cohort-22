using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClient
{
  class Program
  {

    static async Task GetOneItem(string token, int id)
    {
      try
      {
        var client = new HttpClient();

        var responseBodyAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items/{id}?access_token={token}");

        //                                          Describe the Shape of the data (Object in JSON => Item)
        //                                                V       
        var item = await JsonSerializer.DeserializeAsync<Item>(responseBodyAsStream);

        var table = new ConsoleTable("Description", "Created At", "Completed");

        table.AddRow(item.Text, item.CreatedAt, item.CompletedStatus);

        table.Write();
      }
      catch (HttpRequestException)
      {
        Console.WriteLine("I could not find that item");
      }
    }

    static async Task ShowAllItems(string token)
    {
      var client = new HttpClient();

      var responseBodyAsStream = await client.GetStreamAsync($"https://one-list-api.herokuapp.com/items?access_token={token}");

      //                                          Describe the Shape of the data (array in JSON => List, Object in JSON => Item)
      //                                                V        V
      var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsStream);

      var table = new ConsoleTable("Description", "Created At", "Completed");

      // Back in the world of List/LINQ/C#
      foreach (var item in items)
      {
        table.AddRow(item.Text, item.CreatedAt, item.CompletedStatus);
      }

      table.Write();
    }

    static async Task Main(string[] args)
    {
      var token = "";

      if (args.Length == 0)
      {
        Console.Write("What list would you like? ");
        token = Console.ReadLine();
      }
      else
      {
        token = args[0];
      }

      var keepGoing = true;
      while (keepGoing)
      {
        Console.Clear();
        Console.Write("Get (A)ll todo, (O)ne Todo, or (Q)uit: ");
        var choice = Console.ReadLine().ToUpper();

        switch (choice)
        {
          case "Q":
            keepGoing = false;
            break;

          case "O":
            Console.Write("Enter the ID ");
            var id = int.Parse(Console.ReadLine());

            await GetOneItem(token, id);

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            break;

          case "A":
            await ShowAllItems(token);

            Console.WriteLine("Press ENTER to continue");
            Console.ReadLine();
            break;

          default:
            break;
        }
      }
    }
  }
}
