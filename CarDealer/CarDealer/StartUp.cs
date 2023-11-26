using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using CarDealer.Data;
using CarDealer.Models;
using System.Diagnostics;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //9
            //string path = File.ReadAllText("C:/Users/User/Desktop/PushToGithub/c#/CarDealer/CarDealer/Datasets/suppliers.json");
            //Console.WriteLine(ImportSuppliers(context, path));

            //10
            //string path = File.ReadAllText("C:/Users/User/Desktop/PushToGithub/c#/CarDealer/CarDealer/Datasets/parts.json");
            //Console.WriteLine(ImportParts(context, path));

            //11
            //string path = File.ReadAllText("C:/Users/User/Desktop/PushToGithub/c#/CarDealer/CarDealer/Datasets/cars.json");
            //Console.WriteLine(ImportCars(context, path));

            //12
            //string path = File.ReadAllText("C:/Users/User/Desktop/PushToGithub/c#/CarDealer/CarDealer/Datasets/customers.json");
            //Console.WriteLine(ImportCustomers(context, path));

            //13
            //string path = File.ReadAllText("C:/Users/User/Desktop/PushToGithub/c#/CarDealer/CarDealer/Datasets/sales.json");
            //Console.WriteLine(ImportSales(context, path));

            //14
            //Console.WriteLine(GetOrderedCustomers(context));

            //15
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //15
            //Console.WriteLine(GetLocalSuppliers(context));

            //16
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //17
            Console.WriteLine(GetTotalSalesByCustomer(context));
        }

        //9
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Count()}.";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(x => x.SupplierId <= 31 && x.SupplierId >= 1);
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Count()}.";
        }

        //1
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);
            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count()}.";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Count()}.";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);
            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count()}.";
        }

        //14
        public static string GetOrderedCustomers(CarDealerContext context) 
        {
            var customers = context.Customers
                .Select(x => new
                {
                    x.Name,
                    x.BirthDate,
                    x.IsYoungDriver
                })
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .ToArray();

            var settings = new JsonSerializerSettings 
            { 
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented,
            };
            return JsonConvert.SerializeObject(customers, settings);
        }

        //15
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.Make == "Toyota")
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TraveledDistance
                })
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ToArray();

            return JsonConvert.SerializeObject(cars, Formatting.Indented);
        }

        //16
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.AsQueryable().Count()
                })
                .ToArray();

            return JsonConvert.SerializeObject(suppliers, Formatting.Indented);
        }

        //17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var carsWithParts = context.Cars
                .Select(x => new
                {
                    car = new
                    {
                        x.Make,
                        x.Model,
                        x.TraveledDistance
                    },
                    parts = x.PartsCars.Select(x => new
                    {
                        Name = x.Part.Name,
                        Price = $"{x.Part.Price:f2}",
                    })
                    .ToArray()
                })
                .ToArray();

            return JsonConvert.SerializeObject(carsWithParts, Formatting.Indented);
        }

        //18
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.Customers
                .Where(x => x.Sales.Count() > 0)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count()
                })
                .OrderByDescending(x => x.boughtCars);

            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}