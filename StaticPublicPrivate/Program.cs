using System;

namespace StaticPublicPrivate
{
  class Math
  {
    static public double Pi()
    {
      return 3.14159265;
    }
  }

  class Bird
  {
    public string Name { get; set; }


    // Constructor
    // IS a bird
    public Bird()
    {
      Squawk();
    }

    // Is not *A* bird, it is bird class itself!
    static public bool AreTheyAwesome()
    {
      var bird = new Bird();
      bird.Squawk();

      return true;
    }

    // Is a bird
    public void Squawk()
    {
      Console.WriteLine($"{Name} says Squawk!");
      if (Bird.AreTheyAwesome())
      {
        Console.WriteLine("AWESOME!");
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var louie = new Bird();
      louie.Squawk();

      Bird.AreTheyAwesome();

      var pizza = 2 * Math.Pi() * 16;

      Console.WriteLine("Welcome to C#");
    }
  }
}
