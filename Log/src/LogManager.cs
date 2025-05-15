namespace Tandbox.Log;

using System;

public static class LogManager {
  private static readonly ILogFactory _defaultFactory = new ConsoleLogFactory();
  private static ILogFactory _factory = default!;

  public static Log GetLogger(Type type) {
    if (_factory != null)
      return _factory.GetLogger(type);

    return _defaultFactory.GetLogger(type);
  }

  public static Log GetLogger<T>() {
    if (_factory != null)
      return _factory.GetLogger(typeof(T));

    return _defaultFactory.GetLogger(typeof(T));
  }

  public static Log GetLogger(string name) {
    if (_factory != null)
      return _factory.GetLogger(name);

    return _defaultFactory.GetLogger(name);
  }

  public static void Registry(ILogFactory factory) {
    if (_factory != null && _factory != factory)
      throw new Exception("Don't register log factory many times");

    _factory = factory;
  }
}