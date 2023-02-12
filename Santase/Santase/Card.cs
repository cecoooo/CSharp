using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Santase;

public class Card
{
    private char rank;
    private char suit;

    public Card(char rank, char suit) 
    {
        this.Rank = rank;
        this.Suit = suit;
    }

    public char Rank 
    {
        get { return this.rank; }
        private set {
            if (value == 48 || value == 57 || value == 65 || value == 74 || value == 75 || value == 81) this.rank = value;
            else throw new ArgumentException("Invalid card rank is given.");
        }
    }
    public char Suit
    {
        get { return this.suit; }
        private set
        {
            if (value == 67 || value == 68 || value == 72 || value == 83) this.suit = value;
            else throw new ArgumentException("Invalid card suit is given.");
        }
    }
    public override string ToString()
    {
        string r = "";
        string s = "";
        switch (this.Suit)
        {
            case 'C': s = "♣"; break;
            case 'D': s = "♦"; break;
            case 'H': s = "♥"; break;
            case 'S': s = "♠"; break;
        }
        switch (this.Rank)
        {
            case '0': r = "10"; break;
            case '9': r = "9"; break;
            case 'J': r = "J"; break;
            case 'Q': r = "Q"; break;
            case 'K': r = "K"; break;
            case 'A': r = "A"; break;
        }
        return r+s;
    }
}