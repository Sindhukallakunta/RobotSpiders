using RobotSpiders.Application.Logging;
using RobotSpiders.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Tests.UnitTests.Infrastructure.Logging
{
    public class FileLoggerTests
    {
        [Test]
        public void FileLogger_WritesToFile()
        {
            var path = Path.Combine(Path.GetTempPath(), $"spider_{Guid.NewGuid():N}.log");

            try
            {
                ILogger logger = new FileLogger(path);
                logger.Log("hello");

                Assert.That(File.Exists(path), Is.True);
                Assert.That(File.ReadAllText(path), Does.Contain("hello"));
            }
            finally
            {
                if (File.Exists(path)) File.Delete(path);
            }
        }
    }
}
