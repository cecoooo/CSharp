using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    int amount = int.Parse(Console.ReadLine());
                    int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                    Queue<int> queue = new Queue<int>(arr);
                    int latest = 0;
                    Console.WriteLine(queue.Max());
                    while (amount > latest && queue.Count > 0)
                    {
                        latest = queue.Dequeue();
                        amount -= latest;
                    }
                    if (amount > latest)
                        Console.WriteLine("Orders complete");
                    else
                        Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
                    break;
                }

                catch
                {
                    continue;
                }
            }
        }
    }
}
