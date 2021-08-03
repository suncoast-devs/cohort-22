using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
  class Program
  {
    // static int MultiplyBy2(int value)
    // {
    //   return value * 2;
    // }

    static void Main(string[] args)
    {
      var scores = new List<int> { 42, 100, 98, 15 };

      var newScores = scores.Select(score => score * 2);
      foreach (var score in newScores)
      {
        Console.WriteLine(score);
      }

      Console.WriteLine(scores.Count());
      Console.WriteLine(newScores.Count());


      // // Make a new list to store the results
      // var newScores = new List<int>();

      // // Go through each score in the scores list
      // foreach (var score in scores)
      // {
      //   // Use the `MultiplyBy2` expression to take score and double it
      //   var doubled = MultiplyBy2(score);

      //   // Add it to our new list
      //   newScores.Add(doubled);
      // }
      Console.WriteLine();
    }
  }
}
