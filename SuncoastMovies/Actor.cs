using System;
using System.Collections.Generic;

namespace SuncoastMovies
{
  public class Actor
  {
    public int Id { get; set; }

    public string FullName { get; set; }

    public DateTime Birthday { get; set; }

    public List<Role> Roles { get; set; }
  }
}