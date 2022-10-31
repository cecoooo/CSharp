using System;
using System.Linq;

namespace SortEvenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join(", ",
                Console.ReadLine().
                Split(", ").
                Select(int.Parse).
                ToList().
                OrderBy(x => x).
                Where(x => x % 2 == 0)));
        }
    }
}
