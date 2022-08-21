using CarManufacturer;
public class Tire
{
    private int year;

    public int Year
    {
        get { return year; }
        set { year = value; }
    }
    private double pressure;

    public double Pressure
    {
        get { return pressure; }
        set { pressure = value; }
    }
    public Tire(int year, double pressure) 
    {
        this.year = year;
        this.pressure = pressure;
    }
}

