using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = arr[j];
                }
            }
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i==j)
                        sum1 += matrix[i,j];
                    if(i+j==n-1)
                        sum2+=matrix[i,j];
                }
            }
            Console.WriteLine(Math.Abs(sum1-sum2));
        }
    }
}
