using CarManufacturer;

public class Engine
{
    int horsePower;
    double cubicCapacity;
    public int HorsePower
    {
        get { return horsePower; }
        set { horsePower = value; }
    }
    public double CubicCapacity
    {
        get { return cubicCapacity; }
        set { cubicCapacity = value; }
    }
    public Engine(int horsePower, double cubicCapacity)
    { 
       this.horsePower = horsePower;
       this.cubicCapacity = cubicCapacity;
    }
}
