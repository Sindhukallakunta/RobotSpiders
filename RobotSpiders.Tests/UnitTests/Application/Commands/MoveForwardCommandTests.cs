using RobotSpiders.Application.Commands;
using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Application.Commands
{
    public class MoveForwardCommandTests
    {
        [Test]
        public void Execute_MovesSpiderForward()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(2, 2), Direction.Up, wall);
            var command = new MoveForwardCommand(spider);

            // Act
            command.Execute();

            // Assert
            Assert.That(spider.Position, Is.EqualTo(new Position(2, 3)));
        }

        [Test]
        public void Execute_WhenAtUpperBoundary_ShouldNotMoveSpiderForward()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(2, 5), Direction.Up, wall);
            var command = new MoveForwardCommand(spider);

            // Act
            command.Execute();

            // Assert
            Assert.That(spider.Position, Is.EqualTo(new Position(2, 5)));
        }

    }
}
