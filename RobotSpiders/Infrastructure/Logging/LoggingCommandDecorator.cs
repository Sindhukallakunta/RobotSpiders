using RobotSpiders.Application.Commands;
using RobotSpiders.Application.Logging;
using RobotSpiders.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Infrastructure.Logging
{
    /// <summary>
    /// Decorator capturing behavioural telemetry without polluting domain or execution logic.
    /// </summary>
    public sealed class LoggingCommandDecorator : ICommand
    {
        private readonly ICommand _inner;
        private readonly ILogger _logger;
        private readonly char _instruction;
        private readonly Spider _spider;

        public LoggingCommandDecorator(
            ICommand inner, ILogger logger, char instruction, Spider spider)
        {
            _inner = inner;
            _logger = logger;
            _instruction = instruction;
            _spider = spider;
        }

        public void Execute()
        {
            _logger.Log($"Before {_instruction}: {_spider.Position} {_spider.Direction}");
            _inner.Execute();
            _logger.Log($"After  {_instruction}: {_spider.Position} {_spider.Direction}");
        }
    }
}
