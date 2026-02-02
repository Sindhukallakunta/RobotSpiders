using RobotSpiders.Application.Commands;
using RobotSpiders.Application.Logging;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application
{
    /// <summary>
    /// Centralises command creation and cross-cutting concerns.Fails fast on invalid instructions for deterministic behaviour.
    /// </summary>
    public sealed class CommandFactory
    {
        private readonly Spider _spider;
        private readonly ILogger _logger;

        public CommandFactory(Spider spider, ILogger logger)
        {
            _spider = spider;
            _logger = logger;
        }

        public ICommand Create(char instruction)
        {
            ICommand baseCommand = instruction switch
            {
                'F' => new MoveForwardCommand(_spider),
                'L' => new TurnLeftCommand(_spider),
                'R' => new TurnRightCommand(_spider),
                _ => throw new ArgumentException($"Invalid instruction: {instruction}")
            };

            return new LoggingCommandDecorator(baseCommand, _logger, instruction, _spider);
        }
    }
}
