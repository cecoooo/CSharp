using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using SantaseTests;

public class PlayerTest
{
    [Test]
    public void TestPlayerConstructor() 
    {
        Player player = new Player("Gosho");
        Assert.IsNotNull(player);
    }

    [Test]
    public void PlayerName_MustNotBe_NullWhiteSpaceOrEmptyString()
    {
        Assert.Throws<ArgumentException>(() =>
            {
                Player player = new Player("");
            });
        Assert.Throws<ArgumentException>(() =>
        {
            Player player = new Player(" ");
        });
        var ex= Assert.Throws<ArgumentException>(() =>
        {
            Player player = new Player(null);
        });
        Assert.That(ex.Message, Is.EqualTo("Name must not be empty string, null or spaces only"));
    }

    [Test]
    public void TestGatters()
    {
        Player player = new Player("Gosho");
        Assert.That(player.Points, Is.EqualTo(0));
        Assert.That(player.Points, Is.EqualTo(0));
        Assert.That(player.Name, Is.EqualTo("Gosho"));
    }
}
