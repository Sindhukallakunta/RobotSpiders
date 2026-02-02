using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Infrastructure.Logging
{
    public class BootStrapLoggerTests
    {
        [Test]
        public void BootstrapLogger_Log_DoesNotThrow()
        {
            Assert.DoesNotThrow(() =>
                BootstrapLogger.Log(new InvalidOperationException("test")));
        }

    }
}
