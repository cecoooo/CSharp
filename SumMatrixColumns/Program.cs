using System;
using System.Linq;

namespace SumMatrixColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] len = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] arr = new int[len[0], len[1]];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = row[j];
                }
            }
            for (int i = 0; i < arr.GetLength(1); i++)
            {
                int sum = 0;
                for (int j = 0; j < arr.GetLength(0); j++)
                {
                    sum += arr[j, i];
                }
                Console.WriteLine(sum);
            }

        }
    }
}
