using System;
using System.Collections.Generic;
using System.Text;
using Animals;

public class Dog: Animal
{
    public override string ExplainSelf() 
    {
        return base.ExplainSelf() + "\nDJAAF";
    }
    public Dog(string name, string favFood) 
    {
        this.Name = name;
        this.FavouriteFood = favFood;
    }
}