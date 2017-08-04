using System;
using DeckOfCards.Domain;
using Xunit;

namespace DeckOfCards.Tests
{
    public class CardTests
    {
        [Fact]
        public void AnNormalCardShouldHaveNonDefaultConstructor()
        {
            var sut = new NormalCard(Suit.Clubs, CardValues.Ace);
            Assert.NotNull(sut);
        }
        [Fact]
        public void AnJokerCardShouldHaveDefaultConstructorOnly()
        {
            var sut = new JokerCard();
            Assert.NotNull(sut);
        }

        [Fact]
        public void AllCardShouldHaveASuit()
        {
            var sut = new NormalCard(Suit.Clubs, CardValues.Ace);
            Assert.Equal(Suit.Clubs, sut.Suit);
            var jSut = new JokerCard();
            Assert.Equal(Suit.None, jSut.Suit);
        }

        [Fact]
        public void AllCardShouldHaveAValue()
        {
            var sut = new NormalCard(Suit.Clubs, CardValues.Ace);
            Assert.Equal(CardValues.Ace, sut.Value);
            var jSut = new JokerCard();
            Assert.Equal(CardValues.Joker, jSut.Value);
        }

        [Fact]
        public void ACardShouldNotAllowInvalidValueAndThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new NormalCard(Suit.Clubs, "Z"));
            Assert.Throws<ArgumentException>(() => new NormalCard(Suit.Clubs, "11"));
            Assert.Throws<ArgumentException>(() => new NormalCard(Suit.Clubs, "King"));
            Assert.Throws<ArgumentException>(() => new NormalCard(Suit.Clubs, "Random String"));
        }

        public void ANormalCardSHouldNotAllowAnInvalidSuitAndThrowAnException()
        {
            Assert.Throws<ArgumentException>(() => new NormalCard(Suit.None, CardValues.Ace));
            Assert.Throws<ArgumentException>(() => new NormalCard((Suit)5, CardValues.Ace));
        }
    }
}