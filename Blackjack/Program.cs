using System;
using System.Collections.Generic;

// | Face  | Value |
// | ----- | ----- |
// | 2     | 2     |
// | 3     | 3     |
// | 4     | 4     |
// | 5     | 5     |
// | 6     | 6     |
// | 7     | 7     |
// | 8     | 8     |
// | 9     | 9     |
// | 10    | 10    |
// | Jack  | 10    |
// | Queen | 10    |
// | King  | 10    |
// | Ace   | 11    |


// # Data Structure

// The following Nouns exist in the description of the "P"roblem:

// - Deck
// - Card
// - Hand
// - Player
// - Dealer

// These have the following STATE (properties) and BEHAVIOR (methods)

// - Deck

//   - Properties: A list of 52 cards
//   - Behavior: Make a new deck of 52 shuffled cards. Deal one card out of the deck.

// - Card
class Card
{
  //   - Properties: The Face of the card, the Suit of the card
  public string Face { get; set; }
  public string Suit { get; set; }

  override public string ToString()
  {
    return $"The {Face} of {Suit}";
  }

  //   - Behaviors:
  //     - The Value of the card according to the table in the "P"roblem part
}

// - Hand
class Hand
{
  //   - Properties: A list of individual Cards
  public List<Card> CurrentCards { get; set; } = new List<Card>();

  // This uses the constructor to initialize the list of cards
  // public Hand()
  // {
  //   CurrentCards = new List<Card>();
  // }

  //   - Behaviors:
  //     - TotalValue representing he sum of the individual Cards in the list.
  //       - Start with a total = 0
  //       - For each card in the hand do this:
  //         - Add the amount of that card's value to total
  //       - return "total" as the result

  // - Add a card to the hand
  public void AddCard(Card cardToAdd)
  {
    //       - Adds the supplied card to the list of cards
    CurrentCards.Add(cardToAdd);
  }
}

// - Player is just an instance of the Hand class
// - Dealer is just an instance of the Hand class

namespace Blackjack
{
  class Program
  {
    static void Main(string[] args)
    {
      // 1.  Create a new deck
      //     PEDAC ^^^^ - Properties: A list of 52 cards
      //     Algorithm for making a list of 52 cards

      //         Make a blank list of cards -- call this `deck`
      var deck = new List<Card>();

      //         Suits is a list of "Club", "Diamond", "Heart", or "Spade"
      var suits = new List<string>() { "Club", "Diamond", "Heart", "Spade" };

      //         Faces is a list of 2, 3, 4, 5, 6, 7, 8, 9, 10, Jack, Queen, King, or Ace
      var faces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

      //         ```
      //         Go through all of the suits one at a time and in order
      foreach (var suit in suits)
      {
        //             Go through all of the faces one a time and in order
        foreach (var face in faces)
        {
          //     With the current suit and the current face, make a new card
          var newCard = new Card()
          {
            Suit = suit,
            Face = face,
          };

          //     Add that card to the list of cards
          deck.Add(newCard);
        }
      }

      // 2.  Ask the deck to make a new shuffled 52 cards
      // numberOfCards = length of our deck
      var numberOfCards = deck.Count;

      // for rightIndex from numberOfCards - 1 down to 1 do:
      for (var rightIndex = numberOfCards - 1; rightIndex > 1; rightIndex--)
      {
        //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
        var randomNumberGenerator = new Random();
        var leftIndex = randomNumberGenerator.Next(rightIndex);

        //   Now swap the values at rightIndex and leftIndex by doing this:
        //     leftCard = the value from deck[leftIndex]
        var leftCard = deck[leftIndex];
        //     rightCard = the value from deck[rightIndex]
        var rightCard = deck[rightIndex];
        //     deck[rightIndex] = leftCard
        deck[rightIndex] = leftCard;
        //     deck[leftIndex] = rightCard
        deck[leftIndex] = rightCard;
      }

      // 3.  Create a player hand
      var player = new Hand();

      // 4.  Create a dealer hand
      var dealer = new Hand();

      // 5.  Ask the deck for a card and place it in the player hand
      //   - the card is equal to the 0th index of the deck list
      // 6.  Ask the deck for a card and place it in the player hand
      for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
      {
        var card = deck[0];
        //   - Remove that card from the deck list
        deck.Remove(card);
        //   - call the "add card" behavior of the hand and pass it this card
        player.AddCard(card);
      }

      // 7.  Ask the deck for a card and place it in the dealer hand
      // 8.  Ask the deck for a card and place it in the dealer hand
      for (var numberOfCardsToDeal = 0; numberOfCardsToDeal < 2; numberOfCardsToDeal++)
      {
        var card = deck[0];
        //   - Remove that card from the deck list
        deck.Remove(card);
        //   - call the "add card" behavior of the hand and pass it this card
        dealer.AddCard(card);
      }

      Console.WriteLine();
      // 9.  Show the player the cards in their hand and the TotalValue of their Hand
      // 10. If they have BUSTED (hand TotalValue is > 21), then goto step 15
      // 11. Ask the player if they want to HIT or STAND
      // 12. If HIT
      //     - Ask the deck for a card and place it in the player hand, repeat step 10
      // 13. If STAND then continue on
      // 14. If the dealer's hand TotalValue is more than 21 then goto step 17
      // 15. If the dealer's hand TotalValue is less than 17
      //     - Add a card to the dealer hand and go back to 14
      // 16. Show the dealer's hand TotalValue
      // 17. If the player's hand TotalValue > 21 show "DEALER WINS"
      // 18. If the dealer's hand TotalValue > 21 show "PLAYER WINS"
      // 19. If the dealer's hand TotalValue is more than the player's hand TotalValue then show "DEALER WINS", else show "PLAYER WINS"
      // 20. If the value of the hands are even, show "DEALER WINS"
    }
  }
}
