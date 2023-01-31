using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using ImplementatingGraph;

public class Tree
{
    private class Node
    {
        private int value;
        private List<Node> childs;
        private Node parrentNode;
        private List<Node> siblings;



        public Node(int value)
        {
            this.value = value;
            this.childs = new List<Node>();
        }

        public void AddChild(Node node)
        {
            this.childs.Add(node);
        }
    }
    private Node root;
    private int height;
    private List<Node> leafs;

    public Tree(int item)
    {

    }

}