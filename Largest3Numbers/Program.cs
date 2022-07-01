using System;
using System.Collections.Generic;
using System.Linq;

namespace Largest3Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            list.Sort();
            list.Reverse();
            int n = list.Count;
            if (list.Count>3)
            {
                n = 3;
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write(list[i]+" ");
            }
        }
    }
}
