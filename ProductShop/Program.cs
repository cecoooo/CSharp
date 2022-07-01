using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<Dictionary<string, double>>>();
            do
            {
                string[] command = Console.ReadLine().Split(", ");
                if (command[0] == "Revision") break;
                string shop = command[0];
                var list = new List<Dictionary<string, double>> { };
                var productPrice = new Dictionary<string, double> { { command[1], double.Parse(command[2]) }, };
                list.Add(productPrice);
                if (!dict.ContainsKey(shop)) dict.Add(shop, list);
                else dict[shop].Add(productPrice);
            } while (true);
            var dict1 = dict.OrderBy(x=>x.Key);
            foreach (var item in dict1)
            {
                Console.WriteLine(item.Key+"->");
                for (int i = 0; i < item.Value.Count; i++)
                {
                    foreach (var pair in item.Value[i])
                    {
                        Console.WriteLine($"Product: {pair.Key}, Price: {pair.Value}");
                    }
                }
            }
        }
    }
}
