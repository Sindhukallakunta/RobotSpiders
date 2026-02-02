using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Domain
{
    /// <summary>
    /// Autonomous agent that owns its state and movement rules.
    /// </summary>
    public sealed class Spider
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        private readonly Wall _wall;

        public Spider(Position position, Direction direction, Wall wall)
        {
            Position = position;
            Direction = direction;
            _wall = wall;
        }

        public void TurnLeft() =>
            Direction = (Direction)(((int)Direction + 3) % 4);

        public void TurnRight() =>
            Direction = (Direction)(((int)Direction + 1) % 4);

        public void MoveForward()
        {
            var next = Direction switch
            {
                Direction.Up => Position with { Y = Position.Y + 1 },
                Direction.Right => Position with { X = Position.X + 1 },
                Direction.Down => Position with { Y = Position.Y - 1 },
                Direction.Left => Position with { X = Position.X - 1 },
                _ => Position
            };

            if (_wall.IsInside(next))
                Position = next;
        }
    }
}
