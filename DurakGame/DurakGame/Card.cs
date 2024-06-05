using System;

public enum Suit
{
    Clubs,
    Diamonds,
    Hearts,
    Spades
}

public enum Rank
{
    Six = 6,
    Seven,
    Eight,
    Nine,
    Ten,
    Jack,
    Queen,
    King,
    Ace
}

public class Card : IComparable<Card>
{
    public Suit Suit { get; private set; }
    public Rank Rank { get; private set; }

    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public bool CanBeat(Card other, Suit trumpSuit)
    {
        if (Suit == other.Suit && Rank > other.Rank) return true;
        if (Suit == trumpSuit && other.Suit != trumpSuit) return true;
        return false;
    }

    public int CompareTo(Card other)
    {
        if (Suit == other.Suit)
        {
            return Rank.CompareTo(other.Rank);
        }
        else
        {
            return Suit.CompareTo(other.Suit);
        }
    }

    public override string ToString()
    {
        return $"{Rank} of {Suit}";
    }
}
