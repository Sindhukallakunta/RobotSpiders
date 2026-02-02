using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotSpiders.Application.Input
{
    /// <summary>
    /// Provides helper methods for parsing required primitive values from raw input and enforcing fail-fast validation rules.
    /// </summary>
    public static class InputValueParser
    {
        /// <summary>
        /// Parses a required integer value from the provided input string. Throws an exception if the value is missing or not a valid number.
        /// </summary>
        /// <param name="value">The raw input value to parse</param>
        /// <param name="fieldName">The logical name of the field being parsed, used for error messages</param>
        /// <returns>The parsed integer value</returns>
        /// <exception cref="ArgumentException">Thrown when the input is null, empty, or not a valid integer</exception>
        public static int ParseRequiredInt(string? value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException($"{fieldName} is required"); ;

            if (!int.TryParse(value, out var result))
                throw new ArgumentException(
                    $"Invalid numeric value for {fieldName}: '{value}'");

            return result;
        }
    }
}
