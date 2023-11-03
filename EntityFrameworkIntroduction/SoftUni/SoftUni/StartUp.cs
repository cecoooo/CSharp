using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext context = new SoftUniContext();
            //var ex = GetEmployeesFullInformation(context); // 3ex
            //var ex = GetEmployeesWithSalaryOver50000(context); // 4ex
            //var ex = GetEmployeesFromResearchAndDevelopment(context); // 5ex
            //var ex = AddNewAddressToEmployee(context); // 6ex
            var ex = GetAddressesByTown(context); // 8ex
            Console.WriteLine(ex);
        }
        public static string GetEmployeesFullInformation(SoftUniContext context) // 3ex
        {
            var employees = context.Employees.Select(x => new {
                x.FirstName,
                x.LastName,
                x.MiddleName,
                x.JobTitle,
                x.Salary
            });

            string res = String.Join('\n', employees.Select(x => $"{x.FirstName} {x.LastName} {x.MiddleName} {x.JobTitle} {x.Salary:f2}"));

            return res;
        }
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context) // 4ex
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary
                })
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName);

            string res = String.Join('\n', employees.Select(x => $"{x.FirstName} - {x.Salary:f2}"));

            return res;
        }
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context) // 5ex
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department.Name,
                    x.Salary
                })
                .Where(x => x.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName);

            string res = String.Join('\n', employees.Select(x => $"{x.FirstName} {x.LastName} from {x.Name} - {x.Salary:c2}"));

            return res;

        }
        public static string AddNewAddressToEmployee(SoftUniContext context) // 6ex
        {
            Address address = new Address();
            address.AddressText = "Vitoshka 15";
            address.TownId = 4;

            Employee emp = context.Employees.FirstOrDefault(x => x.LastName == "Nakov");

            emp.Address = address;
            context.SaveChanges();

            var employees = context.Employees
                .Select(x => new
                {
                    x.Address.AddressText,
                    x.AddressId,
                })
                .Take(10)
                .OrderByDescending(x => x.AddressId);

            return String.Join('\n', employees.Select(x => $"{x.AddressText}"));  
        }
        public static string GetAddressesByTown(SoftUniContext context) // 8ex
        {
            var address = context.Employees
                                     .Select(x => new
                                     {
                                         count = x.FirstName.Count(),
                                         x.Address.Town.Name,
                                         x.Address.AddressText
                                     })
                                       .Take(10)
                                       .OrderByDescending(x => x.count)
                                       .ThenBy(x => x.Name)
                                       .ThenBy(x => x.AddressText)
                                       .GroupBy(x => new
                                       {
                                           x.AddressText,
                                           x.Name,
                                           x.count
                                       });

            return String.Join('\n', address.Select(x => $"{x.Key.AddressText}, {x.Key.Name} - {x.Key.count} employees"));
        }
    }
}