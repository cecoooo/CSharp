using PersonsInfo;
using System;

public class Person
{
    private string fname;
    public string FirstName
    {
        get { return fname; }
        private set {
            fname = value;
            if (this.fname.Length < 3) 
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");  
        }
    }

    private string lname;

    public string LastName
    {
        get { return lname; }
        private set { lname = value;
            if (this.lname.Length < 3)
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
        }
    }

    private int age;

    public int Age
    {
        get { return age; }
        private set { age = value;
            if (this.age <= 0) 
                throw new ArgumentException("Age cannot be zero or a negative integer!");
        }
    }

    private decimal salary;

    public decimal Salary
    {
        get { return salary; }
        private set { salary = value;
            if (this.salary < 460) 
                throw new ArgumentException("Salary cannot be less than 650 leva!"); 
        }
    }

    public Person() 
    {
    
    }
    public Person(string fname, string lname, int age, decimal salary) 
    {
        this.FirstName = fname;
        this.LastName = lname;
        this.Age = age;
        this.Salary = salary;
    }
    public void IncreaseSalary(decimal percentage) 
    {
        var income = 0m;
        if (this.Age < 30) 
            income = this.Salary * (percentage / 200);
        else
            income = this.Salary * (percentage / 100);
        this.Salary += income;
    }
    public override string ToString() 
    {
        return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
    }
}