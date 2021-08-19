namespace GameNightWithFriends.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string Name { get; set; }

    // Foreign Key
    public int GameNightId { get; set; }

    // Gives back the associated GameNight for this Player
    public GameNight GameNight { get; set; }
  }
}