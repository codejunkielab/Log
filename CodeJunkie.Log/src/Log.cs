namespace CodeJunkie.Log;

using System;
using System.Diagnostics;

/// <summary>
/// Represents a logger that provides methods for logging messages at various levels of severity.
/// This class is not thread-safe.
/// </summary>
public sealed class Log {
  private string _name;
  private ILogFactory _factory;
  private ILogFormatter _formatter;
  private ILogWriter _writer;

  /// <summary>
  /// Gets the name of the logger.
  /// </summary>
  public string Name => _name;

  /// <summary>
  /// Gets a value indicating whether debug-level logging is enabled.
  /// </summary>
  public bool IsDebugEnabled => IsEnabled(Level.Debug);

  /// <summary>
  /// Gets a value indicating whether info-level logging is enabled.
  /// </summary>
  public bool IsInfoEnabled => IsEnabled(Level.Info);

  /// <summary>
  /// Gets a value indicating whether warn-level logging is enabled.
  /// </summary>
  public bool IsWarnEnabled => IsEnabled(Level.Warn);

  /// <summary>
  /// Gets a value indicating whether error-level logging is enabled.
  /// </summary>
  public bool IsErrorEnabled => IsEnabled(Level.Error);

  /// <summary>
  /// Gets a value indicating whether fatal-level logging is enabled.
  /// </summary>
  public bool IsFatalEnabled => IsEnabled(Level.Fatal);

  /// <summary>
  /// Initializes a new instance of the <see cref="Log"/> class.
  /// </summary>
  /// <param name="name">The name of the logger.</param>
  /// <param name="logFactory">The factory that created this logger.</param>
  /// <param name="logFormatter">The formatter used to format log messages.</param>
  /// <param name="logWriter">The writer used to output log messages.</param>
  public Log(string name,
             ILogFactory logFactory,
             ILogFormatter logFormatter,
             ILogWriter logWriter) {
    _name = name;
    _factory = logFactory;
    _formatter = logFormatter;
    _writer = logWriter;
  }

  /// <summary>
  /// Logs a debug-level message.
  /// </summary>
  /// <param name="message">The message to log.</param>
  [Conditional("CODEJUNKIE_LOG")]
  [Conditional("CODEJUNKIE_LOG_DEBUG")]
  public void Debug(string message) {
    if (_writer == null || !IsDebugEnabled)
      return;

    _writer.Debug(_formatter.FormatMessage(_name, Level.Debug, message));
  }

  /// <summary>
  /// Logs an info-level message.
  /// </summary>
  /// <param name="message">The message to log.</param>
  [Conditional("CODEJUNKIE_LOG")]
  [Conditional("CODEJUNKIE_LOG_DEBUG")]
  [Conditional("CODEJUNKIE_LOG_INFO")]
  public void Info(string message) {
    if (_writer == null || !IsInfoEnabled)
      return;

    _writer.Info(_formatter.FormatMessage(_name, Level.Info, message));
  }

  /// <summary>
  /// Logs a warn-level message.
  /// </summary>
  /// <param name="message">The message to log.</param>
  [Conditional("CODEJUNKIE_LOG")]
  [Conditional("CODEJUNKIE_LOG_DEBUG")]
  [Conditional("CODEJUNKIE_LOG_INFO")]
  [Conditional("CODEJUNKIE_LOG_WARN")]
  public void Warn(string message) {
    if (_writer == null || !IsWarnEnabled)
      return;

    _writer.Warn(_formatter.FormatMessage(_name, Level.Warn, message));
  }

  /// <summary>
  /// Logs an error-level message.
  /// </summary>
  /// <param name="message">The message to log.</param>
  [Conditional("CODEJUNKIE_LOG")]
  [Conditional("CODEJUNKIE_LOG_DEBUG")]
  [Conditional("CODEJUNKIE_LOG_INFO")]
  [Conditional("CODEJUNKIE_LOG_WARN")]
  [Conditional("CODEJUNKIE_LOG_ERROR")]
  public void Error(string message) {
    if (_writer == null || !IsErrorEnabled)
      return;

    _writer.Error(_formatter.FormatMessage(_name, Level.Error, message));
  }

  /// <summary>
  /// Logs a fatal-level message.
  /// </summary>
  /// <param name="message">The message to log.</param>
  [Conditional("CODEJUNKIE_LOG")]
  [Conditional("CODEJUNKIE_LOG_DEBUG")]
  [Conditional("CODEJUNKIE_LOG_INFO")]
  [Conditional("CODEJUNKIE_LOG_WARN")]
  [Conditional("CODEJUNKIE_LOG_ERROR")]
  [Conditional("CODEJUNKIE_LOG_FATAL")]
  public void Fatal(string message) {
    if (_writer == null || !IsFatalEnabled)
      return;

    _writer.Fatal(_formatter.FormatMessage(_name, Level.Fatal, message));
  }

  /// <summary>
  /// Determines whether logging is enabled for the specified level.
  /// </summary>
  /// <param name="level">The logging level to check.</param>
  /// <returns><c>true</c> if logging is enabled for the specified level; otherwise, <c>false</c>.</returns>
  private bool IsEnabled(Level level) {
    return level >= _factory.Level;
  }
}
