using RobotSpiders.Application.Commands;
using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Application.Commands
{
    public class TurnRightCommandTests
    {
        [Test]
        public void Execute_TurnsSpiderRight()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(0, 0), Direction.Up, wall);
            var command = new TurnRightCommand(spider);

            // Act
            command.Execute();

            // Assert
            Assert.That(spider.Direction, Is.EqualTo(Direction.Right));
            Assert.That(spider.Position.X, Is.EqualTo(0));
            Assert.That(spider.Position.Y, Is.EqualTo(0));
        }
    }
}
