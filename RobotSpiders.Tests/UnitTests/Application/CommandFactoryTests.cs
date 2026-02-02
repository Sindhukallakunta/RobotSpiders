using RobotSpiders.Application;
using RobotSpiders.Application.Commands;
using RobotSpiders.Application.Logging;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Application
{
    public class CommandFactoryTests
    {
        private Spider _spider = null!;
        private ILogger _logger = null!;
        private CommandFactory _factory = null!;

        [SetUp]
        public void SetUp()
        {
            var wall = new Wall(5, 5);
            _spider = new Spider(new Position(1, 1), Direction.Up, wall);
            _logger = new NullLogger();
            _factory = new CommandFactory(_spider, _logger);
        }

        [Test]
        public void Create_FInstruction_ReturnsICommand()
        {
            // Act
            var command = _factory.Create('F');

            // Assert
            Assert.That(command, Is.Not.Null);
            Assert.That(command, Is.InstanceOf<ICommand>());
        }

        [Test]
        public void InvalidInstruction_Throws()
        {          

            Assert.Throws<ArgumentException>(() => _factory.Create('X'));
        }
    }
}
