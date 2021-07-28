using System;
using System.Collections.Generic;

namespace AllCardsOnDeck
{
  class Program
  {
    static void Main(string[] args)
    {
      // - Make a new list of strings named `deck`
      // - Initialize the list of strings with 52 explicity stated cards from our Example section - Shuffle them with Fisher Yates (paste algo here)
      var deck = new List<string>() {
        "Ace of Clubs", "2 of Clubs", "3 of Clubs", "4 of Clubs", "5 of Clubs", "6 of Clubs", "7 of Clubs", "8 of Clubs", "9 of Clubs", "10 of Clubs", "Jack of Clubs", "Queen of Clubs", "King of Clubs",
        "Ace of Diamonds", "2 of Diamonds",
      };

      //   numberOfCards = length of our deck
      var numberOfCards = deck.Count;

      //   for rightIndex from numberOfCards - 1 down to 1 do:
      for (var rightIndex = numberOfCards - 1; rightIndex >= 1; rightIndex--)
      {
        //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
        var randomNumberGenerator = new Random();
        var leftIndex = randomNumberGenerator.Next(rightIndex);

        //        Now swap the values at rightIndex and leftIndex by doing this:
        //          leftCard = the value from deck[leftIndex]
        var leftCard = deck[leftIndex];
        //          rightCard = the value from deck[rightIndex]
        var rightCard = deck[rightIndex];
        //          deck[rightIndex] = leftCard
        deck[rightIndex] = leftCard;
        //          deck[leftIndex] = rightCard
        deck[leftIndex] = rightCard;
      }

      Console.WriteLine("Done shuffling");

      //   - first card = deck[0]
      var firstCard = deck[0];
      //   - second card = deck[1]
      var secondCard = deck[1];
      //   - print first and second card
      Console.WriteLine(firstCard);
      Console.WriteLine(secondCard);

      Console.WriteLine($"The first card is {firstCard} and the second card is {secondCard}");
    }
  }
}
