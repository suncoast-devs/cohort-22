namespace GameNightWithFriends.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string Name { get; set; }

    // Foreign Key
    public int GameNightId { get; set; }

    // Gives back the associated GameNight for this Player
    // A Player attents ONE GameNight (so an Object/Class goes here)
    public GameNight GameNight { get; set; }
  }
}