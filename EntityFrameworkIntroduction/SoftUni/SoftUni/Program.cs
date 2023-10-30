using SoftUni.Data;
using SoftUni.Models;

namespace SoftUni
{
    public class Program
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            Employee employee = context.Employees.Find(1);
            Console.WriteLine(employee.FirstName);
        }
    }
}