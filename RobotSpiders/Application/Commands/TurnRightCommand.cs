using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application.Commands
{
    /// <summary>
    ///  Command that rotates the spider 90 degrees to the right without changing its current position.
    /// </summary>
    public sealed class TurnRightCommand : ICommand
    {
        private readonly Spider _spider;
        public TurnRightCommand(Spider spider) => _spider = spider;
        public void Execute() => _spider.TurnRight();
    }
}
