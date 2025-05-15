namespace Tandbox.Log;

using System;
using System.Collections.Generic;

public class ConsoleLogFactory : ILogFactory {
  private readonly Dictionary<string, Log> _repositories = new();
  private Level _level = Level.All;

  public ConsoleLogFactory() { }

  Level ILogFactory.Level {
    get => _level;
    set => _level = value;
  }

  Log ILogFactory.GetLogger<T>() {
    var type = typeof(T);
    var fullName = type.FullName
                   ?? throw new ArgumentException("Type.FullName must not be null", nameof(type));
    return GetOrCreateLogger(fullName, type.Name);
  }

  Log ILogFactory.GetLogger(Type type) {
    var fullName = type.FullName
                   ?? throw new ArgumentException("Type.FullName must not be null", nameof(type));
    return GetOrCreateLogger(fullName, type.Name);
  }

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