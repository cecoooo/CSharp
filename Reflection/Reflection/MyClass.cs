using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using Reflection;
public class MyClass : IComparable
{
    private int age = 0;
    public string name = "no data";
    private string proffesion = "no data";
    private static string egn;

    [Flags]
    public enum DaysOfWeek
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
    public MyClass()
    {

    }
    private MyClass(string egn)
    {

    }
    static MyClass()
    {

    }
    public MyClass(int age, string name)
    {
        this.age = age;
        this.name = name;
    }

    public string Proffesion
    {
        get { return proffesion; }
        set { proffesion = value; }
    }

    CustomAttribute Custom = new CustomAttribute("");

    [Custom("")]
    private void PrintHelloWorld()
    {
        Console.WriteLine("Hello World!");
    }

    public override string ToString()
    {
        return $"name: {this.name}\n" +
            $"age: {this.age}\n" +
            $"proffesion: {this.proffesion}";
    }

    [Obsolete("This method is depricated, use Method2() instead.")]
    public void Method1()
    {

    }
    [Obsolete("This method is even worse than Method1()...", true)]
    public void Method2()
    {

    }

    public int CompareTo(object obj)
    {
        throw new NotImplementedException();
    }
}