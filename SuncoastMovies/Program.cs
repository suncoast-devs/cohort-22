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


      // Makes a new collection of movies but each movie knows the associated Rating object
      var moviesWithRatingsRolesAndActors = context.Movies.
                                              // from our movie, please include the associated Rating object
                                              Include(movie => movie.Rating).
                                              // ... and from our movie, please include the associated Roles LIST
                                              Include(movie => movie.Roles).
                                              // THEN for each of roles, please include the associated Actor object
                                              ThenInclude(role => role.Actor);

      foreach (var movie in moviesWithRatingsRolesAndActors)
      {
        if (movie.Rating == null)
        {
          Console.WriteLine($"{movie.Title} - not rated");
        }
        else
        {
          Console.WriteLine($"{movie.Title} - {movie.Rating.Description}");
        }

        foreach (var role in movie.Roles)
        {
          Console.WriteLine($" - {role.CharacterName} played by {role.Actor.FullName}");
        }
      }

      var newMovie = new Movie
      {
        Title = "SpaceBalls",
        PrimaryDirector = "Mel Brooks",
        Genre = "Comedy",
        YearReleased = 1987,
        RatingId = 2
      };


      var otherNewMovie = new Movie
      {
        Title = "Real Genius",
        PrimaryDirector = "I forget",
        Genre = "Comedy",
        YearReleased = 1986,
        RatingId = 2
      };

      context.Movies.Add(newMovie);
      context.Movies.Add(otherNewMovie);
      context.SaveChanges();
    }
  }
}
