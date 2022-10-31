using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

public abstract class Shape
{
    public abstract double CalculatePerimeter();
    public abstract double CalculateArea();
    public virtual string Draw() 
    {
        return $"Perimeter: {this.CalculatePerimeter()}\n" +
            $"Area: {this.CalculateArea()}";
    }
}