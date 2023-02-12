using NUnit.Framework;
using System;

namespace SantaseTests
{
    public class GamesTest
    {
        [Test]
        public void TestConstructor()
        {
            Game game = new Game(new Player("g"), new Player("g"), 7);
            Assert.IsNotNull(game);
        }

        [Test]
        public void GameGoal_MustBeGiggerThanZero()
        {
            var ex = Assert.Throws<ArgumentException>(() => 
            {
                Game game = new Game(new Player("g"), new Player("g"), -7);
            });
            Assert.Throws<ArgumentException>(() =>
            {
                Game game = new Game(new Player("g"), new Player("g"), 0);
            });
            Assert.That(ex.Message, Is.EqualTo("Goal must be bigger than zero."));
        }

        [Test]
        public void TestGameGetters() 
        {
            Game game = new Game(new Player("g"), new Player("f"), 7);
            Assert.That(game.You.Name, Is.EqualTo("g"));
            Assert.That(game.Opponent.Name, Is.EqualTo("f"));
            Assert.That(game.Goal, Is.EqualTo(7));
        }
    }
}