using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using DeckOfCards.Domain;
using Xunit;

namespace DeckOfCards.Tests
{
    public class DeckTests
    {
        [Fact]
        public void ADeckShouldOnlyHaveANonDefaultConstructor()
        {
            var sut = new Deck(includeJokers: true);
            Assert.NotNull(sut);
        }

        [Fact]
        public void ADeckThatIncludesJokersShouldHave54Cards()
        {
            var sut = GetJokerDeck();
            Assert.Equal(54, sut.CardsRemaining);
        }
        [Fact]
        public void ADeckThatIncludesJokersShoulContainTwoJokers()
        {
            var sut = GetJokerDeck();
            Assert.Equal(54, sut.CardsRemaining);
            var jokerCardsFound = 0;
            for (int i = 0; i < 54; i++)
            {
                jokerCardsFound += CardValues.Joker == sut.TakeTopCard().Value ? 1 : 0;
            }
            Assert.Equal(2, jokerCardsFound);
        }

        [Fact]
        public void ADeckThatExcludesJokersShouldHave52Cards()
        {
            var sut = GetNoJokerDeck();
            Assert.Equal(52, sut.CardsRemaining);
        }
        [Fact]
        public void ADeckThatExcludesJokersShouldNotContainAnyJokers()
        {
            var sut = GetNoJokerDeck();
            Assert.Equal(52, sut.CardsRemaining);
            for (int i = 0; i < 52; i++)
            {
                Assert.NotEqual(CardValues.Joker, sut.TakeTopCard().Value);
            }
        }


        [Fact]
        public void ADeckShouldReturnNullWhenThereAreNoCardsRemaining()
        {
            var sut = GetJokerDeck();
            while (sut.TakeTopCard() != null) { }
            Assert.Null(sut.TakeTopCard());
        }

        [Fact]
        public void TakingACardShouldIncrementTheUsedCardsCount()
        {
            var sut = GetJokerDeck();
            Assert.Equal(54, sut.CardsRemaining);

            sut.TakeTopCard();

            Assert.Equal(53, sut.CardsRemaining);
            Assert.Equal(1, sut.CardsUsed);
        }

        [Fact]
        public void ShufflingTheDeckShouldResetCardCounts()
        {
            var sut = GetJokerDeck();
            Assert.Equal(54, sut.CardsRemaining);
            Assert.Equal(0, sut.CardsUsed);

            sut.TakeTopCard();

            Assert.Equal(53, sut.CardsRemaining);
            Assert.Equal(1, sut.CardsUsed);

            sut.ShuffleAllCards();

            Assert.Equal(54, sut.CardsRemaining);
            Assert.Equal(0, sut.CardsUsed);
        }

        [Fact]
        public void ShufflingTheDeckShouldProductDifferentFirstTopCard()
        {
            // it is entirely possible to get the same first card from two random decks
            // it is unlikely (1 in ~150k for 54 card deck) to get the same sequence of the first three cards, so we will test that
            var sut = GetJokerDeck();

            var firstDeckCard1 = sut.TakeTopCard();
            var firstDeckCard2 = sut.TakeTopCard();
            var firstDeckCard3 = sut.TakeTopCard();

            sut.ShuffleAllCards();

            var secondDeckCard1 = sut.TakeTopCard();
            var secondDeckCard2 = sut.TakeTopCard();
            var secondDeckCard3 = sut.TakeTopCard();

            var passedTest = firstDeckCard1.ToString() != secondDeckCard1.ToString() &&
                                 firstDeckCard2.ToString() != secondDeckCard2.ToString() &&
                                     firstDeckCard3.ToString() != secondDeckCard3.ToString();
            Assert.True(passedTest);
        }

        [Fact]
        public void SpeedTestOfGuidNewGuidvsRandomNext()
        {
            Random rnd = new Random();
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var guid = Guid.NewGuid();
            sw.Stop();
            long newGuidEt, rndNextEt;
            newGuidEt = sw.ElapsedTicks;
            Console.WriteLine($"Guid.NewGuid() took {newGuidEt} ticks");
            sw.Reset();
            sw.Start();
            var val = rnd.Next();
            sw.Stop();
            rndNextEt = sw.ElapsedTicks;
            Console.WriteLine($"Random.Next() took {rndNextEt} ticks");
        }

        private static Deck GetNoJokerDeck()
        {
            return new Deck(includeJokers: false);
        }

        private static Deck GetJokerDeck()
        {
            return new Deck(includeJokers: true);
        }
    }
}
