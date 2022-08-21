using System;
using System.Linq;

namespace SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            Console.WriteLine(arr.Length+"\n"+arr.Sum());
        }
    }
}
