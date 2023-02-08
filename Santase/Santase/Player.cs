using System;
using System.Collections.Generic;
using System.Text;
using Santase;

public class Player
{
    private string name;
    private int points;

    public string Name
    {
        get { return name; }
    }
    public int Points
    {
        get { return points; }
    }

    public Player(string name)
    {
        this.name = name;
        points = 0;
    }
}