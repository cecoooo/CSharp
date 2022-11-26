using System;
using System.Linq;
using System.Collections.Generic;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine().Split().Select(int.Parse).ToList();
            var num = int.Parse(Console.ReadLine());
            Predicate<int> isDivisible = x =>
            {
                if (x % num == 0)
                    return false;
                return true;
            };
            Console.WriteLine(String.Join(" ", list.Where(x => isDivisible(x)).ToList().OrderByDescending(x => x)));
        }
    }
}
