using System;
using System.Linq;

namespace Jagged_ArrayModification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());   
            int[][] jagged = new int[n][];
            for (int i = 0; i < n; i++)
            {
                int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                jagged[i] = arr;
            }
            bool t = false;
            do
            {
                string[] command = Console.ReadLine().Split(" ");
                switch (command[0])
                {
                    case "END": t = true; break;
                    case "Add": int r = int.Parse(command[1]);
                        int c = int.Parse(command[2]);
                        int num = int.Parse(command[3]);
                        Add(jagged, r, c, num); break;
                    case "Subtract":
                        int r1 = int.Parse(command[1]);
                        int c1 = int.Parse(command[2]);
                        int num1 = int.Parse(command[3]);
                        Subtract(jagged, r1, c1, num1); break;    
                }
                if (t) break;
            } while (true);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < jagged[i].Length; j++)
                {
                    Console.Write(jagged[i][j]+" ");
                }
                Console.WriteLine();
            }
        }
        static void Add(int[][] arr, int r, int c, int num)
        {
            try
            {
                arr[r][c] += num;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid coordinates");
                return;
            }
        }
        static void Subtract(int[][] arr, int r, int c, int num)
        {
            try
            {
                arr[r][c] -= num;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid coordinates");
                return;
            }
        }
    }
}
