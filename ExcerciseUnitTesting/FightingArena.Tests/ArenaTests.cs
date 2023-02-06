namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Immutable;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void TestConstructor() 
        {
            Arena arena = new Arena();
            Assert.That(arena, Is.Not.Null);
            
        }

        [Test]
        public void TestCount() 
        {
            Arena arena = new Arena();
            Assert.That(arena.Count, Is.EqualTo(0));
            arena.Enroll(new Warrior("w", 2, 2));
        }

        [Test]
        public void TestEnrollMethod() 
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("w", 2, 2));
            Warrior[] arr = arena.Warriors.ToImmutableArray<Warrior>().ToArray();
            Assert.That(arr[0].Name, Is.EqualTo("w"));
            Assert.That(arr[0].Damage, Is.EqualTo(2));
            Assert.That(arr[0].HP, Is.EqualTo(2));
        }

        [Test]
        public void AlreadyEnrolledWarriors_ShouldNotBeAble_ToEnrollAgain_MustThrow_InvalidOperationException()
        {
            Arena arena = new Arena();
            arena.Enroll(new Warrior("w", 2, 2));
            var ex = Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("w", 2, 2)));
            Assert.That(ex.Message, Is.EqualTo("Warrior is already enrolled for the fights!"));
        }

        [Test]
        public void ThereCannotBeA_FighIf_OneOfTheWarriors_IsNotEnrolledForTheFights_MustThrow_InvalidOperationException() 
        {
            Warrior warrior = new Warrior("w", 2, 2);
            Arena arena = new Arena();
            arena.Enroll(warrior);
            Assert.Throws<InvalidOperationException>(() => arena.Fight(warrior.Name, "w1"));
        }
    }
}
