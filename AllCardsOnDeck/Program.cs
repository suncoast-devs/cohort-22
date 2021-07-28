using System;

namespace AllCardsOnDeck
{
  class Program
  {
    static void Main(string[] args)
    {
      // - Make a new list of strings named `deck`
      // - Initialize the list of strings with 52 explicity stated cards from our Example section - Shuffle them with Fisher Yates (paste algo here)

      //   numberOfCards = length of our deck

      //   for rightIndex from numberOfCards - 1 down to 1 do:
      //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")

      //        Now swap the values at rightIndex and leftIndex by doing this:
      //          leftCard = the value from deck[leftIndex]
      //          rightCard = the value from deck[rightIndex]
      //          deck[rightIndex] = leftCard
      //          deck[leftIndex] = rightCard

      //   - first card = deck[0]
      //   - second card = deck[1]
      //   - print first and second card
    }
  }
}
