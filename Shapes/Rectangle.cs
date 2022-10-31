using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

public class Rectangle:Shape
{
    private double height;

    public double Height
    {
        get { return height; }
        set { height = value; }
    }
    private double weight;

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }
    public Rectangle(double height, double weight) 
    {
        this.height = height;
        this.weight = weight;
    }
    public override double CalculatePerimeter() 
    {
        return 2 * (this.height + this.weight);
    }
    public override double CalculateArea()
    {
        return height * weight;
    }
}