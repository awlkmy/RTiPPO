using DurakGame;
using System.Collections.Generic;
using System.Linq;

public class Game
{
    public List<Player> Players { get; private set; }
    public Player CurrentPlayer { get; set; }
    public Player LeadingPlayer { get; set; }
    public List<Card> Table { get; private set; }
    public List<Card> DiscardPile { get; private set; }
    public Deck Deck { get; private set; }
    public Card TrumpCard { get; private set; }

    public Game(List<string> playerNames)
    {
        Players = new List<Player>();
        foreach (var name in playerNames)
        {
            Players.Add(new Player(name));
        }
        Table = new List<Card>();
        DiscardPile = new List<Card>();
        Deck = new Deck();
    }

    public void StartGame()
    {
        Deck.Shuffle();
        foreach (var player in Players)
        {
            player.Hand.AddRange(Deck.DrawCards(6));
        }
        TrumpCard = Deck.DrawCard();
        if (TrumpCard != null)
        {
            Deck.PutTrumpCardToBottom(TrumpCard);
        }
    }

    public void ThrowCards(List<Card> cards)
    {
        foreach (var card in cards)
        {
            Table.Add(card);
            CurrentPlayer.Hand.Remove(card);
        }
    }

    public void EndTurn()
    {
        if (CurrentPlayer == Players[0])
        {
            CurrentPlayer = Players[1];
        }
        else
        {
            CurrentPlayer = Players[0];
        }
    }

    public void EndRound()
    {
        // Карты уходят в отбой
        MoveToDiscardPile();
        // Игроки добирают карты из колоды
        DrawCardsFromDeck();
        // Меняем ведущего игрока и отбивающегося
        SwitchPlayers();
    }

    public void MoveToDiscardPile()
    {
        DiscardPile.AddRange(Table);
        Table.Clear();
    }

    public void DrawCardsFromDeck()
    {
        foreach (var player in Players)
        {
            while (player.Hand.Count < 6 && Deck.GetRemainingCards() > 0)
            {
                player.Hand.Add(Deck.DrawCard());
            }
        }
    }

    public void SwitchPlayers()
    {
        LeadingPlayer = LeadingPlayer == Players[0] ? Players[1] : Players[0];
        CurrentPlayer = LeadingPlayer == Players[0] ? Players[1] : Players[0];
    }

    public void BotPlay()
    {
        // Пример логики для бота
        if (Table.Count == 0)
        {
            // Бот подкидывает карту
            Card cardToThrow = CurrentPlayer.Hand.FirstOrDefault();
            if (cardToThrow != null)
            {
                ThrowCards(new List<Card> { cardToThrow });
            }
        }
        else
        {
            // Бот отбивается или берет карты
            List<Card> cardsToBeat = new List<Card>();
            foreach (var card in Table)
            {
                Card cardToBeat = CurrentPlayer.Hand.FirstOrDefault(c => c.CanBeat(card, TrumpCard.Suit));
                if (cardToBeat != null)
                {
                    cardsToBeat.Add(cardToBeat);
                }
                else
                {
                    // Если бот не может побить все карты, он берет карты
                    CurrentPlayer.TakeCards(Table);
                    Table.Clear();
                    return;
                }
            }
            ThrowCards(cardsToBeat);
        }
        EndTurn();
    }

    public Player GetWinner()
    {
        foreach (var player in Players)
        {
            if (player.Hand.Count == 0 && Deck.GetRemainingCards() == 0)
            {
                return player;
            }
        }
        return null;
    }

    public int GetTotalCardsCount()
    {
        return Deck.GetRemainingCards() + (TrumpCard != null ? 1 : 0);
    }
}
