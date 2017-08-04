using System;
using System.Linq;

namespace DeckOfCards.Domain
{
    public class NormalCard : ICard
    {
        public NormalCard(Suit suit, string value)
        {
            if (Suit == Suit.None)
            {
                throw new ArgumentException("Normal cards just have a suit", nameof(suit));
            }

            if (!CardValues.ValidValues.Contains(value) || value == CardValues.Joker)
            {
                throw new ArgumentException($"Normal cards must have a valid value and not be a joker. Valid values: {string.Concat(CardValues.ValidValues, ", ")}", nameof(value));
            }

            Suit = suit;
            Value = value;
        }

        public Suit Suit { get; }
        public string Value { get; }

        public override string ToString()
        {
            return $"{Value} of {Suit}";
        }
    }
}