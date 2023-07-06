using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class CarBuilderInfo:CarBuilderFacade
    {
        public CarBuilderInfo(Car car) 
        {
            Car = car;
        }
        public CarBuilderInfo WithType(string type) 
        {
            Car.Type = type;
            return this;
        }
        public CarBuilderInfo WithColor(string color) 
        {
            Car.Color = color;
            return this;
        }
        public CarBuilderInfo WithNumberDoors(int number) 
        {
            Car.NumberOfDoors = number;
            return this;
        }
    }
}
