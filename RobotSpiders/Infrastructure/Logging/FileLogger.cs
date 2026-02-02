using RobotSpiders.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Infrastructure.Logging
{
    /// <summary>Thread-safe file logger.</summary>
    public sealed class FileLogger : ILogger
    {
        private readonly string _path;
        private readonly object _lock = new();

        public FileLogger(string path) => _path = path;

        public void Log(string message)
        {
            lock (_lock)
            {
                File.AppendAllText(
                    _path,
                    $"{DateTime.UtcNow:O} - {message}{Environment.NewLine}",
                    Encoding.UTF8);
            }
        }
    }
}
