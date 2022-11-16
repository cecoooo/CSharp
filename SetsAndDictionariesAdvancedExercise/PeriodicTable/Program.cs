using System;
using System.Collections.Generic;
using System.Linq;

namespace PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<string>();
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(" ");
                foreach (var item in line)
                    set.Add(item);
            }
            var list = set.ToList();
            list.Sort();
            Console.WriteLine(String.Join(" ", list));
        }
    }
}
