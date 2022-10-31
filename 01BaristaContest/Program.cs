using System;
using System.Linq;
using System.Collections.Generic;

namespace _01BaristaContest
{
    public class Program
    {
        static void Main()
        {
            int[] coffee = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] milk = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var drinks = new Dictionary<string, int>();
            var queueCof = ToQueue(coffee);
            var stackMilk = ToStack(milk);
            while (queueCof.Count != 0 && stackMilk.Count != 0)
            {
                int sum = stackMilk.Peek() + queueCof.Peek();
                string drink = string.Empty;
                var isTrue = false;
                switch (sum)
                {
                    case 50: drink = "Cortado"; break;
                    case 75: drink = "Espresso"; break;
                    case 100: drink = "Capuccino"; break;
                    case 150: drink = "Americano"; break;
                    case 200: drink = "Latte"; break;
                    default: isTrue = true; break;
                }
                queueCof.Dequeue();
                if (isTrue) 
                { 
                    stackMilk = DecreaseCoffee(stackMilk);
                    continue;
                }
                else
                    stackMilk.Pop();
                if (drinks.ContainsKey(drink))
                    drinks[drink]++;
                else
                    drinks[drink] = 1;
            }
            var newData = drinks.OrderBy(x => x.Value).ThenByDescending(x => x.Key);
            if (queueCof.Count == 0 && stackMilk.Count ==0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!\n" +
                    "Coffee left: none\n" +
                    "Milk left: none");
                foreach (var item in newData)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                switch (queueCof.Count)
                {
                    case 0: Console.WriteLine("Coffee left: none"); break;
                    default: Console.WriteLine($"Coffee left: {string.Join(", ", queueCof)}"); break;
                }
                switch (stackMilk.Count)
                {
                    case 0: Console.WriteLine("Milk left: none"); break;
                    default: Console.WriteLine($"Milk left: {string.Join(", ", stackMilk)}"); break;
                }
                foreach (var item in newData)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
        static Stack<int> ToStack(int[] arr)
        { 
            var stack = new Stack<int>();
            foreach (int item in arr) 
                stack.Push(item);
            return stack;
        }
        static Queue<int> ToQueue(int[] arr)
        {
            var queue = new Queue<int>();
            foreach (int item in arr)
                queue.Enqueue(item);
            return queue;
        }
        static Stack<int> DecreaseCoffee(Stack<int> coffee) 
        {
            var arr = coffee.ToArray();
            arr[0] -= 5;
            int[] rev = new int[arr.Length];
            int c = 0;
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                rev[c] = arr[i];
                c++;
            }
            return ToStack(rev);
        }
    }
}
