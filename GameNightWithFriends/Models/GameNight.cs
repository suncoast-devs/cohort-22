using System;
using System.Collections.Generic;

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

    // ONE GameNight HAS MANY Players (the List<Player> goes here)
    public List<Player> Players { get; set; }
  }
}