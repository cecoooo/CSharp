using System;
using System.Linq;

namespace SumMatrixElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] len = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] arr = new int[len[0], len[1]];
            int r=0;
            int c=0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = row[j];
                    c++;
                }
                r++;
            }
            int sum = 0;
            foreach (var item in arr)
            {
                sum += item;
            }
            Console.WriteLine(r);
            Console.WriteLine(c/r);
            Console.WriteLine(sum);
        }
    }
}
