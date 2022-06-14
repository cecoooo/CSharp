using System;
using System.Collections.Generic;

namespace ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> cars = new HashSet<string> { };
            do
            {
                string[] command = Console.ReadLine().Split(", ");
                if (command[0] == "END") break;
                switch (command[0])
                {
                    case "IN": cars.Add(command[1]); break;
                    case "OUT": cars.Remove(command[1]); break;
                }
            } while (true);
            if (cars.Count > 0) Console.WriteLine(String.Join("\n", cars));
            else Console.WriteLine("Parking Lot is Empty");
        }
    }
}
