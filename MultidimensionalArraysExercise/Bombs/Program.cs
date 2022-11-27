using System;
using System.Collections.Generic;
using System.Linq;

namespace RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static bool isWin = false;
        static int row = 0;
        static int col = 0;
        static List<string> indexes = new List<string>();
        static List<string> currIndexes = new List<string>();
        static bool playerIsDead = false;
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            char[,] matrix = new char[size[0], size[1]];
            for (int i = 0; i < size[0]; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < size[1]; j++)
                {
                    matrix[i, j] = line[j];
                }
            }
            string directions = Console.ReadLine();
            for (int k = 0; k < directions.Length; k++)
            {
                for (int i = 0; i < size[0]; i++)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        if (matrix[i, j] == 'B' && !indexes.Contains(i + "" + j)) 
                        {
                            indexes.Add(i + "" + j);
                            currIndexes.Add(i + "" + j);
                        }
                    }
                }
                for (int i = 0; i < size[0]; i++)
                {
                    bool isBreak = false;
                    for (int j = 0; j < size[1]; j++)
                    {
                        if (matrix[i, j] == 'P')
                        {
                            move(matrix, i, j, directions[k]);
                            isBreak = true;
                            break;
                        }
                    }
                    if (isBreak)
                        break;
                }
                for (int i = 0; i < size[0]; i++)
                {
                    for (int j = 0; j < size[1]; j++)
                    {
                        if (matrix[i,j] == 'B') {
                            spread(matrix, i, j);
                        }
                    }
                }
                if (playerIsDead)
                    break;
                currIndexes.Clear();
            }
            for (int i = 0; i < size[0]; i++)
            {
                for (int j = 0; j < size[1]; j++)
                {
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            if (isWin)
                Console.WriteLine($"won: {row} {col}");
            else
                Console.WriteLine($"dead: {row} {col}");
        }
        static void spread(char[,] matrix, int i, int j) 
        {
            if (i != 0 && currIndexes.Contains(i + "" + j))
            {
                if (matrix[i - 1, j] == 'P')
                {
                    playerIsDead = true;
                    row = i;
                    col = j;
                }
                matrix[i - 1, j] = 'B';
            }
            if (j != 0 && currIndexes.Contains(i + "" + j))
            {
                if (matrix[i, j - 1] == 'P')
                {
                    playerIsDead = true;
                    row = i;
                    col = j-1;
                }
                matrix[i, j - 1] = 'B';
            }
            if (i != matrix.GetLength(0) - 1 && currIndexes.Contains(i + "" + j))
            {
                if (matrix[i + 1, j] == 'P')
                {
                    row = i+1;
                    col = j;
                    playerIsDead = true;
                }
                matrix[i + 1, j] = 'B';
            }
            if (j != matrix.GetLength(1) - 1 && currIndexes.Contains(i + "" + j))
            {
                if (matrix[i, j + 1] == 'P')
                {
                    row = i;
                    col = j+1;
                    playerIsDead = true;
                }
                matrix[i, j + 1] = 'B';
            }
        }
        static void move(char[,] matrix, int i, int j, char dir)
        {
            switch (dir)
            {
                case 'D':
                    matrix[i, j] = '.';
                    if (i != matrix.GetLength(0) - 1)
                    {
                        if (matrix[i + 1, j] == 'B')
                        {
                            row = i+1;
                            col = j;
                            playerIsDead = true;    
                            return;
                        }
                        matrix[i + 1, j] = 'P';
                    }
                    else
                    {
                        isWin = true;
                        row = i;
                        col = j;
                    }
                    break;
                case 'U':
                    matrix[i, j] = '.';
                    if (i != 0)
                    {
                        if (matrix[i - 1, j] == 'B')
                        {
                            row = i-1;
                            col = j;
                            playerIsDead = true;
                            return;
                        }
                        matrix[i - 1, j] = 'P';
                    }
                    else
                    {
                        isWin = true;
                        row = i;
                        col = j;
                    }
                    break;
                case 'L':
                    matrix[i, j] = '.';
                    if (j != 0)
                    {
                        if (matrix[i, j-1] == 'B')
                        {
                            row = i;
                            col = j-1;
                            playerIsDead = true;
                            return;
                        }
                        matrix[i, j-1] = 'P';
                    }
                    else
                    {
                        isWin = true;
                        row = i;
                        col = j;
                    }
                    break;
                case 'R':
                    matrix[i, j] = '.';
                    if (j != matrix.GetLength(1) - 1)
                    {
                        if (matrix[i, j + 1] == 'B')
                        {
                            row = i;
                            col = j+1;
                            playerIsDead = true;
                            return;
                        }
                        matrix[i, j + 1] = 'P';
                    }
                    else
                    {
                        isWin = true;
                        row = i;
                        col = j;
                    }
                    break;
            }
        }
    }
}