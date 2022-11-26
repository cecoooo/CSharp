using System;
using System.Collections.Generic;
using System.Linq;

namespace FindEvensOrOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, List<int>> toArr = (x, y) => {
                List<int> arr = new List<int>();
                for (int i = x; i <= y; i++)
                {
                    arr.Add(i);
                }
                return arr;
            };
            int[] range = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            string command = Console.ReadLine();
            Predicate<int> isOddEven = x =>
            {
                if (command == "even")
                {
                    if (x % 2 == 0)
                        return true;
                    return false;
                }
                else 
                {
                    if (x % 2 != 0)
                        return true;
                    return false;
                }
            };
            Console.WriteLine(String.Join(" ",
                toArr(range[0], range[1]).
                Where(x => isOddEven(x))));
        }
    }
}
