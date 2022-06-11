using System;

namespace SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] arr = new char[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                string str = Console.ReadLine(); 
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = str[j];
                }
            }
            char sym = Console.ReadLine()[0];
            int c = 0;
            int r = 0;
            bool t = false;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == sym) 
                    {
                        r = i;
                        c = j;
                        t = true;
                        break;
                    }
                }
                if (t) break;
            }
            if (t)
            {
                Console.WriteLine($"({r}, {c})");
            }
            else
            {
                Console.WriteLine($"{sym} does not occur in the matrix");
            }
        }
    }
}
