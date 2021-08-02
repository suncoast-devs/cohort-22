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

  // Adds multiple cards to my hand
  public void AddCards(List<Card> cardsToAdd)
  {
    foreach (Card card in cardsToAdd)
    {
      AddCard(card);
    }
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

  public bool NotBusted()
  {
    return !Busted();
  }

  public bool Busted()
  {
    return TotalValue() > 21;

    // if (TotalValue() > 21)
    // {
    //   return true;
    // }
    // else
    // {
    //   return false;
    // }
  }

  public bool DealerShouldHit()
  {
    return TotalValue() <= 17;

    // if (TotalValue() <= 17)
    // {
    //   return true;
    // }
    // else
    // {
    //   return false;
    // }
  }
}

class Deck
{
  public List<Card> Cards { get; set; } = new List<Card>();

  // Behaviors:
  //   Initialize a list of 52 cards
  public void Initialize()
  {
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
        Cards.Add(newCard);
      }
    }
  }

  //   Shuffle
  public void Shuffle()
  {
    // 2.  Ask the deck to make a new shuffled 52 cards
    // numberOfCards = length of our deck
    var numberOfCards = Cards.Count;

    // for rightIndex from numberOfCards - 1 down to 1 do:
    for (var rightIndex = numberOfCards - 1; rightIndex > 1; rightIndex--)
    {
      //   leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")
      var randomNumberGenerator = new Random();
      var leftIndex = randomNumberGenerator.Next(rightIndex);

      //   Now swap the values at rightIndex and leftIndex by doing this:
      //     leftCard = the value from Cards[leftIndex]
      var leftCard = Cards[leftIndex];
      //     rightCard = the value from Cards[rightIndex]
      var rightCard = Cards[rightIndex];
      //     Cards[rightIndex] = leftCard
      Cards[rightIndex] = leftCard;
      //     Cards[leftIndex] = rightCard
      Cards[leftIndex] = rightCard;
    }
  }

  //   Deal a single card
  public Card Deal()
  {
    var card = Cards[0];

    Cards.Remove(card);

    return card;
  }

  public List<Card> DealMultiple(int numberOfCardsToDeal)
  {
    var multipleCards = new List<Card>();

    for (int count = 0; count < numberOfCardsToDeal; count++)
    {
      Card dealtCard = Deal();

      multipleCards.Add(dealtCard);
    }

    return multipleCards;
  }
}

// - Player is just an instance of the Hand class
// - Dealer is just an instance of the Hand class

namespace Blackjack
{
  class Program
  {
    static void PlayTheGame()
    {
      // 1.  Create a new deck
      //     PEDAC ^^^^ - Properties: A list of 52 cards
      //     Algorithm for making a list of 52 cards

      //         Make a blank list of cards -- call this `deck`

      var deck = new Deck();
      deck.Initialize();
      deck.Shuffle();

      // 3.  Create a player hand
      var player = new Hand();

      // 4.  Create a dealer hand
      var dealer = new Hand();

      // 5.  Ask the deck for a card and place it in the player hand
      //   - the card is equal to the 0th index of the deck list
      // 6.  Ask the deck for a card and place it in the player hand
      player.AddCards(deck.DealMultiple(2));

      // 7.  Ask the deck for a card and place it in the dealer hand
      // 8.  Ask the deck for a card and place it in the dealer hand
      dealer.AddCards(deck.DealMultiple(2));

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
          Card card = deck.Deal();

          player.AddCard(card);
        }
        // 13. If STAND then continue on
      }

      player.PrintCardsAndTotal("Player");

      // 14. If the dealer's hand TotalValue is more than 21 then goto step 17
      // 15. If the dealer's hand TotalValue is less than 17
      while (player.NotBusted() && dealer.DealerShouldHit())
      {
        //     - Add a card to the dealer hand
        Card card = deck.Deal();

        dealer.AddCard(card);
        // and go back to 14
      }

      // 16. Show the dealer's hand TotalValue
      dealer.PrintCardsAndTotal("Dealer");

      // 17. If the player's hand TotalValue > 21 show "DEALER WINS"
      if (player.Busted())
      {
        Console.WriteLine("DEALER WINS");
      }
      else
      // 18. If the dealer's hand TotalValue > 21 show "PLAYER WINS"
      if (dealer.Busted())
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

    // Example of a method to build a deck
    //
    // static List<Card> BuildDeck()
    // {
    //   var theDeckWeAreCurrentlyBuilding = new List<Card>();

    //   /// Code to build a deck


    //   return theDeckWeAreCurrentlyBuilding;
    // }

    static void Main(string[] args)
    {
      // Example of doing deck building in a method

      // var theDeckWeJustBuilt = BuildDeck();
      // Console.WriteLine(theDeckWeJustBuilt.Count);

      while (true)
      {
        PlayTheGame();

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Would you like to play again? ");
        var answer = Console.ReadLine().ToUpper();

        if (answer == "NO")
        {
          Console.WriteLine("Bye.....");
          break;
        }
      }
    }
  }
}
