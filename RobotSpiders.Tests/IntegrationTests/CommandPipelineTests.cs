using RobotSpiders.Application;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.IntegrationTests
{
    public class CommandPipelineTests
    {
        [Test]
        public void FullPipeline_ProducesExpectedResult()
        {
            var wall = new Wall(7, 15);
            var spider = new Spider(new Position(2, 4), Direction.Left, wall);

            var processor = new CommandProcessor(
                new CommandFactory(spider, new NullLogger()));

            processor.Execute("flflfrfflf"); // lowercase input

            Assert.That(spider.Position.X, Is.EqualTo(3));
            Assert.That(spider.Position.Y, Is.EqualTo(1));
            Assert.That(spider.Direction, Is.EqualTo(Direction.Right));
        }

        [Test]
        public void FullPipeline_WhenMoveWouldExitWall_ShouldNotThrow()
        {
            var wall = new Wall(7, 7);
            var spider = new Spider(new Position(5, 5), Direction.Right, wall);

            var processor = new CommandProcessor(
                new CommandFactory(spider, new NullLogger()));

            processor.Execute("FFFRFFLF"); 

            Assert.That(spider.Position.X, Is.EqualTo(7));
            Assert.That(spider.Position.Y, Is.EqualTo(3));
            Assert.That(spider.Direction, Is.EqualTo(Direction.Right));
        }
    }
}
