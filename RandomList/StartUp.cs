using System;

namespace CustomRandomList
{
    public class StartUp
    {
        static void Main()
        {
            RandomList list = new RandomList();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            Console.WriteLine(list.Return());
            Console.WriteLine();
            list.RemoveRan();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
