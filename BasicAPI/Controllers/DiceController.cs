using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DiceController : ControllerBase
  {
    [HttpGet("{sides}")]
    public List<int> Roll(int sides, int count = 1)
    {
      var rolls = new List<int>();

      // Make a random number generator
      var randomNumberGenerator = new Random();

      for (var rollNumber = 0; rollNumber < count; rollNumber++)
      {
        // Next(sides) would make a number between 0 and just less than sides
        // so return that number plus one. Making the range from 1 to a number
        // INCLUDING the value of sides.
        var roll = randomNumberGenerator.Next(sides) + 1;

        rolls.Add(roll);
      }

      return rolls;
    }
  }
}