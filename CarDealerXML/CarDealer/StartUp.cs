using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.IO;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static object User { get; private set; }

        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();

            //9
            //string input = File.ReadAllText("C:\\Users\\User\\Desktop\\PushToGithub\\c#\\CarDealerXML\\CarDealer\\Datasets\\suppliers.xml");
            //Console.WriteLine(ImportSuppliers(context, input));

            //10
            //string input = File.ReadAllText("C:\\Users\\User\\Desktop\\PushToGithub\\c#\\CarDealerXML\\CarDealer\\Datasets\\parts.xml");
            //Console.WriteLine(ImportParts(context, input));

            //11
            //string input = File.ReadAllText("C:\\Users\\User\\Desktop\\PushToGithub\\c#\\CarDealerXML\\CarDealer\\Datasets\\cars.xml");
            //Console.WriteLine(ImportCars(context, input));

            //12
            //string input = File.ReadAllText("C:\\Users\\User\\Desktop\\PushToGithub\\c#\\CarDealerXML\\CarDealer\\Datasets\\customers.xml");
            //Console.WriteLine(ImportCustomers(context, input));

            //13
            //string input = File.ReadAllText("C:\\Users\\User\\Desktop\\PushToGithub\\c#\\CarDealerXML\\CarDealer\\Datasets\\sales.xml");
            //Console.WriteLine(ImportSales(context, input));

            //14
            //Console.WriteLine(GetCarsWithDistance(context));

            //15
            Console.WriteLine(GetCarsFromMakeBmw(context));
        }

        private static Mapper getMapper() 
        {
            var cfg = new MapperConfiguration(c => c.AddProfile<CarDealerProfile>());
            return new Mapper(cfg);
        }

        //9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SupplierImportDTO[]),
                new XmlRootAttribute("Suppliers"));

            using var reader = new StringReader(inputXml);
            SupplierImportDTO[] supplierImportDTOs = (SupplierImportDTO[])xmlSerializer.Deserialize(reader);

            var mapper = getMapper();
            Supplier[] suppliers = mapper.Map<Supplier[]>(supplierImportDTOs);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        //10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(PartImportDTO[]), new XmlRootAttribute("Parts"));
            
            using var reader = new StringReader(inputXml);
            PartImportDTO[] partImportDTOs = (PartImportDTO[])xmlSerializer.Deserialize(reader);

            var suppliersIds = context.Suppliers
                .Select(x => x.Id)
                .ToArray();

            var mapper = getMapper();
            Part[] parts = mapper.Map<Part[]>(partImportDTOs.Where(x => suppliersIds.Contains(x.SupplierId)));

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //11
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarImportDTO[]), new XmlRootAttribute("Cars"));

            using var reader = new StringReader(inputXml);
            CarImportDTO[] carImportDTOs = (CarImportDTO[])xmlSerializer.Deserialize(reader);

            var mapper = getMapper();
            List<Car> cars = new List<Car>();

            foreach (var carDTO in carImportDTOs)
            {
                Car car = mapper.Map<Car>(carDTO);

                int[] ids = context.Cars.
                    Select(x => x.Id)
                    .Distinct()
                    .ToArray();

                var CarParts = new List<PartCar>();

                foreach (var id in ids)
                {
                    CarParts.Add(new PartCar
                    {
                        Car = car,
                        PartId = id
                    });
                }

                car.PartsCars = CarParts;
                cars.Add(car);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        //12
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CustomerImportDTO[]), new XmlRootAttribute("Customers"));

            using var reader = new StringReader(inputXml);
            CustomerImportDTO[] customerImportDTOs = (CustomerImportDTO[])xmlSerializer.Deserialize(reader);

            var mapper = getMapper();
            Customer[] customers = mapper.Map<Customer[]>(customerImportDTOs);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //13
        public static string ImportSales(CarDealerContext context, string inputXml) 
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaleImportDTO[]),
                new XmlRootAttribute("Sales"));

            using var reader = new StringReader(inputXml);
            SaleImportDTO[] saleImportDTOs = (SaleImportDTO[])xmlSerializer.Deserialize(reader);

            var carIds = context.Cars.Select(car => car.Id).ToList();

            var mapper = getMapper();
            Sale[] sales = mapper.Map<Sale[]>(saleImportDTOs.Where(x => carIds.Contains(x.CarId)));

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        //14
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var mapper = getMapper();

            var cars = context.Cars.
                Where(x => x.TraveledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .ProjectTo<CarExportDTO>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarExportDTO[]),
                new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(String.Empty, String.Empty);

            StringBuilder stringBuilder = new StringBuilder();

            using (StringWriter sw = new StringWriter(stringBuilder))
            {
                xmlSerializer.Serialize(sw, cars, xsn);
            }

            XDocument doc = XDocument.Parse(stringBuilder.ToString());

            return doc.ToString();
        }

        //15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var mapper = getMapper();

            var cars = context.Cars.
                Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .ProjectTo<CarExportWithIds>(mapper.ConfigurationProvider)
                .ToArray();

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(CarExportWithIds[]));

            var xsn = new XmlSerializerNamespaces();
            xsn.Add(String.Empty, String.Empty);

            StringBuilder sb = new StringBuilder();

            using (StringWriter sw = new StringWriter(sb))
            {
                xmlSerializer.Serialize(sw, cars, xsn);
            }

            XDocument doc = XDocument.Parse(sb.ToString());

            return doc.ToString();
        }
    }
}