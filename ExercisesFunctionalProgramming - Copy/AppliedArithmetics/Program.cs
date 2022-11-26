using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = String.Empty;
            var list = Console.ReadLine().Split().Select(int.Parse).ToList();
            Func<int, int> add = n => n +=1;
            Func<int, int> subtract = n => n -= 1;
            Func<int, int> mul = n => n *= 2 ;
            Action<List<int>> print = n => Console.WriteLine(String.Join(" ", n));
            while (command != "end")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "add": list = list.Select(x => add(x)).ToList(); break;
                    case "multiply": list = list.Select(x => mul(x)).ToList(); break;
                    case "subtract": list = list.Select(x => subtract(x)).ToList(); break;
                    case "print": print(list); break;
                }
            }
        }
    }
}
