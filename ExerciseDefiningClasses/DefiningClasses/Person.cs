using System;
using System.Collections.Generic;
using System.Text;
using DefiningClasses;
public class Person: IComparable<Person>
{
	private string name;

	public string Name
	{
		get { return name; }
		set { name = value; }
	}
	private int age;

	public int Age
	{
		get { return age; }
		set { age = value; }
	}

	public Person() 
	{
		this.name = "No name";
		this.age = 1;
	}
    public Person(int age)
    {
        this.name = "No name";
        this.age = age;
    }
    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    int IComparable<Person>.CompareTo(Person other)
    {
        Person p = other;
        return Name.CompareTo(p.Name);
    }
}
