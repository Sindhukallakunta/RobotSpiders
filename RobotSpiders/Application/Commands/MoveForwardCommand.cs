using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application.Commands
{
    /// <summary>
    /// Command that moves the spider forward by one grid unit in its current direction, if the move is within bounds.
    /// </summary>
    public sealed class MoveForwardCommand : ICommand
    {
        private readonly Spider _spider;
        public MoveForwardCommand(Spider spider) => _spider = spider;
        public void Execute() => _spider.MoveForward();
    }
}
