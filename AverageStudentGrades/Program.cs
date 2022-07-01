using System;
using System.Collections.Generic;

namespace AverageStudentGrades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dict = new Dictionary<string, List<decimal>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split(' ');
                decimal grade = decimal.Parse(arr[1]);
                if (!dict.ContainsKey(arr[0]))
                {
                    dict[arr[0]] = new List<decimal> { grade };
                }
                else
                {
                    dict[arr[0]].Add(grade);
                }
            }
            foreach (var item in dict)
            {
                decimal average = 0;
                for (int i = 0; i < item.Value.Count; i++)
                {
                    average += item.Value[i];
                }
                average /= item.Value.Count;
                Console.Write($"{item.Key} -> ");
                for (int i = 0; i < item.Value.Count; i++)
                {
                    Console.Write($"{item.Value[i]:f2} ");
                }
                Console.WriteLine($"(avg: {average:f2})");
            }
        }
    }
}
