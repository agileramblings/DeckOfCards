using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckOfCards.Domain
{
    public class Deck
    {
        private readonly bool _includeJokers;
        private readonly Stack<ICard> _availableCards = new Stack<ICard>();
        private readonly Stack<ICard> _usedCards = new Stack<ICard>();
        private readonly Random _rnd = new Random();

        public Deck(bool includeJokers)
        {
            _includeJokers = includeJokers;
            ShuffleAllCards();
        }

        public int CardsRemaining => _availableCards.Count;
        public int CardsUsed => _usedCards.Count;

        public ICard TakeTopCard()
        {
            if (_availableCards.Count == 0)
            {
                return null;
            }

            var cardToReturn = _availableCards.Pop();
            _usedCards.Push(cardToReturn);
            return cardToReturn;
        }

        public void ShuffleAllCards()
        {
            _availableCards.Clear();
            _usedCards.Clear();

            var listOfCards = CreateNormalCardList();

            // add jokers as required
            if (_includeJokers)
            {
                listOfCards.AddRange(new[] { new JokerCard(), new JokerCard() });
            }

            // randomize deck
            foreach (var card in listOfCards.OrderBy(x => _rnd.Next()))
            {
                _availableCards.Push(card);
            }
        }

        private List<ICard> CreateNormalCardList()
        {
            var listOfCards = new List<ICard>(52);
            // create list of normal cards
            foreach(Suit suit in Enum.GetValues(typeof(Suit)))
            {
                if (suit == Suit.None) continue;

                foreach(var value in CardValues.ValidValues)
                {
                    listOfCards.Add(new NormalCard(suit, value));
                }
            }
            return listOfCards;
        }
    }
}