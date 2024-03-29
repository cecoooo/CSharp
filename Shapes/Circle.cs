﻿using System;
using System.Collections.Generic;
using System.Text;
using Shapes;

public class Circle:Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }
    public Circle(double radius) 
    {
        this.radius = radius;
    }
    public override double CalculateArea()
    {
        return (radius * radius)*Math.PI;
    }
    public override double CalculatePerimeter()
    {
        return 2*Math.PI*radius;
    }
    public override string Draw()
    {
        return base.Draw();
    }
}