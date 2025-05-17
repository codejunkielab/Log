namespace CodeJunkie.Log;

using System;

/// <summary>
/// Optional interface providing log-message formatting to <see cref="Log"/>.
/// </summary>
public sealed class DefaultLogFormatter : ILogFormatter {
  /// <inheritdoc />
  string ILogFormatter.FormatMessage(string logName, Level level, string message) {
    return string.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [{1}] {2} - {3}", System.DateTime.Now, level, logName, message);
  }

  /// <inheritdoc />
  string ILogFormatter.FormatMessage(string logName, Level level, string message, Exception exception) {
    return string.Format("{0:yyyy-MM-dd HH:mm:ss.fff} [{1}] {2} - {3}", System.DateTime.Now, level, logName, message);
  }
}
