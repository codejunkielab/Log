namespace CodeJunkie.Log;

using System;
using System.Diagnostics.CodeAnalysis;

/// <summary>
/// A log writer that outputs log messages to the console.
/// </summary>
[ExcludeFromCodeCoverage]
public sealed class ConsoleLogWriter : ILogWriter {
  /// <summary>
  /// Writes a debug-level message to the console.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Debug(object message) {
    Console.WriteLine(message);
  }

  /// <summary>
  /// Writes an info-level message to the console.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Info(object message) {
    Console.WriteLine(message);
  }

  /// <summary>
  /// Writes a warning-level message to the console.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Warn(object message) {
    Console.WriteLine(message);
  }

  /// <summary>
  /// Writes an error-level message to the console error stream.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Error(object message) {
    Console.Error.WriteLine(message);
  }

  /// <summary>
  /// Writes a fatal-level message to the console error stream.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Fatal(object message) {
    Console.Error.WriteLine(message);
  }
}
