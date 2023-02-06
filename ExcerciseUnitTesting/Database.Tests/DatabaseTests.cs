namespace Database.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Xml.Linq;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void ArraysCapacity_MustBe_Exactly16Integer()
        {
            Database database = new Database();
            for (int i = 1; i < 17; i++)
                database.Add(i);
            Assert.That(database.Count, Is.EqualTo(16));
            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void AddAnElementAtTheNextFreeCell()
        {
            Database database = new Database();
            for (int i = 0; i < 16; i++)
            {
                database.Add(i);
                Assert.That(database.Count, Is.EqualTo(i+1));
            }
            Assert.Throws<InvalidOperationException>(() => database.Add(16));
        }

        [Test]
        public void RemovingAnElementAtTheLastIndex()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.Remove());
            database.Add(1);
            database.Add(2);
            database.Remove();
            Assert.That(database.Fetch()[database.Count-1], Is.EqualTo(1));
        }

        [Test]
        public void ConstructorsShouldTakeIntegersOnly_AndStoreThemInTheArray()
        {
            Database database = new Database(0, 1, 2);
            int[] arr = database.Fetch();
            for (int i = 0; i < database.Count; i++)
            {
                Assert.That(i, Is.EqualTo(arr[i]));
            }
        }

        [Test]
        public void TheFetchMethod_ShouldReturnTheElements_AsAnArray() 
        {
            Database database = new Database();
            var arr = database.Fetch();
            Assert.That(arr, Is.TypeOf(typeof(int[])));
        }
    }
}
