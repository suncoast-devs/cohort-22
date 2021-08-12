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

      // foreach(var dino in dinos)
      // {
      //   Console.WriteLine(dino.Name);
      // }
      foreach (var movie in context.Movies)
      // SELECT * FROM "Movies"
      {
        Console.WriteLine($"There is a movie named {movie.Title}");
      }
    }
  }
}
