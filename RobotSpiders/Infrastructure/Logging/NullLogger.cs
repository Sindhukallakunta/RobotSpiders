using RobotSpiders.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Infrastructure.Logging
{
    /// <summary>
    /// A no-op logger implementation that intentionally performs no logging.Used to disable logging without introducing conditional logic in application
    /// </summary>
    public sealed class NullLogger : ILogger
    {
        public void Log(string message) { }
    }
}
