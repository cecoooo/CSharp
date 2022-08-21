using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StartUp
    {
        static void Main() 
        {
            StackOfStrings stack = new StackOfStrings();
            stack.Push("pi6ka");
            Console.WriteLine(stack.IsEmpty());
        }
    }
}
