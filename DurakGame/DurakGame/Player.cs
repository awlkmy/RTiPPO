using System;
using System.Collections.Generic;
using System.Linq;

namespace DurakGame 
{
    public class Player
    {
        public string Name { get; private set; }
        public List<Card> Hand { get; private set; }

        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>();
        }

        public void TakeCards(List<Card> cards)
        {
            Hand.AddRange(cards);
        }

        public Card GetLowestTrumpCard(Suit trumpSuit)
        {
            return Hand.Where(card => card.Suit == trumpSuit).OrderBy(card => card.Rank).FirstOrDefault();
        }
    }

}