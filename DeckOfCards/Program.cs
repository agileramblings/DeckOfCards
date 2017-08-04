using System;
using DeckOfCards.Domain;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            var includeJokers = args.Length > 0 && args[0] == "-include";
            var verb = includeJokers ? "include" : "exclude";
            Console.WriteLine("Welcome to our Deck of Cards Console Application");
            Console.WriteLine($"You have decided to {verb} jokers in your deck.");

            var deckOfCardsWithJokers = new Deck(includeJokers);
            Console.WriteLine();
            Console.WriteLine("We are now going to take the top card from the stack until the stack is empty.");
            Console.WriteLine();

            while (deckOfCardsWithJokers.CardsRemaining > 0)
            {
                var poppedCard = deckOfCardsWithJokers.TakeTopCard();
                Console.WriteLine($"You pulled the {poppedCard}. Cards Remaining: {deckOfCardsWithJokers.CardsRemaining} Cards Used: {deckOfCardsWithJokers.CardsUsed}");
            }

            Console.WriteLine();
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press a key to <EXIT>");
            Console.ReadKey();
        }
    }
}