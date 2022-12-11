using System;

namespace ImplementingLinkedList
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Func<int, int> func = x => x + 1;
            CustomDoublyLinkedList list = new CustomDoublyLinkedList();
            list.AddFirst(5);
            list.AddFirst(6);
            list.AddLast(7);
            list.AddFirst(51);
            list.AddFirst(62);
            list.AddLast(73);
            Console.WriteLine(list.RemoveLast()); // 73
            Console.WriteLine(list.RemoveFirst()); // 62
            list.ForEach(func);
            var arr = list.ToArray();
            foreach (var item in arr)
            {
                Console.Write(item + " "); // 52 7 6 8 
            }
        }
    }
}
