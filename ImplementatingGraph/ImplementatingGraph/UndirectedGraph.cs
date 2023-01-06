using System;
using System.Collections.Generic;
using System.Text;
using ImplementatingGraph;


// Implemented with Matrix
public class UndirectedGraph<T>
{
    private T[][] arr = null;
    public int countOfElements { get; private set; }

    public UndirectedGraph(int v)
    {
        this.countOfElements = v;
        arr = new T[v][];
        for (int i = 0; i < v; i++)
            this.arr[i] = new T[this.countOfElements];
    }

    public void AddNode(int u, int v, T value)
    {
        arr[u - 1][v - 1] = value;
        arr[v - 1][u - 1] = value;
    }

    public void PrintGraph()
    {
        for (int i = 0; i < this.countOfElements; i++)
        {
            for (int j = 0; j < this.countOfElements; j++)
            {
                if (i != j)
                    Console.WriteLine($"Path between Node {i + 1} & Node {j + 1} - {arr[i][j]}");
            }
        }
    }
}