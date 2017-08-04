using System.Collections.Generic;

namespace DeckOfCards.Domain
{
    public static class CardValues
    {
        public const string Ace = "A";
        public const string King = "K";
        public const string Queen = "Q";
        public const string Jack = "J";
        public const string Ten = "10";
        public const string Nine = "9";
        public const string Eight = "8";
        public const string Seven = "7";
        public const string Six = "6";
        public const string Five = "5";
        public const string Four = "4";
        public const string Three = "3";
        public const string Two = "2";
        public const string Joker = "Joker";

        public static readonly IReadOnlyCollection<string> ValidValues = new List<string>{Ace, King, Queen, Jack, Ten, Nine, Eight, Seven, Six, Five, Four, Three, Two};
    }
}

