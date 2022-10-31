using System;
using System.Collections.Generic;
using LinkedList;

namespace LinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var list = new OwnCollection();
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.Add(10);
            //Console.WriteLine(list.Count);
            list.RemoveAt(1);
            list.InsertAt(3, 18);
            //Console.WriteLine(list.Count);
            //Console.WriteLine(list[3]);
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
