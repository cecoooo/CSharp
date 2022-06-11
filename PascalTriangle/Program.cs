using System;

namespace PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            if (n < 1) return;
            long[][] jagged = new long[n][];
            long[] first = new long[1] { 1 };
            jagged[0] = first;
            for (int i = 1; i < n; i++)
            {
                long[] arr = new long[i + 1];
                for (int j = 0; j < arr.Length; j++)
                {
                    try
                    {
                        arr[j] += jagged[i - 1][j - 1];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arr[j] += 0;    
                    }
                    try
                    {
                        arr[j] += jagged[i - 1][j];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        arr[j] += 0;
                    }
                }
                jagged[i] = arr;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
    }
}
