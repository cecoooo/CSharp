using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var dict = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var innerDict1 = new Dictionary<string, int>();
                string buff = String.Empty;
                string text = String.Empty;
                bool isFirst = true;
                for (int j = 0; j < input.Length+1; j++)
                {
                    if (j == input.Length) {
                        AddToDict(innerDict1, buff);
                        break;
                    }
                    if (Char.IsLetter(input[j]) || input[j] == '-')
                        buff += input[j];
                    else
                    {
                        if (isFirst)
                        {
                            text = buff;
                            isFirst = false;
                        }
                        else
                            AddToDict(innerDict1, buff);
                        buff = String.Empty;
                    }
                }
                var innerDict = innerDict1.Where(x => x.Key != "" && x.Key != "-").ToDictionary(x => x.Key, x => x.Value);
                if (!dict.ContainsKey(text))
                {
                    dict.Add(text, innerDict);
                }
                else 
                {
                    foreach (var item in innerDict)
                        AddToInnerDict(dict[text], item.Key, item.Value);
                }
            }
            var lookingFor = Console.ReadLine().Split(" ");
            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var text in item.Value)
                {
                    Console.Write($"* {text.Key} - {text.Value}");
                    if (lookingFor[0] == item.Key && lookingFor[1] == text.Key)
                        Console.Write(" (found!)\n");
                    else
                        Console.WriteLine();
                }
            }
        }
        static void AddToDict(Dictionary<string, int> innerDict, string buff) {
            if (innerDict.ContainsKey(buff))
                innerDict[buff]++;
            else
                innerDict.Add(buff, 1);
        }
        static void AddToInnerDict(Dictionary<string, int> innerDict, string buff, int value)
        {
            if (innerDict.ContainsKey(buff))
                innerDict[buff]+=value;
            else
                innerDict.Add(buff, 1);
        }
    }
}
