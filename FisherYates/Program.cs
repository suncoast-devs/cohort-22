using System;
using System.Collections.Generic;

namespace FisherYates
{
  class Program
  {
    static void Main(string[] args)
    {
      var students = new List<string>() { "Nam", "Dom", "Drew", "Shawn", "Mila", "Austin" };

      // numberOfCards = length of our students

      // for rightIndex from numberOfCards - 1 down to 1 do:
      //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")

      //   Now swap the values at rightIndex and leftIndex by doing this:
      //     leftCard = the value from students[leftIndex]
      //     rightCard = the value from students[rightIndex]
      //     students[rightIndex] = leftCard
      //     students[leftIndex] = rightCard
    }
  }
}
