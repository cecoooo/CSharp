using System;
using System.Collections.Generic;
using System.Text;
using Basketball;

public class Player
{
    public string Name { get; set; }
    public string Position { get; set; }
    public double Rating { get; set; }
    public int Games { get; set; }
    public bool Retired { get; set; } = false;
    public Player(string name, string posotion, double rating, int games)
    {
        this.Name = name;
        this.Position = posotion;   
        this.Rating = rating;
        this.Games = games;
    }
    public override string ToString()
    {
        return $"-Player: {this.Name}" +
            $"--Position: {this.Position}" +
            $"--Rating: {this.Rating}" +
            $"--Games played: {this.Games}";
    }
}
