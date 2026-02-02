using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Domain
{
    public class SpiderTests
    {
        [Test]
        public void MoveForward_InsideBounds_Moves()
        {
            var wall = new Wall(10, 10);
            var spider = new Spider(new Position(2, 2), Direction.Up, wall);

            spider.MoveForward();

            Assert.That(spider.Position, Is.EqualTo(new Position(2, 3)));
        }

        [Test]
        public void MoveForward_OutsideBounds_DoesNotMove()
        {
            var wall = new Wall(0, 0);
            var spider = new Spider(new Position(0, 0), Direction.Up, wall);

            spider.MoveForward();

            Assert.That(spider.Position, Is.EqualTo(new Position(0, 0)));
        }

        [TestCase(Direction.Up, Direction.Left)]
        [TestCase(Direction.Right, Direction.Up)]
        [TestCase(Direction.Down, Direction.Right)]
        [TestCase(Direction.Left, Direction.Down)]
        public void TurnLeft_WrapsCorrectly(Direction start, Direction expected)
        {
            var wall = new Wall(10, 10);
            var spider = new Spider(new Position(0, 0), start, wall);

            spider.TurnLeft();

            Assert.That(spider.Direction, Is.EqualTo(expected));
        }

        [TestCase(Direction.Up, Direction.Right)]
        [TestCase(Direction.Right, Direction.Down)]
        [TestCase(Direction.Down, Direction.Left)]
        [TestCase(Direction.Left, Direction.Up)]
        public void TurnRight_WrapsCorrectly(Direction start, Direction expected)
        {
            var wall = new Wall(10, 10);
            var spider = new Spider(new Position(0, 0), start, wall);

            spider.TurnRight();

            Assert.That(spider.Direction, Is.EqualTo(expected));
        }

    }
}
