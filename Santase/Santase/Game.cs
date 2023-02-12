using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks.Dataflow;
using Santase;

public class Game
{
    private static List<string> DECK = new List<string>() { "9C", "9D", "9H", "9S", "0C", "0D", "0H", "0S", "JC", "JD", "JH", "JS", "QC", "QD", "QH", "QS", "KC", "KD", "KH", "KS", "AC", "AD", "AH", "AS" };
    private Player you;
    private Player opponent;
    private int goal;
    public Game(Player you, Player opponent, int goal)
    {
        this.you = you;
        this.opponent = opponent;   
        this.Goal = goal;
    }

    public Player You 
    {
        get { return this.you; }
    }
    public Player Opponent
    {
        get { return this.opponent; }
    }
    public int Goal
    {
        get { return this.goal; }
        private set { 
            if(value > 0) this.goal = value;
            else throw new ArgumentException("Goal must be bigger than zero.");
        }
    }

    
    public string Play()
    {
        Player you = this.You;
        Player opponent = this.Opponent;
        int rand = Random(1, 3);
        Player first;
        Player second;
        switch (rand)
        {
            case 1: first = you; second = opponent; break;
            default:
                first = opponent; second = you;
                break;
        }
        int goal = this.Goal;
        while (first.GamesWon < goal)
        {
            List<string> cards = MixCards();
            int leftCards = 24;
            FirstHand(first, second, cards);
            char trump = ShooceTrump(cards);
            PrintCards(trump);
            while (leftCards != 0 || first.Points < 66)
            {
                if (first.Equals(this.you)) first.Move();
                else first.Move(trump, leftCards);
                second.Responce();
            }
        }
        return first.Name;
    }



    private int Random(int start, int end)
    {
        Random random = new Random();
        return random.Next(start, end);
    }

    private Card GetNewCard(List<string> deck)
    {
        string card = deck[0];
        deck.Remove(card);
        return new Card(card[0], card[1]);
    }

    private List<string> MixCards() 
    {
        List<string> deck = new List<string>();
        while (deck.Count != 24) 
        {
            string card = DECK[Random(0, DECK.Count)];
            if (!deck.Contains(card))
                deck.Add(card);
        }
        return deck;
    }
    
    private void FirstHand(Player first, Player second, List<string> deck) 
    {
        for (int i = 0; i < 6; i++)
        {
            first.AddNewCard(GetNewCard(deck));
            second.AddNewCard(GetNewCard(deck));
        }
    }
    private char ShooceTrump(List<string> cards)
    {
        string card = cards[0];
        cards[0] = cards[cards.Count - 1];
        cards[cards.Count - 1] = card;
        return cards[cards.Count - 1][1];
    }
    private void PrintCards(char trump)
    {
        string suit = "";
        switch (trump)
        {
            case 'C': suit = "♣"; break;
            case 'D': suit = "♦"; break;
            case 'H': suit = "♥"; break;
            case 'S': suit = "♠"; break;
        }
        Console.WriteLine($"Your Cards: {this.you.ViewCards()}\nTrump suit: {suit}");
    }

    private Card WinningHand(Card f, Card s, char trump)
    {
        if (f.Suit != s.Suit)
        {
            if (s.Suit == trump) return s;
            return f;
        }
        int fRankNum = 0;
        int sRankNum = 0;
        switch (f.Rank)
        {
            case 'J': fRankNum = 1; break;
            case 'Q': fRankNum = 2; break;
            case 'K': fRankNum = 3; break;
            case '0': fRankNum = 4; break;
            case 'A': fRankNum = 5; break;
        }
        switch (s.Rank)
        {
            case 'J': sRankNum = 1; break;
            case 'Q': sRankNum = 2; break;
            case 'K': sRankNum = 3; break;
            case '0': sRankNum = 4; break;
            case 'A': sRankNum = 5; break;
        }
        if(fRankNum > sRankNum) return f;
        return s;
    }
}