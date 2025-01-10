using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FightClubExample;

namespace Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void Soldier_Constructor_ThrowsArgumentException_OnNegativeHealth()
        { 
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Knight("Sir Gallant", -10));

        }

        [TestMethod]
        public void Knight_TakesReducedDamage_WithArmor()
        { 
            // Arrange

            var knight = new Knight("Sir Gallant");

            int initialHealth = knight.Health;

            int incomingDamage = 50;

            // Act

            knight.TakeDamage(incomingDamage);

            // Assert

            int expectedDamage = incomingDamage + (incomingDamage * knight.Armor / 100);

            int expectedHealth = initialHealth - expectedDamage;

            Assert.AreEqual(expectedHealth, knight.Health);

        }

        [TestMethod]
        public void Goblin_TakesDamage_WithNegativeDamage()
        {
            // Arrange
            Goblin enemy = new Goblin("Grik");

            // Assert
            Assert.ThrowsException<ArgumentException>(() => enemy.TakeDamage(-15));
        }

        [TestMethod]
        public void Enemy_Constructor_ThrowsArgumentException_OnNegativeHealth()
        {
            // Arrange & Act & Assert
            Assert.ThrowsException<ArgumentException>(() => new Dragon("Smaug", -10));
        }
    }
}
