using System;
using System.Linq;

namespace AddVAT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join("\n",
                Console.ReadLine().
                Split(", ").
                Select(double.Parse).
                Select(x => x*1.2).
                Select(x => $"{x:f2}").
                ToArray()));
        }
        
    }
}
