using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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

      // e.g. For every Movie object also get it's associated Rating object!
      //
      //                                     JOIN             Rating
      var moviesWithRatings = context.Movies.Include(movie => movie.Rating);

      foreach (var movie in moviesWithRatings)
      // SELECT * FROM "Movies"
      {
        if (movie.Rating == null)
        {
          Console.WriteLine($"There is a movie named {movie.Title} - with no rating");
        }
        else
        {
          Console.WriteLine($"There is a movie named {movie.Title} - {movie.Rating.Description}");
        }
      }
    }
  }
}
