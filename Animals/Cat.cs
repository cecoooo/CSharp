using System;
using System.Collections.Generic;
using System.Text;
using Animals;

public class Cat: Animal
{
    public override string ExplainSelf()
    {
        return base.ExplainSelf() + "\nMEEOW";
    }
    public Cat(string name, string favFood)
    {
        this.Name = name;
        this.FavouriteFood = favFood;
    }
}