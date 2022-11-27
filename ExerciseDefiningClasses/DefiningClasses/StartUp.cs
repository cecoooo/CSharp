using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // 3ex.
            //int n = int.Parse(Console.ReadLine());
            //Family family = new Family();
            //for (int i = 0; i < n; i++)
            //{
            //    string[] input = Console.ReadLine().Split();
            //    Person person = new Person(input[0], int.Parse(input[1]));
            //    family.AddMember(person);
            //}
            //Console.WriteLine(family.GetOldestMember().Name + " " + family.GetOldestMember().Age);

            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));
                family.AddMember(person);
            }
            List<Person> oldestThan30 = new List<Person>();
            foreach (var item in family)
            {
                if (item.Age > 30) 
                {
                    oldestThan30.Add(item);
                }
            }
            oldestThan30.Sort();
            foreach (var item in oldestThan30)
            {
                Console.WriteLine($"{item.Name} - {item.Age}");
            }
        }
    }
}
