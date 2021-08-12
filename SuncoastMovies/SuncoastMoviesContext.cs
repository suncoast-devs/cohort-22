using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace SuncoastMovies
{
  public class SuncoastMoviesContext : DbContext
  {
    public DbSet<Movie> Movies { get; set; }
    public DbSet<Rating> Ratings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");

      var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
      optionsBuilder.UseLoggerFactory(loggerFactory);
    }
  }
}