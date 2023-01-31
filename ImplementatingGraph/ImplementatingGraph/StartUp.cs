using System;

namespace ImplementatingGraph
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            DirectedGraph graph = new DirectedGraph(5);
            graph.CreateEdge(0, 3);
            graph.CreateEdge(1, 0);
            graph.CreateEdge(3, 4);
            graph.CreateEdge(2, 4);
            graph.CreateEdge(0, 3);
            graph.CreateEdge(0, 4);
            graph.CreateEdge(1, 2);
            graph.CreateEdge(1, 4);
            graph.CreateEdge(4, 4);
            graph.CreateEdge(4, 3);
            graph.PrintGraphConnections();
            graph.ReverseDirectedGraph();
            Console.WriteLine("--------------");
            graph.PrintGraphConnections();
        }
    }
}
