using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Domain
{
    /// <summary>Defines navigable boundaries.</summary>
    public sealed class Wall
    {
        public int MaxX { get; }
        public int MaxY { get; }

        public Wall(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }

        public bool IsInside(Position p) =>
            p.X >= 0 && p.Y >= 0 && p.X <= MaxX && p.Y <= MaxY;
    }
}
