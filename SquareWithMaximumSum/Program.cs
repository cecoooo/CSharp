using System;
using System.Linq;

namespace SquareWithMaximumSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] len = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[,] arr = new int[len[0], len[1]];
            int max = int.MinValue;
            int startC = 0;
            int startR = 0;
            int lastC = 0;
            int lastR = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int[] ints = Console.ReadLine().Split(", ").Select(int.Parse).ToArray(); 
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    arr[i,j] = ints[j];
                }
            }
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int startIndexR = i;
                int lastIndexR = i + 1;
                if (lastIndexR == arr.GetLength(0)) break;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    int startIndexC = j;
                    int lastIndexC = j + 1;
                    if (lastIndexC == arr.GetLength(1)) break;
                    int[,] matrix = new int[2, 2] { 
                        { arr[startIndexR, startIndexC], arr[startIndexR, lastIndexC]},
                        { arr[lastIndexR, startIndexC], arr[lastIndexR, lastIndexC]}
                    };
                    int sum = 0;
                    foreach (var item in matrix)
                    {
                        sum += item;
                    }
                    if (sum > max)
                    {
                        max = sum;
                        startR = startIndexR;
                        lastC = lastIndexC;
                        startC = startIndexC;
                        lastR = lastIndexR;
                    }
                }
            }
            int[,] matrix1 = new int[2, 2] {
                        { arr[startR, startC], arr[startR, lastC]},
                        { arr[lastR, startC], arr[lastR, lastC]}
                    };
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(matrix1[i,j]+" ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(max);
        }
    }
}
