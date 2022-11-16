using System;
using System.Collections.Generic;

namespace EvenTimes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var set = new HashSet<int>();
            int res = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (set.Contains(num))
                    res = num;
                set.Add(num);
            }
            Console.WriteLine(res);
        }
    }
}
