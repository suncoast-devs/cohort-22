using System;
using System.Collections.Generic;




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

  public int Value()
  {
    // var values = new Dictionary<string, int>();
    // for (var number = 2; number <= 10; number++)
    // {
    //   values.Add($"{number}", number);
    // }
    // values.Add("Jack", 10);
    // values.Add("Queen", 10);
    // values.Add("King", 10);
    // values.Add("Ace", 11);

    // return values[Face];

    switch (Face)
    {
      case "2":
      case "3":
      case "4":
      case "5":
      case "6":
      case "7":
      case "8":
      case "9":
      case "10":
        return int.Parse(Face);

      case "Jack":
      case "Queen":
      case "King":
        return 10;

      case "Ace":
        return 11;

      default:
        return 0;
    }
  }

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
  public int TotalValue()
  {
    //       - Start with a total = 0
    var total = 0;
    //       - For each card in the hand do this:
    foreach (var card in CurrentCards)
    {
      //         - Add the amount of that card's value to total
      total = total + card.Value();
    }

    //       - return "total" as the result
    return total;
  }

  // - Add a card to the hand
  public void AddCard(Card cardToAdd)
  {
    //       - Adds the supplied card to the list of cards
    CurrentCards.Add(cardToAdd);
  }

  public void PrintCardsAndTotal(string handName)
  {
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine($"{handName}, your cards are:");
    Console.WriteLine(String.Join(", ", CurrentCards));

    //     and the TotalValue of their Hand
    Console.WriteLine($"The total value of your hand is: {TotalValue()}");
    Console.WriteLine();
    Console.WriteLine();
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
      while (true)
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


        // 10. If they have BUSTED (hand TotalValue is > 21), then goto step 15
        var answer = "";

        while (player.TotalValue() < 21 && answer != "STAND")
        {
          // 9.  Show the player the cards in their hand
          //     Loop through the list of cards in the player's hand
          //       for every card, print out to the user the description of the card

          player.PrintCardsAndTotal("Player");

          // 11. Ask the player if they want to HIT or STAND
          Console.Write("Do you want to HIT or STAND? ");
          answer = Console.ReadLine().ToUpper();

          // 12. If HIT
          if (answer == "HIT")
          {
            //     - Ask the deck for a card and place it in the player hand, repeat step 10
            var newCard = deck[0];
            deck.Remove(newCard);

            player.AddCard(newCard);
          }
          // 13. If STAND then continue on
        }

        player.PrintCardsAndTotal("Player");

        // 14. If the dealer's hand TotalValue is more than 21 then goto step 17
        // 15. If the dealer's hand TotalValue is less than 17
        while (player.TotalValue() <= 21 && dealer.TotalValue() <= 17)
        {
          //     - Add a card to the dealer hand
          var newCard = deck[0];
          deck.Remove(newCard);

          dealer.AddCard(newCard);
          // and go back to 14
        }

        // 16. Show the dealer's hand TotalValue
        dealer.PrintCardsAndTotal("Dealer");

        // 17. If the player's hand TotalValue > 21 show "DEALER WINS"
        if (player.TotalValue() > 21)
        {
          Console.WriteLine("DEALER WINS");
        }
        else
        // 18. If the dealer's hand TotalValue > 21 show "PLAYER WINS"
        if (dealer.TotalValue() > 21)
        {
          Console.WriteLine("PLAYER WINS");
        }
        else
        // 19. If the dealer's hand TotalValue is more than the player's hand TotalValue then show "DEALER WINS", else show "PLAYER WINS"
        if (dealer.TotalValue() > player.TotalValue())
        {
          Console.WriteLine("DEALER WINS");
        }
        else
        if (player.TotalValue() > dealer.TotalValue())
        {
          Console.WriteLine("PLAYER WINS");
        }
        else
        {
          // 20. If the value of the hands are even, show "DEALER WINS"
          Console.WriteLine("DEALER WINS");
        }
      }
    }
  }
}
