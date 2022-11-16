    using System;
    using System.Collections.Generic;
    using System.Linq;

    namespace CountSymbols
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                var input = Console.ReadLine();
                var dict = new Dictionary<char, int>();
                for (int i = 0; i < input.Length; i++)
                {
                    if (dict.ContainsKey(input[i]))
                        dict[input[i]]++;
                    else
                        dict[input[i]] = 1; 
                }
                var dict1 = dict.OrderBy(x => x.Key);
                foreach (var item in dict1)
                {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
                }
            }
        }
    }
