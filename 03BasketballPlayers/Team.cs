using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Basketball;

public class Team : IEnumerable<Player>
{
    private Player[] data = new Player[4];
    public string Name { get; set; }
    public int OpenPositions { get; set; }
    public char Group { get; set; }
    public int Count { get; private set; } = 0;
    public Team(string name, int openposition, char group)
    {
        this.Name = name;
        this.OpenPositions = openposition;
        this.Group = group;
    }
    public IEnumerator<Player> GetEnumerator()
    {
        foreach (var player in this)
            yield return player;
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
    public string AddPlayer(Player player)
    {
        string text = string.Empty;
        if (player.Name == null || player.Name == string.Empty)
        {
            return "Invalid player's information.";
        }
        else if (player.Position == null || player.Position == string.Empty)
        {
            return "Invalid player's information.";
        }
        else if (this.OpenPositions == 0)
        {
            return "There are no more open positions.";
        }
        else if (player.Rating < 80)
        {
            return "Invalid player's rating.";
        }
        else
        {
            if (data.Length == Count)
                ExtendData();
            this.data[this.Count] = player;
            this.Count++;
            this.OpenPositions--;
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }
    }
    public bool RemovePlayer(string name)
    {
        bool isTrue = false;
        Player[] newData = new Player[this.data.Length];
        int c = 0;
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Name == name)
            {
                isTrue = true;
                continue;
            }
            newData[c] = this.data[i];
            c++;
        }
        if (isTrue)
        {
            this.Count--;
            this.OpenPositions++;
            this.data = newData;
        }
        return isTrue;
    }
    public int RemovePlayerByPosition(string position)
    {
        Player[] newData = new Player[this.data.Length];
        int count = 0;
        int c = 0;
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Position == position)
            {
                count++;
                continue;
            }
            newData[c] = this.data[i];
            c++;
        }
        this.Count -= count;
        this.OpenPositions+= count;
        this.data = newData;
        return count;
    }
    public Player RetirePlayer(string name) 
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Name == "name")
            {
                this.data[i].Retired = true;
                return this.data[i];
            }
        }
        return null;
    }
    public List<Player> AwardPlayers(int games) 
    {
        var list = new List<Player>();
        for (int i = 0; i < this.Count; i++)
        {
            if (this.data[i].Games >= games)
            {
                list.Add(this.data[i]);
            }
        }
        return list;
    }
    public string Report() 
    {
        string rep = $"Active players competing for Team {this.Name} from Group {this.Group}:";
        for (int i = 0; i < this.Count; i++)
        {
            if (!this.data[i].Retired)
            {
                rep += $"\n{this.data[i].Name}";
            }
        }
        return rep;
    }
    private void ExtendData()
    {
        Player[] newData = new Player[this.data.Length * 2];
        for (int i = 0; i < this.data.Length; i++)
        {
            newData[i] = this.data[i];
        }
        this.data = newData;
    }
}