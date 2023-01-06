using System;
using System.Collections.Generic;
using System.Text;
using ImplementatingGraph;


// Implemented with Adcacency List
public class DirectedGraph
{
    List<List<int>> list;
    int countIOfNodes;

    public DirectedGraph(int v)
    {
        this.countIOfNodes = v;
        list = new List<List<int>>();
        for (int i = 0; i < v; i++)
        {
            list.Add(new List<int>());
        }
    }

    public void CreateEdge(int v, int u)
    {
        if (v != u && !list[v].Contains(u))
            list[v].Add(u);
    }

    public void PrintGraphConnections()
    {
        for (int i = 0; i < this.list.Count; i++)
        {
            Console.Write($"Node {i} connected to: ");
            for (int j = 0; j < this.list[i].Count; j++)
            {
                Console.Write(list[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}