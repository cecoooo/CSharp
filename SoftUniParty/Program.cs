using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests = new HashSet<string>();
            do
            {
                string person = Console.ReadLine();
                if (person == "PARTY") break;
                guests.Add(person);
            } while (true);
            do
            {
                string command = Console.ReadLine();
                if (command == "END") break;
                guests.Remove(command);
            } while (true);
            Console.WriteLine(guests.Count);
            foreach (var item in guests)
            {
                if (Char.IsDigit(item[0]))
                {
                    Console.WriteLine(item);
                    guests.Remove(item);
                }
            }
            foreach (var item in guests)
            {
                Console.WriteLine(item);
            }
        }
    }
}
