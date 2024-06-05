using System;
using System.Collections.Generic;

public class Deck
{
    private List<Card> cards;
    private Random random = new Random();

    public Deck()
    {
        cards = new List<Card>();
        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (Rank rank in Enum.GetValues(typeof(Rank)))
            {
                cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        int n = cards.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = cards[i];
            cards[i] = cards[j];
            cards[j] = temp;
        }
    }

    public Card DrawCard()
    {
        if (cards.Count == 0) return null;
        Card card = cards[cards.Count - 1];
        cards.RemoveAt(cards.Count - 1);
        return card;
    }

    public List<Card> DrawCards(int count)
    {
        List<Card> drawnCards = new List<Card>();
        for (int i = 0; i < count; i++)
        {
            Card card = DrawCard();
            if (card != null)
            {
                drawnCards.Add(card);
            }
        }
        return drawnCards;
    }

    public void PutTrumpCardToBottom(Card trumpCard)
    {
        cards.Insert(0, trumpCard);
    }

    public int GetRemainingCards()
    {
        return cards.Count;
    }
}
