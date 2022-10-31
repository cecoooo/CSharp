using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicQueueOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] com = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] ints = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < com[0]; i++)
                queue.Enqueue(ints[i]);
            for (int i = 0; i < com[1]; i++)
                queue.Dequeue();
            if (queue.Count == 0)
                Console.WriteLine(0);
            else if (queue.Contains(com[2]))
                Console.WriteLine("true");
            else
                Console.WriteLine(queue.Min());
        }
    }
}
