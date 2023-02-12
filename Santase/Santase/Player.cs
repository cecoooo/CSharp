using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Santase;

public class Player
{
    private string name;
    private int points;
    private int gamesWon;
    private List<Card> cards;

    public Player(string name)
    {
        this.Name = name;
        this.Points = 0;
        this.GamesWon = 0;
        this.cards = new List<Card>();
    }
    public string Name
    {
        get { return name; }
        private set {
            if (!String.IsNullOrWhiteSpace(value)) name = value;
            else throw new ArgumentException("Name must not be empty string, null or spaces only"); 
        }
    }
    public int Points
    {
        get { return points; }
        private set { 
            if(value >= 0) points = value;
            else throw new ArgumentOutOfRangeException("Points must not be lower than zero.");   
        }
    }
    public int GamesWon
    {
        get { return this.gamesWon; }
        private set
        {
            if (value >= 0) this.gamesWon = value;
            else throw new ArgumentOutOfRangeException("Points must not be lower than zero.");
        }
    }

    public Card Move()
    {
        int num = int.Parse(Console.ReadLine());
        if (num < 1 || num > this.cards.Count) 
            throw new ArgumentOutOfRangeException($"No spot {num} in you cards.");
        Card card = this.cards[num-1];
        this.cards.Remove(card);
        return card;
    }
    public Card Move(char trump, int leftCards)
    {
        Card card = null;
        if (this.cards.Contains(new Card('Q', trump)) && this.cards.Contains(new Card('K', trump))) 
            card = new Card('Q', trump);
        else if (this.cards.Contains(new Card('Q', 'C')) && this.cards.Contains(new Card('K', 'C')))
            card = new Card('Q', 'C');
        else if (this.cards.Contains(new Card('Q', 'D')) && this.cards.Contains(new Card('K', 'D'))) 
            card = new Card('Q', 'D');
        else if (this.cards.Contains(new Card('Q', 'H')) && this.cards.Contains(new Card('K', 'H'))) 
            card = new Card('Q', 'H');
        else if (this.cards.Contains(new Card('Q', 'S')) && this.cards.Contains(new Card('K', 'S'))) 
            card = new Card('Q', 'S');
        else if (leftCards > 12)
            card = this.cards.FindLast(x => (x.Rank == '9' && x.Suit != trump) || (x.Rank == 'J' && x.Suit != trump) || (x.Rank == 'Q' && x.Suit != trump) || (x.Rank == 'K' && x.Suit != trump) || (x.Rank == '0' && x.Suit != trump));
        else
            card = this.cards.FindLast(x => x.Rank == 'A' || x.Rank == '0' || x.Rank == 'K' || x.Rank == 'Q' || x.Rank == 'J' || x.Rank == '9');
        this.cards.Remove(card);
        return card;
    }

    public void Responce()
    {

    }

    public void AddNewCard(Card card) => this.cards.Add(card);
    public void RemoveCard(Card card) => this.cards.Remove(card);
    
    public void AddPoints(int points) => this.Points += points;
    
    public void AddGamesWon(int games) => this.GamesWon += games;
    
    public void GameOver() => this.Points = 0;

    public string ViewCards() 
    {
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < this.cards.Count; i++)
        {
            res.Append(cards[i].ToString()).Append(" ");
        }
        return res.ToString().Trim();
    }
    
}