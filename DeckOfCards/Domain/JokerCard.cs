namespace DeckOfCards.Domain
{
    public class JokerCard : ICard
    {
        public Suit Suit => Suit.None;
        public string Value => CardValues.Joker;

        public override string ToString()
        {
            return Value;
        }
    }
}