using System;
using CarManufacturer;

class Car
{
    private string make;

    public string Make
    {
        get { return make; }
        set { make = value; }
    }
    private string model;

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
    private int year;

    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    private double fuelQuantity;

    public double FuelQuantity
    {
        get { return fuelQuantity; }
        set { fuelQuantity = value; }
    }
    private double fuelConsumption;

    public double FuelConsumption
    {
        get { return fuelConsumption; }
        set { fuelConsumption = value; }
    }

    private Engine engine;
    public Engine Engine 
    {
        get { return engine; }
        set { engine = value; }
    }

    private Tire[] tires;
    public Tire[] Tires 
    {
        get { return tires; }
        set { tires = value; }
    }

    public void Drive(double distance) 
    {
        if (fuelQuantity - distance * fuelConsumption >= 0 )
        {
            fuelQuantity -= distance * fuelConsumption;
        }
        else
        {
            Console.WriteLine("Not enough fuel to perform this trip!");
        }
    }
    public string WhoAmI() 
    {
        return $"Make: {this.Make}" +
            $"\nModel: { this.Model}" +
            $"\nYear: { this.Year}" +
            $"\nFuel: { this.FuelQuantity:F2}";
    }

    public Car()
    {
        Make = "VW";
        Model = "Golf";
        Year = 2025;
        FuelQuantity = 200.0;
        FuelConsumption = 10.0;
    }
    public Car(string make, string model, int year)
        : this()
    {
        this.Make = make;
        this.Model = model;
        this.Year = year;
    }
    public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
        : this(make, model, year)
    {
        this.FuelConsumption = fuelConsumption;
        this.FuelQuantity = fuelQuantity;
    }
    public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
    :this( make, model, year, fuelQuantity, fuelConsumption)
    {
        this.engine = engine;
        this.tires = tires; 
    }
}