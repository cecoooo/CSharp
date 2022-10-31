using System;
using System.Linq;

namespace CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(String.Join("\n",
                Console.ReadLine().
                Split(' ').
                Where(x => Char.IsUpper(x[0]))));
        }
    }
}
