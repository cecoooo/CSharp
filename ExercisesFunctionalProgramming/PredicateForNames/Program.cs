using System;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(String.Join("\n",
                Console.ReadLine().
                Split().
                Where(x => x.Length <= n)));
        }
    }
}
