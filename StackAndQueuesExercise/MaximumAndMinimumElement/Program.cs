using System;
using System.Collections.Generic;
using System.Linq;

namespace MaximumAndMinimumElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                int[] coms = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                try
                {
                    switch (coms[0])
                    {
                        case 1: stack.Push(coms[1]); break;
                        case 2: stack.Pop(); break;
                        case 3: Console.WriteLine(stack.Max()); break;
                        case 4: Console.WriteLine(stack.Min()); break;
                    }
                }
                catch {
                    continue;
                }
            }
            Console.WriteLine(String.Join(", ", stack));
        }
    }
}
