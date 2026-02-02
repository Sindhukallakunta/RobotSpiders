using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application.Logging
{
    /// <summary>
    /// Defines a minimal logging abstraction used to record application and diagnostic messages
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
    }
}
