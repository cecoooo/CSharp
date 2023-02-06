namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car CreateCar()
        {
            string make = "golf";
            string model = "combi";
            double fuelConsumption = 1.0;
            double fuelCapacity = 1.0;
            return new Car(make, model, fuelConsumption, fuelCapacity);
        }
        [Test]
        public void TestConstructors()
        {
            Car car = CreateCar();
            Assert.That(car, Is.Not.Null);
        }

        [Test]
        public void TestMakeGatterAndSetter()
        {
            Car car = CreateCar();
            Assert.That(car.Make, Is.EqualTo("golf"));
        }

        [Test]
        public void TestModelGatterAndSetter()
        {
            Car car = CreateCar();
            Assert.That(car.Model, Is.EqualTo("combi"));
        }

        [Test]
        public void TestFuelConsumptionGatterAndSetter()
        {
            Car car = CreateCar();
            Assert.That(car.FuelConsumption, Is.EqualTo(1));
        }

        [Test]
        public void TestFuelCapacityGatterAndSetter()
        {
            Car car = CreateCar();
            Assert.That(car.FuelCapacity, Is.EqualTo(1));
        }

        [Test]
        public void TestFuelAmountGatterAndSetter()
        {
            Car car = CreateCar();
            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }

        [Test]
        public void TestMakeValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() => 
            {
                Car car = new Car(null, "Combi", 1, 1);
            });
            Assert.That(ex.Message, Is.EqualTo("Make cannot be null or empty!"));
        }

        [Test]
        public void TestModelValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Golf", null, 1, 1);
            });
            Assert.That(ex.Message, Is.EqualTo("Model cannot be null or empty!"));
        }

        [Test]
        public void TestFuelConsumtionValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Golf", "Combi", 0, 1);
            });
            Assert.That(ex.Message, Is.EqualTo("Fuel consumption cannot be zero or negative!"));
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Golf", "Combi", -1, 1);
            });
        }

        [Test]
        public void TestFuelCapacityValidation()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Golf", "Combi", 1, 0);
            });
            Assert.That(ex.Message, Is.EqualTo("Fuel capacity cannot be zero or negative!"));
            Assert.Throws<ArgumentException>(() =>
            {
                Car car = new Car("Golf", "Combi", 1, -1);
            });
        }

        [Test]
        public void RefuaelMethod_MustRefuel_TheExactAmountOfFuel()
        {
            Car car = new Car("golf", "combi", 10, 50);
            car.Refuel(40);
            Assert.That(car.FuelAmount, Is.EqualTo(40));
        }

        [Test]
        public void RefuaelMethod_MustRefuel_NotAbove_TheCapacity()
        {
            Car car = new Car("golf", "combi", 10, 50);
            car.Refuel(60);
            Assert.That(car.FuelAmount, Is.EqualTo(50));
        }

        [Test]
        public void RefuelingWith_Zero_AmountOfFuel_MustThrowAn_ArgumentException()
        {
            Car car = new Car("golf", "combi", 10, 50);
            var ex = Assert.Throws<ArgumentException>(() => car.Refuel(0));
            Assert.That(ex.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void RefuelingWith_Negative_AmountOfFuel_MustThrowAn_ArgumentException()
        {
            Car car = new Car("golf", "combi", 10, 50);
            var ex = Assert.Throws<ArgumentException>(() => car.Refuel(-1));
            Assert.That(ex.Message, Is.EqualTo("Fuel amount cannot be zero or negative!"));
        }

        [Test]
        public void DrivingMust_LowerTheAmountOfFuel()
        {
            Car car = new Car("golf", "combi", 10, 50);
            car.Refuel(40);
            car.Drive(20);
            Assert.That(car.FuelAmount, Is.EqualTo(38));
        }

        [Test]
        public void WeCannotDriveTheDistance_WithoutEnoughAmountOfFuel_InvalidOperationException_IsThrown()
        {
            Car car = new Car("golf", "combi", 10, 50);
            car.Refuel(1);
            var ex = Assert.Throws<InvalidOperationException>(() => car.Drive(20));
            Assert.That(ex.Message, Is.EqualTo("You don't have enough fuel to drive!"));
        }
    }
}