using System;
using System.Linq;

namespace SuncoastMovies
{
  class Program
  {
    static void Main(string[] args)
    {
      var context = new SuncoastMoviesContext();

      // this feels like:
      //
      // var transactionCount = transactions.Count();
      // var dinoCount = dinos.Count();
      var movieCount = context.Movies.Count();
      Console.WriteLine($"There are {movieCount} movies!");
    }
  }
}
