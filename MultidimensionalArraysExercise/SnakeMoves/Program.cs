using System;
using System.Dynamic;
using System.Linq;

namespace SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dim = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            string text = Console.ReadLine();
            char[,] matrix = new char[dim[0], dim[1]];
            int c = 0;
            for (int i = 0; i < dim[0]; i++)
            {
                for (int j = 0; j < dim[1]; j++)
                {
                    matrix[i, j] = text[c];
                    c++;
                    if (c == text.Length)
                        c = 0;
                }
                i++;
                if (i == dim[0])
                    break;
                for (int j = dim[1]-1; j >= 0; j--)
                {
                    matrix[i, j] = text[c];
                    c++;
                    if (c == text.Length)
                        c = 0;
                }
            }
            for (int i = 0; i < dim[0]; i++)
            {
                for (int j = 0; j < dim[1]; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
