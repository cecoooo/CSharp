using System;
using System.Linq;

namespace _02Help_A_Mole
{
    public class Program
    {
        public static int count = 0;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[5,5];
            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i,j] = line[j];
                }
            }
            string command = Console.ReadLine();
            while (command != "End")
            {
                switch (command)
                {
                    case "right": MoveRight(matrix, n); break;
                    case "down": MoveDown(matrix, n); break;
                    case "left": MoveLeft(matrix, n); break;
                    case "up": MoveUp(matrix, n); break;
                }
                command = Console.ReadLine();
            }
            if (count < 25)
            {
                Console.WriteLine("Too bad! The Mole lost this battle!\n" +
                    $"The Mole managed to survive with a total of {count} points.");
                for(int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(matrix[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Yay! The Mole survived another game!\n" +
                    $"The Mole lost the game with a total of {count} points.");
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write(matrix[i,j]);
                    }
                    Console.WriteLine();
                }
            }
        }
        static void MoveRight(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 'M')
                    {
                        if (j == matrix.Length-1)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            return;
                        }
                        matrix[i,j] = '-';
                        if (Char.IsDigit(matrix[i,j+1]))
                        {
                            count += int.Parse(matrix[i,j+1].ToString());
                        }
                        matrix[i,j + 1] = 'M';
                        return;                            
                    }
                }
            }
        }
        static void MoveDown(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 'M')
                    {
                        if (i == 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            return;
                        }
                        matrix[i,j] = '-';
                        if (Char.IsDigit(matrix[i-1,j]))
                        {
                            count += int.Parse(matrix[i - 1,j].ToString());
                        }
                        matrix[i-1,j] = 'M';
                        return;
                    }
                }
            }
        }
        static void MoveLeft(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 'M')
                    {
                        if (j == 0)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            return;
                        }
                        matrix[i,j] = '-';
                        if (Char.IsDigit(matrix[i,j - 1]))
                        {
                            count += int.Parse(matrix[i,j - 1].ToString());
                        }
                        matrix[i,j - 1] = 'M';
                        return;
                    }
                }
            }
        }
        static void MoveUp(char[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i,j] == 'M')
                    {
                        if (i == matrix.Length - 1)
                        {
                            Console.WriteLine("Don't try to escape the playing field!");
                            return;
                        }
                        matrix[i,j] = '-';
                        if (Char.IsDigit(matrix[i + 1,j]))
                        {
                            count += int.Parse(matrix[i + 1,j].ToString());
                        }
                        matrix[i + 1,j] = 'M';
                        return;
                    }
                }
            }
        }
    }
}
