using System;

namespace Basketball
{

    public class StartUp
    {
        static void Main()
        {
            Player secondPlayer = new Player("Slavi", "Point Guard", 94.3, 47);
            Player thirdPlayer = new Player("Evgeni", "Shooting Guard", 93.7, 16);
            Player fourthPlayer = new Player("Momchil", "Small forward", 67.9, 3);
            Player fifthPlayer = new Player("Vasil", "Power forward", 86.9, 10);
            Player sixthPlayer = new Player("Stefan", "Center", 95.6, 25);
            Player seventhPlayer = new Player("Ivan", " Small forward ", 98.5, 89);
            Team team = new Team("BHTC", 5, 'A');
            team.AddPlayer(secondPlayer);
            team.AddPlayer(seventhPlayer);
            team.AddPlayer(thirdPlayer);
            team.AddPlayer(fourthPlayer);
            team.AddPlayer(fifthPlayer);
            team.AddPlayer(sixthPlayer);
            Console.WriteLine(team.Report());
        }
    }
}
