using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            Team team = new Team();
            for (int i = 0; i < n; i++)
            {
                var command = Console.ReadLine().Split(' ');
                Person person = new Person(command[0], command[1], int.Parse(command[2]), decimal.Parse(command[3]));
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.\nReserve team has {team.ReservedTeam.Count} players.");
        }
    }
}
