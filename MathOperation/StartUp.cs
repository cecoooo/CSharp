using System;

namespace Operations
{
    public class StartUp
    {
        static void Main()
        {
            MathOperations operations = new MathOperations();
            Console.WriteLine(operations.Add(2, 3));
            Console.WriteLine(operations.Add(2.0, 3.1, 4.9));
            Console.WriteLine(operations.Add(1m, 5m, 7.9m));
        }
    }
}
