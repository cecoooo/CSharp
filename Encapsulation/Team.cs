using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using PersonsInfo;

public class Team
{
    private string name;
    public string Name
    {
        get { return name; }
        private set { name = value; }
    }

    private List<Person> firstTeam = new List<Person>();

    public List<Person> FirstTeam
    {
        get { return firstTeam; }
        private set { firstTeam = value; }
    }

    private List<Person> reservedTeam = new List<Person>();

    public List<Person> ReservedTeam
    {
        get { return reservedTeam; }
        private set { reservedTeam = value; }
    }

    public Team() 
    {
            
    }
    public Team(string name)
    {
        this.Name = name;
    }
    public void AddPlayer(Person person) 
    {
        if (person.Age < 40)
        {
            this.firstTeam.Add(person);
        }
        else 
        {
            this.reservedTeam.Add(person);
        }
    }

}