
using Facade;

var car = new CarBuilderFacade().Info.WithType("BMW").WithColor("Black").WithNumberDoors(4).Built.InCity("Munich").AtAddress("ala bala").Build();

Console.WriteLine(car);