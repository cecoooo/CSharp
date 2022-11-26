using System;
using System.Linq;
using System.Collections.Generic;

namespace KnightsOfHonor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> changeAndPrint = x => Console.WriteLine("Sir " + x);
            Console.ReadLine().Split(" ").ToList().ForEach(changeAndPrint);
        }
    }
}
