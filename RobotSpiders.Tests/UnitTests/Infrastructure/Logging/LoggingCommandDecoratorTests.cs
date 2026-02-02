using Moq;
using RobotSpiders.Application.Commands;
using RobotSpiders.Application.Logging;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Infrastructure.Logging
{
    public class LoggingCommandDecoratorTests
    {
        [Test]
        public void Execute_LogsBeforeAndAfter_UsingMockLogger()
        {
            // Arrange
            var wall = new Wall(5, 5);
            var spider = new Spider(new Position(1, 1), Direction.Up, wall);

            ICommand innerCommand = new MoveForwardCommand(spider);

            var loggerMock = new Mock<ILogger>();

            var decorator = new LoggingCommandDecorator(
                innerCommand,
                loggerMock.Object,
                'F',
                spider);

            // Act
            decorator.Execute();

            // Assert
            loggerMock.Verify(
                l => l.Log(It.Is<string>(s => s.Contains("Before F"))),
                Times.Once);

            loggerMock.Verify(
                l => l.Log(It.Is<string>(s => s.Contains("After  F"))),
                Times.Once);
        }
    }
}
