using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ActionPoint1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);
            Console.ReadLine().Split(" ").ToList().ForEach(print);
        }
    }
}
