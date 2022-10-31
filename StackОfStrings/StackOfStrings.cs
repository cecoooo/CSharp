using System;
using System.Collections.Generic;
using System.Text;
using CustomStack;

public class StackOfStrings:Stack<string>
{
    public bool IsEmpty()
    {
        if (this.Count == 0)
            return true;
        return false;
    }
    public Stack<string> AddRange() 
    {
        return this;
    }
}