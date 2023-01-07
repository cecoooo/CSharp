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

    public bool IsBipartiteGraph() 
    {
        bool isBipartite = true;
        List<int> redGroup = new List<int>();
        List<int> blueGroup = new List<int>();
        List<int> stillChecked = new List<int>();
        int element = -1;

        for (int i = 0; i < this.arr.Length; i++)
        {
            bool breakOrNot = false;
            for (int j = 0; j < this.arr.Length; j++)
            {
                if (this.arr[i][j] != null)
                {
                    breakOrNot = true;
                    element = i;
                    break;
                }
            }
            if (breakOrNot)
                break;
        }
        List<int> curruntList = new List<int>();
        int offset = -1;
        while (stillChecked.Count != this.arr.Length && element > -1) {
            element=curruntList[offset];
            curruntList = stillChecked.Count % 2 == 0 ? redGroup : blueGroup;
            if (!curruntList.Contains(element)) curruntList.Add(element);
            else { isBipartite = false; break; }
            if (stillChecked.Contains(element)) continue;
            else stillChecked.Add(element);
            for (int i = 0; i < this.arr.Length; i++)
                if (this.arr[element][i] != null)
                    curruntList.Add(i);
            offset+=


        }
        return isBipartite;
    }
}