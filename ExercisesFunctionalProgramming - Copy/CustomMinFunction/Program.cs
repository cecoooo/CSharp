using System;
using System.Linq;

namespace CustomMinFunction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> min = (arr) => 
            {
                int min = int.MaxValue;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < min)
                        min = arr[i];
                }
                return min;
            };
            var list = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine(min(list));
        }
    }
}
