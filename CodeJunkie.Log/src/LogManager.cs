namespace CodeJunkie.Log;

using System;

/// <summary>
/// Provides methods to manage and retrieve loggers.
/// </summary>
public static class LogManager {
  private static readonly ILogFactory _defaultFactory = new ConsoleLogFactory();
  private static ILogFactory _factory = default!;

  /// <summary>
  /// Retrieves a logger for the specified type.
  /// </summary>
  /// <param name="type">The type for which the logger is to be retrieved.</param>
  /// <returns>A <see cref="Log"/> instance for the specified type.</returns>
  public static Log GetLogger(Type type) {
    if (_factory != null)
      return _factory.GetLogger(type);

    return _defaultFactory.GetLogger(type);
  }

  /// <summary>
  /// Retrieves a logger for the specified generic type.
  /// </summary>
  /// <typeparam name="T">The generic type for which the logger is to be retrieved.</typeparam>
  /// <returns>A <see cref="Log"/> instance for the specified generic type.</returns>
  public static Log GetLogger<T>() {
    if (_factory != null)
      return _factory.GetLogger(typeof(T));

    return _defaultFactory.GetLogger(typeof(T));
  }

  /// <summary>
  /// Retrieves a logger with the specified name.
  /// </summary>
  /// <param name="name">The name of the logger to retrieve.</param>
  /// <returns>A <see cref="Log"/> instance with the specified name.</returns>
  public static Log GetLogger(string name) {
    if (_factory != null)
      return _factory.GetLogger(name);

    return _defaultFactory.GetLogger(name);
  }

  /// <summary>
  /// Registers a custom log factory to be used by the LogManager.
  /// </summary>
  /// <param name="factory">The log factory to register.</param>
  /// <exception cref="ArgumentException">Thrown if a factory is already registered and it is not the same as the provided factory.</exception>
  public static void Registry(ILogFactory factory) {
    if (_factory != null && _factory != factory)
      throw new ArgumentException("LogManager already has a factory registered.");

    _factory = factory;
  }

  /// <summary>
  /// Resets the LogManager to its default state, removing any custom factory that has been registered.
  /// </summary>
  public static void Reset() {
    _factory = default!;
  }
}
