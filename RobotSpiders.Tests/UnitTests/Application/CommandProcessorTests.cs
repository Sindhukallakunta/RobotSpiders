using RobotSpiders.Application;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Application
{
    public class CommandProcessorTests
    {
        [Test]
        public void Execute_EmptyInstructions_DoesNothing()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(1, 1), Direction.Up, wall);

            var factory = new CommandFactory(spider, new NullLogger());
            var processor = new CommandProcessor(factory);

            // Act
            processor.Execute(string.Empty);

            // Assert
            Assert.That(spider.Position, Is.EqualTo(new Position(1, 1)));
            Assert.That(spider.Direction, Is.EqualTo(Direction.Up));
        }

        [Test]
        public void Execute_NormalisesLowercaseInstructions()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(1, 1), Direction.Up, wall);

            var factory = new CommandFactory(spider, new NullLogger());
            var processor = new CommandProcessor(factory);

            // Act
            processor.Execute("ffr");

            // Assert
            Assert.That(spider.Position, Is.EqualTo(new Position(1, 3)));
            Assert.That(spider.Direction, Is.EqualTo(Direction.Right));
        }

        [Test]
        public void Execute_InvalidInstruction_Throws()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(1, 1), Direction.Up, wall);

            var factory = new CommandFactory(spider, new NullLogger());
            var processor = new CommandProcessor(factory);

            // Act + Assert
            Assert.Throws<ArgumentException>(() => processor.Execute("FX"));
        }
    }
}
