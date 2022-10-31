using System;
using System.Collections.Generic;
using System.Text;
using CustomRandomList;

public class RandomList:List<string>
{
    public string Return() 
    {
        Random rnd = new Random();
        int index = rnd.Next(0, this.Count-1);
        return this[index];
    }
    public void RemoveRan() 
    {
        Random rnd = new Random();
        int num = rnd.Next(0, this.Count-1);
        this.RemoveAt(num);
    }
}

