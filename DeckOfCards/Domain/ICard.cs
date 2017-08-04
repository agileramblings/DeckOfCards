namespace DeckOfCards.Domain
{
    public interface ICard
    {
        Suit Suit { get; }
        string Value { get; }
    }
}