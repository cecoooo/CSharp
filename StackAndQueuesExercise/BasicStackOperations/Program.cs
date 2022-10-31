using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicStackOperations
{
    class Program
    {
        static void Main()
        {
            int[] commands = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] stackArr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < stackArr.Length; i++)
                stack.Push(stackArr[i]);
            for (int i = 0; i < commands[1]; i++)
                stack.Pop();
            if (stack.Count == 0)
                Console.WriteLine(0);
            else if (stack.Contains(commands[2]))
                Console.WriteLine("true");
            else
                Console.WriteLine(stack.Min());
        }
    }
}