using System;
using System.Collections.Generic;

namespace CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string,Dictionary<string, List<string>>>();
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(' ');
                var city = new List<string> {};
                var country = new Dictionary<string, List<string>> {};
                if (!dict.ContainsKey(command[0]))
                {
                    city.Add(command[2]);
                    country.Add(command[1], city);
                    //if (dict[command[0]].ContainsKey(command[1])) continue;
                    //if (dict[command[0]][command[1]].Contains(command[2])) continue;
                    dict.Add(command[0], country);
                    continue;
                }
                if (!dict[command[0]].ContainsKey(command[1]))
                {
                    city.Add(command[2]);
                    //if (dict[command[0]][command[1]].Contains(command[2])) continue;
                    dict[command[0]].Add(command[1], city);
                }
                if (!dict[command[0]][command[1]].Contains(command[2])) dict[command[0]][command[1]].Add(command[2]); 
            }
            foreach (var item in dict)
            {
                Console.WriteLine(item.Key+":");
                foreach (var pair in item.Value)
                {
                    Console.WriteLine($"\t{pair.Key} -> {string.Join(", ", pair.Value)}");
                }
            }
        }
    }
}
