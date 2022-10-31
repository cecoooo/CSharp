using System;
using System.Collections.Generic;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //Box<int> nums = new Box<int> { };
            //nums.Add(1);
            //nums.Add(2);
            //nums.Add(3);
            //nums.Add(4);
            //nums.Add(5);
            //Console.WriteLine(nums.Count);
            //nums.Remove();
            //nums.Remove();
            //Console.WriteLine(nums.Count);

            Box<int> box = new Box<int>(); 
            box.Add(1); box.Add(2);
            box.Add(3); 
            Console.WriteLine(box.Count);
            box.Add(4);
            box.Add(5); 
            Console.WriteLine(box.Count);
            box.Remove();
            Console.WriteLine(box.Count);
        }
    }
}
