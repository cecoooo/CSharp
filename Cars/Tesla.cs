using System;
using System.Collections.Generic;
using System.Text;
using Cars;

public class Tesla : ICar, IElectricCar
{ 
    public int Battery { get; set; }
    public string Model { get ; set; }
    public string Color { get; set; }
    public Tesla() 
    {
    
    }
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Battery = battery; 
        this.Color = color; 
    }
    public string Start()
    {
        return "Engine start";
    }
    public string Stop()
    {
        return "Breaaak!";
    }
    public override string ToString()
    {
        return $"{this.Color} Tesla {this.Model} with {this.Battery} Batteries\n{this.Start()}\n{this.Stop()}";
    }
}