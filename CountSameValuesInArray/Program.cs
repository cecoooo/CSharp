using System;
using System.Collections.Generic;
using System.Linq;

namespace CountSameValuesInArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            var dict = new Dictionary<double, int> { };
            for (int i = 0; i < arr.Length; i++)
            {
                if (!dict.ContainsKey(arr[i]))
                {
                    dict[arr[i]] = 1;
                }
                else
                {
                    dict[arr[i]]++;
                }
            }
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
