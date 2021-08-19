using System;

namespace GameNightWithFriends.Models
{
  public class GameNight
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Host { get; set; }
    public string Address { get; set; }
    public DateTime When { get; set; }
    public int MinimumNumberOfPlayers { get; set; }
    public int MaximumNumberOfPlayers { get; set; }
  }
}