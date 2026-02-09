// With the help of CoPilot, I created a SoftAssert class that allows me to log multiple assertion failures 
// without throwing an exception immediately. 
// This way, I can collect all the errors and report them at the end of the test, 
// which is especially useful for UI tests where multiple elements might fail to meet the expected conditions.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Automation.Tests.Helpers
{
    public class SoftAssert
    {
        private readonly List<string> _errors = new();

        /// <summary>
        /// Asserts that a condition is true. If false, logs the error without throwing.
        /// </summary>
        public void AssertTrue(bool condition, string message)
        {
            if (!condition)
                _errors.Add($"❌ Expected true but was false: {message}");
        }

        /// <summary>
        /// Asserts that two values are equal. If not, logs the error without throwing.
        /// </summary>
        public void AssertEqual<T>(T expected, T actual, string message)
        {
            if (!EqualityComparer<T>.Default.Equals(expected, actual))
                _errors.Add($"❌ Expected: {expected}, Actual: {actual}. {message}");
        }

        /// <summary>
        /// Asserts that a string contains a substring. If not, logs the error without throwing.
        /// </summary>
        public void AssertContains(string substring, string fullString, string message)
        {
            if (fullString == null || !fullString.Contains(substring))
                _errors.Add($"❌ Expected '{fullString}' to contain '{substring}'. {message}");
        }

        /// <summary>
        /// Record a custom error message.
        /// </summary>
        public void Fail(string message)
        {
            _errors.Add($"❌ {message}");
        }

        /// <summary>
        /// Checks if any errors have been logged.
        /// </summary>
        public bool HasErrors() => _errors.Any();

        /// <summary>
        /// Returns the count of logged errors.
        /// </summary>
        public int ErrorCount() => _errors.Count;

        /// <summary>
        /// Get all errors as a single string.
        /// </summary>
        public string GetErrorsSummary() => string.Join(Environment.NewLine, _errors);

        /// <summary>
        /// Throws an exception if any errors have been logged. Used at the end of a test.
        /// </summary>
        public void AssertAll()
        {
            if (_errors.Any())
            {
                var allErrors = string.Join(Environment.NewLine, _errors);
                var summary = $"Soft assertions failed ({_errors.Count} error{(_errors.Count == 1 ? "" : "s")}):{Environment.NewLine}{allErrors}";
                throw new Exception(summary);
            }
        }

        /// <summary>
        /// Clear all logged errors.
        /// </summary>
        public void Clear()
        {
            _errors.Clear();
        }
    }
}
