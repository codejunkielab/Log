namespace Tandbox.Log;

using System;

/// <summary>
/// Log class.
/// This class is not thread-safe.
/// </summary>
public sealed class Log {
  private string _name;
  private ILogFactory _factory;
  private ILogFormatter _formatter;
  private ILogWriter _writer;

  public string Name => _name;
  public bool IsDebugEnabled => IsEnabled(Level.Debug);
  public bool IsInfoEnabled => IsEnabled(Level.Info);
  public bool IsWarnEnabled => IsEnabled(Level.Warn);
  public bool IsErrorEnabled => IsEnabled(Level.Error);
  public bool IsFatalEnabled => IsEnabled(Level.Fatal);

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
  /// Debug level log information.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Debug(string message) {
    if (_writer == null || !IsDebugEnabled)
      return;

    _writer.Debug(_formatter.FormatMessage(_name, Level.Debug, message));
  }

  /// <summary>
  /// Info level log information.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Info(string message) {
    if (_writer == null || !IsInfoEnabled)
      return;

    _writer.Info(_formatter.FormatMessage(_name, Level.Info, message));
  }

  /// <summary>
  /// Warn level log information.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Warn(string message) {
    if (_writer == null || !IsWarnEnabled)
      return;

    _writer.Warn(_formatter.FormatMessage(_name, Level.Warn, message));
  }

  /// <summary>
  /// Error level log information.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Error(string message) {
    if (_writer == null || !IsErrorEnabled)
      return;

    _writer.Error(_formatter.FormatMessage(_name, Level.Error, message));
  }

  /// <summary>
  /// Fatal level log information.
  /// </summary>
  /// <param name="message">The message to log.</param>
  public void Fatal(string message) {
    if (_writer == null || !IsFatalEnabled)
      return;

    _writer.Fatal(_formatter.FormatMessage(_name, Level.Fatal, message));
  }

  private bool IsEnabled(Level level) {
    return level >= _factory.Level;
  }
}