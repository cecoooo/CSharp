using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void WeaponLosesDurability_AfterEachAttack()
        {
            // Arrange
            Axe axe = new Axe(3, 4);

            // Act
            axe.Attack(new Dummy(4, 5));

            // Assert
            Assert.AreEqual(axe.DurabilityPoints, 3);
        }

        [Test]
        public void AttackingWithA_BrockenWeapon() 
        {
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() =>
            {
                // Arrange
                Axe axe = new Axe(2, 0);
                // Act
                axe.Attack(new Dummy(1, 1));
            });
            Assert.That(ex.Message, Is.EqualTo("Axe is broken."));
        }
    }
}