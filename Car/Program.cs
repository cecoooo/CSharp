using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer

{
    public class StartUp
    {
        static void Main()
        {
            //Car car = new Car();
            //car.Make = "BMW";
            //car.Model = "X6";
            //car.Year = 2002;
            //car.FuelQuantity = 200;
            //car.FuelConsumption = 0.02;
            //car.Drive(2000);
            //car.Drive(1000);
            //Console.WriteLine(car.WhoAmI());
            //Console.WriteLine();

            //Car carr = new Car("bmw", "x6", 2001);
            //Console.WriteLine(carr.Make);
            //Console.WriteLine(carr.Model);
            //Console.WriteLine(carr.Year);
            //Console.WriteLine(carr.FuelQuantity);
            //Console.WriteLine(carr.FuelConsumption);
            //Console.WriteLine();

            //Car carrr = new Car("Audi", "A3", 2005, 100, 0.1);
            //Console.WriteLine(carrr.Make);
            //Console.WriteLine(carrr.Model);
            //Console.WriteLine(carrr.Year);
            //Console.WriteLine(carrr.FuelQuantity);
            //Console.WriteLine(carrr.FuelConsumption);
            //Console.WriteLine();


            //Tire[] tires = new Tire[4]
            //{
            //    new Tire(2019, 2.5),
            //    new Tire(2018, 2.4),
            //    new Tire(2017, 2.5),
            //    new Tire(2019, 2.6)
            //};

            //Engine engine = new Engine(100, 500);

            //Car car = new Car("BMW", "x6", 2001, 100, 0.1, engine, tires);

            //Console.WriteLine($"Make: {car.Make}\n" +
            //    $"Model: {car.Model}\n" +
            //    $"Year: {car.Year}\n" +
            //    $"Fuel Quantity: {car.FuelQuantity}\n" +
            //    $"Fuel Consumtion: {car.FuelConsumption}\n" +
            //    $"Engine info => Horse power: {car.Engine.HorsePower}\n" +
            //    $"            => Cubics: {car.Engine.CubicCapacity}\n" +
            //    $"Tires info => Year: {string.Join(", ", car.Tires.Select(x => x.Year))}\n" +
            //    $"           => Pressure: {string.Join(", ", car.Tires.Select(x => x.Pressure))}");

            Func<string, Tire[]> toTire = x =>
            {
                string[] y = x.Split(' ').ToArray();
                var tires = new Tire[4];
                int c = 0;
                for (int i = 0; i < y.Length; i += 2)
                {
                    int year = int.Parse(y[i]);
                    double pressure = double.Parse(y[i + 1]);
                    var tire = new Tire(year, pressure);
                    tires[c] = tire;
                    c++;
                }
                return tires;
            };
            var tiresList = new List<Tire[]>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "No more tires") break;
                Tire[] tires = toTire(command);
                tiresList.Add(tires);
            }
            var engineList = new List<Engine>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Engines done") break;
                var engines = ToEngine(command);
                engineList.Add(engines);
            }
            //for (int i = 0; i < tiresList.Count; i++)
            //{
            //    for (int j = 0; j < tiresList[i].Length; j++)
            //    {
            //        Console.WriteLine($"HP: {tiresList[i][j].Year} Cubics: {tiresList[i][j].Pressure}");
            //    }
            //}
            //for (int i = 0; i < engineList.Count; i++)
            //{
            //    Console.WriteLine($"HP: {engineList[i].HorsePower} Cubics: {engineList[i].CubicCapacity}");
            //}
            var carList = new List<Car>();
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Show special") break;
                Car car = ToCar(command, engineList, tiresList);
                carList.Add(car);
            }
            //Console.WriteLine();
            //for (int i = 0; i < carList.Count; i++)
            //{
            //    Car car = carList[i];
            //    Console.WriteLine($"Make: {car.Make}\n" +
            //        $"Model: {car.Model}\n" +
            //        $"Year: {car.Year}\n" +
            //        $"Fuel Quantity: {car.FuelQuantity}\n" +
            //        $"Fuel Consumtion: {car.FuelConsumption}\n" +
            //        $"Engine info => Horse power: {car.Engine.HorsePower}\n" +
            //        $"            => Cubics: {car.Engine.CubicCapacity}\n" +
            //        $"Tires info => Year: {string.Join(", ", car.Tires.Select(x => x.Year))}\n" +
            //        $"           => Pressure: {string.Join(", ", car.Tires.Select(x => x.Pressure))}");
            //    Console.WriteLine();
            //}
            Func<Car, bool> isDrive = x => 
            {
                double sum = 0.0;
                for (int i = 0; i < 4; i++) 
                    sum += x.Tires[i].Pressure;
                if (x.Year >= 2017 && x.Engine.HorsePower > 330 && sum >= 9 && sum <= 10) 
                    return true;
                else 
                    return false;
            };
            for (int i = 0; i < carList.Count; i++)
            {
                Car car = carList[i];
                if (isDrive(car))
                {
                    car.FuelQuantity = DriveCar(20, car);
                    Console.WriteLine($"Make: {car.Make}\n" +
                        $"Model: {car.Model}\n" +
                        $"Year: {car.Year}\n" +
                        $"HorsePowers: {car.Engine.HorsePower}\n" +
                        $"FuelQuantity: {car.FuelQuantity}");
                }
            }
        }
        static Engine ToEngine(string text)
        {
            var textArr = text.Split(' ');
            int hp = int.Parse(textArr[0]);
            double cubics = double.Parse(textArr[1]);
            Engine engine = new Engine(hp, cubics);
            return engine;
        }
        static Car ToCar(string text, List<Engine> listEng, List<Tire[]> listTireArr)
        {
            var arr = text.Split(' ');
            string make = arr[0];
            string model = arr[1];
            int year = int.Parse(arr[2]);
            var fuelQ = double.Parse(arr[3]);
            var fuelC = double.Parse(arr[4]);
            int indexEng = int.Parse(arr[5]);
            int indexTires = int.Parse(arr[6]);
            Car car = new Car(make, model, year, fuelQ, fuelC, listEng[indexEng], listTireArr[indexTires]);
            return car;
        }
        static double DriveCar(int dist, Car car) 
        {
            double fuelC = car.FuelConsumption/100;
            double fuelQ = car.FuelQuantity;
            return fuelQ - dist * fuelC; 
        }
    }
}
