using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Domain
{
    public class WallTests
    {
        [Test]
        public void IsInside_PositionAtOrigin_ReturnsTrue()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var position = new Position(0, 0);

            // Act
            var result = wall.IsInside(position);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsInside_PositionWithinBounds_ReturnsTrue()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var position = new Position(3, 4);

            // Act
            var result = wall.IsInside(position);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsInside_PositionBeyondMaxX_ReturnsFalse()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var position = new Position(6, 3);

            // Act
            var result = wall.IsInside(position);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsInside_PositionWithNegativeY_ReturnsFalse()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var position = new Position(2, -1);

            // Act
            var result = wall.IsInside(position);

            // Assert
            Assert.That(result, Is.False);
        }
    }
}
