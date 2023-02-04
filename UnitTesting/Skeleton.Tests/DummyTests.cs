using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyLosesHealth_IfAttacked()
        {
            // Arrange 
            Dummy dummy = new Dummy(3, 2);

            // Act
            dummy.TakeAttack(2);

            // Assert
            Assert.That(dummy.Health, Is.EqualTo(1));
        }

        [Test]
        public void DeadDummyThrowsAnException_IfAttacked()
        {
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                // Arrange
                Dummy dummy = new Dummy(0, 1);

                // Act
                dummy.TakeAttack(1);
            });
            Assert.That(ex.Message, Is.EqualTo("Dummy is dead."));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            // Arrange
            Dummy dummy = new Dummy(0, 9);

            // Act
            var xp = dummy.GiveExperience();

            // Assert
            Assert.That(xp, Is.EqualTo(9));
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                // Arrange
                Dummy dummy = new Dummy(2, 2);

                // Act
                dummy.GiveExperience();
            });
            Assert.That(ex.Message, Is.EqualTo("Target is not dead."));
        }
    }
}