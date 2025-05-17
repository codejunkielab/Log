namespace CodeJunkie.Log;

/// <summary>
/// Represents the logging levels used to filter log messages.
/// </summary>
public enum Level {
  /// <summary>
  /// Logs all messages, regardless of severity.
  /// </summary>
  All = 0,

  /// <summary>
  /// Logs detailed debugging information, typically used for development.
  /// </summary>
  Debug,

  /// <summary>
  /// Logs informational messages that highlight the progress of the application.
  /// </summary>
  Info,

  /// <summary>
  /// Logs potentially harmful situations that might require attention.
  /// </summary>
  Warn,

  /// <summary>
  /// Logs error events that might still allow the application to continue running.
  /// </summary>
  Error,

  /// <summary>
  /// Logs very severe error events that will presumably lead the application to abort.
  /// </summary>
  Fatal,

  /// <summary>
  /// Disables logging entirely.
  /// </summary>
  Off
}
