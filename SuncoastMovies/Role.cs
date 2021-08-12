namespace SuncoastMovies
{
  public class Role
  {
    public int Id { get; set; }
    public string CharacterName { get; set; }

    // Other properties/columns (FOREIGN KEYS)
    public int MovieId { get; set; }
    public int ActorId { get; set; }

    public Movie Movie { get; set; }
    public Actor Actor { get; set; }
  }
}