using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = intParse(Console.ReadLine());
            var pairs = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                string[] pair = Console.ReadLine().Split(", ");
                pairs[pair[0]] = intParse(pair[1]);
            }
            string command = Console.ReadLine();
            int age = intParse(Console.ReadLine());
            string[] nameAge = Console.ReadLine().Split(' ');
            switch (nameAge.Length)
            {
                case 1:
                    switch (nameAge[0])
                    {
                        case "name":
                            switch (command)
                            {
                                case "older":
                                    Console.WriteLine(  
                                        String.Join("\n", pairs.
                                        Where(x => x.Value >= age).
                                        Select(x => x.Key))); 
                                    break;
                                case "younger":
                                    Console.WriteLine(
                                        String.Join("\n", pairs.
                                        Where(x => x.Value < age).
                                        Select(x => x.Key))); 
                                    break;
                            }
                            break;
                        case "age":
                            switch (command)
                            {
                                case "older":
                                    Console.WriteLine(
                                        String.Join("\n", pairs.
                                        Where(x => x.Value >= age).
                                        Select(x => x.Value)));
                                    break;
                                case "younger":
                                    Console.WriteLine(
                                        String.Join("\n", pairs.
                                        Where(x => x.Value < age).
                                        Select(x => x.Value)));
                                    break;
                            }
                            break;
                    }
                    break;
                case 2:
                    switch (command)
                    {
                        case "older":
                            Console.WriteLine(
                                        String.Join("\n", pairs.
                                        Where(x => x.Value >= age).
                                        Select(x => $"{x.Key} - {x.Value}"))); 
                            break;
                        case "younger":
                            Console.WriteLine(
                                        String.Join("\n", pairs.
                                        Where(x => x.Value > age).
                                        Select(x => $"{x.Key} - {x.Value}")));
                            break;
                    }
                    break;
            }
        }
        static int intParse(string text)
        {
            Func<char, int> toInt = x => x - '0';
            int sum = 0;
            for (int i = 0; i < text.Length; i++)
            {
                sum *= 10;
                int num = toInt(text[i]);
                sum += num;
            }
            return sum;
        }
    }
}