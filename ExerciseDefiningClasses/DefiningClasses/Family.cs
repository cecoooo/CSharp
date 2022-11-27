using System;
using System.Collections.Generic;
using System.Text;
using DefiningClasses;
using System.Linq;
using System.Collections;
using System.Net.Cache;

public class Family: IEnumerable<Person>
{
    private List<Person> list = new List<Person>();

    public List<Person> List 
    { 
        get { return list; }
        set { list = value; }
    }

    public void AddMember(Person person) 
    {
        this.list.Add(person);
    }

    public Person GetOldestMember()
    {
        Person p = new Person();
        int max = int.MinValue;
        for (int i = 0; i < this.List.Count; i++)
        {
            if (list[i].Age > max) 
            {
                max = list[i].Age;
                p = list[i];
            }
        }
        return p;
    }

    IEnumerator<Person> IEnumerable<Person>.GetEnumerator()
    {
        foreach (Person p in this.list)
        {
            yield return p;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public Person this[int index] 
    {
        get => list[index];
        set => list[index] = value;
    }
}