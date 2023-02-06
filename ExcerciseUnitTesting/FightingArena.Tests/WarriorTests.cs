namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Threading;

    [TestFixture]
    public class WarriorTests
    {
        private Warrior CreateWarior()
        {
            return new Warrior("warior", 2, 30);
        }

        [Test]
        public void TestConstructor()
        {
            Warrior warrior = CreateWarior();
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void TestNameGetterAndSetter()
        {
            Warrior warrior = CreateWarior();
            Assert.That(warrior.Name, Is.EqualTo("warior"));
        }

        [Test]
        public void TestDamageGetterAndSetter()
        {
            Warrior warrior = CreateWarior();
            Assert.That(warrior.Damage, Is.EqualTo(2));
        }

        [Test]
        public void TestHP_GetterAndSetter()
        {
            Warrior warrior = CreateWarior();
            Assert.That(warrior.HP, Is.EqualTo(30));
        }

        [Test]
        public void WarriorNameMustThrow_ArgumentException_IfNameIs_NullEmptyOrWhiteSpace()
        {
            Assert.Throws<ArgumentException>(() => 
            {
                Warrior warrior = new Warrior("", 2, 30);

            });
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(" ", 2, 30);

            });
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(null, 2, 30);

            });
            Assert.That(ex.Message, Is.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void WarriorDamageMustThrow_ArgumentException_IfDamageIs_ZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("warrior", 0, 30);

            });
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("warrior", -1, 30);

            });
            Assert.That(ex.Message, Is.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void WarriorHP_MustThrow_ArgumentException_IfHP_IsNegative()
        {
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior("warrior", 2, -1);

            });
            Assert.That(ex.Message, Is.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void WarriorCannotAttack_IfHisHP_IsBelow30_MustThrow_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() => 
            {
                Warrior warrior = new Warrior("w", 2, 29);
                warrior.Attack(new Warrior("w2", 2, 30));
            });
            Assert.That(ex.Message, Is.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void WarriorCannotAttackWarriorsWhoseHP_Arebelow30_MustThrow_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new Warrior("w", 2, 30);
                warrior.Attack(new Warrior("w2", 2, 29));
            });
        }

        [Test]
        public void WarriorCannotAttackStrongerEnemies_MustThrow_InvalidOperationException()
        {
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                Warrior warrior = new Warrior("w", 32, 31);
                warrior.Attack(new Warrior("w2", 32, 32));
            });
            Assert.That(ex.Message, Is.EqualTo("You are trying to attack too strong enemy"));
        }
    }
}