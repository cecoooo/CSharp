using System;
using System.Linq;

namespace PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] arr = new int[n,n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] row = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i, j] = row[j]; 
                }
            }
            int sum = 0;    
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (i == j) sum += arr[i, j];
                }
            }
            Console.WriteLine(sum);
        }
    }
}