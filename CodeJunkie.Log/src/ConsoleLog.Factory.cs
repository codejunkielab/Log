namespace CodeJunkie.Log;

using System;
using System.Collections.Generic;

/// <summary>
/// Factory class for creating and managing console-based loggers.
/// </summary>
public class ConsoleLogFactory : ILogFactory {
  private readonly Dictionary<string, Log> _repositories = new();
  private Level _level = Level.All;

  /// <summary>
  /// Initializes a new instance of the <see cref="ConsoleLogFactory"/> class.
  /// </summary>
  public ConsoleLogFactory() { }

  /// <inheritdoc/>
  Level ILogFactory.Level {
    get => _level;
    set => _level = value;
  }

  /// <summary>
  /// Retrieves a logger instance for the specified generic type.
  /// </summary>
  /// <typeparam name="T">The type for which the logger is created.</typeparam>
  /// <returns>A <see cref="Log"/> instance associated with the specified type.</returns>
  Log ILogFactory.GetLogger<T>() {
    var type = typeof(T);
    var fullName =
      type.FullName
      ?? throw new ArgumentException("Type.FullName must not be null", nameof(type));
    return GetOrCreateLogger(fullName, type.Name);
  }

  /// <summary>
  /// Retrieves a logger instance for the specified type.
  /// </summary>
  /// <param name="type">The type for which the logger is created.</param>
  /// <returns>A <see cref="Log"/> instance associated with the specified type.</returns>
  Log ILogFactory.GetLogger(Type type) {
    var fullName = type.FullName
                   ?? throw new ArgumentException("Type.FullName must not be null", nameof(type));
    return GetOrCreateLogger(fullName, type.Name);
  }

  /// <summary>
  /// Retrieves a logger instance for the specified name.
  /// </summary>
  /// <param name="name">The name of the logger.</param>
  /// <returns>A <see cref="Log"/> instance associated with the specified name.</returns>
  Log ILogFactory.GetLogger(string name) {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("name must not be null or whitespace", nameof(name));
    return GetOrCreateLogger(name, name);
  }

  private Log GetOrCreateLogger(string key, string displayName) {
    if (_repositories.TryGetValue(key, out var existing))
      return existing;

    var log = new Log(
      name: displayName,
      logFactory: this,
      logFormatter: new DefaultLogFormatter(),
      logWriter: new ConsoleLogWriter());

    _repositories[key] = log;
    return log;
  }
}
