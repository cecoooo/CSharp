using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = Console.ReadLine().Split().Select(double.Parse).ToArray();
            Predicate<int> isDivisible = x => {
                bool isDiv = true;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (x % arr[i] != 0)
                        isDiv = false;
                }
                return isDiv;
            };
            var list = new List<int>();
            for (int i = 1; i <= n; i++)
            {
                list.Add(i);
            }
            Console.WriteLine(
                String.Join(" ",
                list.
                Where(x => isDivisible(x))));
        }
    }
}
