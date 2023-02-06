namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;
    using System.Runtime.InteropServices;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void ArraysCapacity_MustBe_Exactly16Integer()
        {
            Database database = new Database();
            for (int i = 1; i < 17; i++)
                database.Add(new Person(i, i.ToString()));
            Assert.That(database.Count, Is.EqualTo(16));
            Assert.Throws<InvalidOperationException>(() => database.Add(new Person(17, "17")));
        }

        [Test]
        public void RemovingAnElementAtTheLastIndex()
        {
            Database db = new Database(new Person[] { new Person(1, "1") , new Person(2 ,"2"), new Person(3, "3") });
            db.Remove();
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("3"));
        }
        [Test]
        public void RemovingAnElementAtTheLastIndex_MustTrow_InvalidOperationException_IfArrayIsEmpty()
        {
            Database db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.Remove());
        }

        [Test]
        public void ConstructorsShouldTakeIntegersOnly_AndStoreThemInTheArray()
        {
            Database db = new Database(new Person[] { new Person(1, "1"), new Person(2, "2"), new Person(3, "3") });
            Assert.That(db.Count, Is.EqualTo(3));
        }

        [Test]
        public void IfThereAreAlreadyUsers_WithThisUsername_InvalidOperationException_IsThrown()
        {
            Database database = new Database();
            Person person = new Person(1, "gosho");
            Person person1 = new Person(2, "gosho");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.Add(person1));
        }

        [Test]
        public void IfThereAreAlreadyUsers_WithThisId_InvalidOperationException_IsThrown()
        {
            Database database = new Database();
            Person person = new Person(1, "gosho");
            Person person1 = new Person(1, "gosho1");
            database.Add(person);
            Assert.Throws<InvalidOperationException>(() => database.Add(person1));
        }

        [Test]
        public void IfNoUserIsPresentByThisUsername_InvalidOperationException_IsThrown()
        {
            Database database = new Database();
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("gosho"));
        }

        [Test]
        public void IfTheUsernameParameterIsNull_ArgumentNullException_IsThrown()
        {
            Database database = new Database();
            Assert.Throws<ArgumentNullException>(() => database.FindByUsername(null));
        }

        [Test]
        public void ArgumentsAreAll_CaseSensitive()
        {
            Database database = new Database();
            Person person = new Person(1, "gosho");
            database.Add(person);
            database.FindByUsername("gosho");
            Assert.Throws<InvalidOperationException>(() => database.FindByUsername("Gosho"));
        }

        [Test]
        public void IfNoUserIsPresentByThisId_InvalidOperationException_IsThrown()
        { 
            Database db = new Database();
            Assert.Throws<InvalidOperationException>(() => db.FindById(1));
        }
        [Test]
        public void IfNegativeIdsAreFound_ArgumentOutOfRangeException_IsThrown()
        {
            Database db = new Database();
            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-11));
        }
    }
}