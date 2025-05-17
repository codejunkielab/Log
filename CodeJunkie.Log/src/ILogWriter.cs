namespace CodeJunkie.Log;

using System;

/// <summary>
/// The ILogWriter interface is use by application to log messages into the Loxodon.Log framework.
/// </summary>
/// <example>Simple example of logging messages
/// <code lang="C#">
/// ILogWriter log = LogManager.GetLogger("application-log");
///
/// log.Info("Application Start");
/// log.Debug("This is a debug message");
///
/// if (log.IsDebugEnabled) {
///		log.Debug("This is another debug message");
/// }
/// </code>
/// </example>
public interface ILogWriter {
  /// <summary>
  /// Debug level log information.
  /// </summary>
  void Debug(object message);

  /// <summary>
  /// Info level log information.
  /// </summary>
  void Info(object message);

  /// <summary>
  /// Warn level log information.
  /// </summary>
  void Warn(object message);

  /// <summary>
  /// Error level log information.
  /// </summary>
  void Error(object message);

  /// <summary>
  /// Fatal level log information.
  /// </summary>
  void Fatal(object message);
}
