using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Infrastructure.Logging
{
    /// <summary>
    /// Provides a last-resort logging mechanism for capturing
    /// fatal errors during application startup or early failure scenarios
    /// when the standard logging infrastructure is unavailable.
    /// </summary>
    public static class BootstrapLogger
    {
        private static readonly string _path =
            Path.Combine(AppContext.BaseDirectory, "fatal.log");
        /// <summary>
        /// Attempts to log a fatal exception to a local file.
        /// Logging failures are swallowed to ensure the application
        /// does not crash due to logging errors.
        /// </summary>
        /// <param name="ex">The exception to be logged</param>
        public static void Log(Exception ex)
        {
            try
            {
                File.AppendAllText(
                    _path,
                    $"{DateTime.UtcNow:u} | FATAL | {ex}\n"
                );
            }
            catch
            {
                Console.WriteLine( ex );
            }
        }
    }
}
