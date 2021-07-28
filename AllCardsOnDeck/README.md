# AllCardsOnDeck

PEDAC

Problem
Example
Data (data structure)
Algorithm
Code

Problem

    Once the program starts, you should create a new deck.
    After deck creation, you should shuffle the deck.
    After the deck is shuffled, display the top two cards.

    Your deck should contain 52 unique cards.
    All cards should be represented as a string such as "Ace of Hearts"
    There are four suits: "Clubs", "Diamonds", "Hearts", and "Spades".
    There are 13 ranks: "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", and "King".

    Create a new deck of cards which will be a list of 52 strings where the strings are similar to "Ace of Clubs", "2 of Clubs", ... , "Ace of Diamonds", ... -- Then when we have list of cards we will shuffle them with the Fisher Yates. Then we will show the 0th index of the list and the 1st index of the list to show the first two cards.

Example Data

    Ace of Clubs
    2 of Clubs
    3 of Clubs
    4 of Clubs
    5 of Clubs
    6 of Clubs
    7 of Clubs
    8 of Clubs
    9 of Clubs
    10 of Clubs
    Jack of Clubs
    Queen of Clubs
    King of Clubs
    Ace of Diamonds
    ...
    ALL 52 CARDS

Data (data structure)

`string`
`List`
looping?
There are four suits: "Clubs", "Diamonds", "Hearts", and "Spades".
There are 13 ranks: "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", and "King".

Algorithm A

- Make a new list of strings named `deck`
- Initialize the list of strings with 52 explicity stated cards from our Example section - Shuffle them with Fisher Yates (paste algo here)

  numberOfCards = length of our deck

  for rightIndex from numberOfCards - 1 down to 1 do:
  leftIndex = random integer that is greater than or equal to 0 and LESS than rightIndex. See the section "How do we get a random integer")

       Now swap the values at rightIndex and leftIndex by doing this:
         leftCard = the value from deck[leftIndex]
         rightCard = the value from deck[rightIndex]
         deck[rightIndex] = leftCard
         deck[leftIndex] = rightCard

  - first card = deck[0]
  - second card = deck[1]
  - print first and second card

Algorithm B

- Make a list of the 4 suits and call this list `suits`
- Make a list of the 13 ranks and call this list `ranks`
- Make a new list of strings named `deck`
- Make a loop that goes through the list `suits`
  - Make a loop that goes through the list `ranks`
    - for each rank, make a new string of the form $"{rank} of ${suit}"
    - add that newly formed string to the end of the deck list
- Same as Algo A
