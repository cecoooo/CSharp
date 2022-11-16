using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();
            for (int i = 0; i < input[0]; i++)
            {
                int n = int.Parse(Console.ReadLine());
                set1.Add(n);
            }
            for (int i = 0; i < input[1]; i++)
            {
                int n = int.Parse(Console.ReadLine());
                set2.Add(n);
            }
            var list = set1.ToArray();
            var list1 = new List<int>();
            for (int i = 0; i < list.Length; i++)
            {
                if (set2.Contains(list[i]))
                    list1.Add(list[i]);
            }
            Console.WriteLine(String.Join(" ", list1));
        }
    }
}
