using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClient
{
  class Program
  {
    static async Task Main(string[] args)
    {
      var client = new HttpClient();

      var responseBodyAsStream = await client.GetStreamAsync("https://one-list-api.herokuapp.com/items?access_token=cohort22");

      //                                          Describe the Shape of the data (array in JSON => List, Object in JSON => Item)
      //                                                V        V
      var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseBodyAsStream);

      // Back in the world of List/LINQ/C#
      foreach (var item in items)
      {
        Console.WriteLine($"The task {item.Text} was created on {item.CreatedAt} and has a completion of {item.CompletedStatus}");
      }
    }
  }
}
