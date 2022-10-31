using System;
using System.Collections.Generic;
using System.Text;
using Animals;

public class Animal
{
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    private string favouriteFood;

    public string FavouriteFood
    {
        get { return favouriteFood; }
        set { favouriteFood = value; }
    }
    public virtual string ExplainSelf() 
    {
        return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
    }
}