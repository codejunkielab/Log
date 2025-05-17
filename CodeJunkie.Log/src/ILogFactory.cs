namespace CodeJunkie.Log;

using System;

/// <summary>
/// Defines a factory interface for creating loggers.
/// </summary>
public interface ILogFactory {
  /// <summary>
  /// Gets or sets the logging level.
  /// </summary>
  Level Level { get; set; }

  /// <summary>
  /// Retrieves a logger for the specified generic type.
  /// </summary>
  /// <typeparam name="T">The generic type for which the logger is to be retrieved.</typeparam>
  /// <returns>A <see cref="Log"/> instance for the specified generic type.</returns>
  Log GetLogger<T>();

  /// <summary>
  /// Retrieves a logger for the specified type.
  /// </summary>
  /// <param name="type">The type for which the logger is to be retrieved.</param>
  /// <returns>A <see cref="Log"/> instance for the specified type.</returns>
  Log GetLogger(Type type);

  /// <summary>
  /// Retrieves a logger with the specified name.
  /// </summary>
  /// <param name="name">The name of the logger to retrieve.</param>
  /// <returns>A <see cref="Log"/> instance with the specified name.</returns>
  Log GetLogger(string name);
}
