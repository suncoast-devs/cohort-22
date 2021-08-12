using Microsoft.EntityFrameworkCore;

namespace SuncoastMovies
{
  public class SuncoastMoviesContext : DbContext
  {
    public DbSet<Movie> Movies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseNpgsql("server=localhost;database=SuncoastMovies");
    }
  }
}