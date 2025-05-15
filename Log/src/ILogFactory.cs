namespace Tandbox.Log;

using System;

public interface ILogFactory {
  Level Level { get; set; }

  Log GetLogger<T>();

  Log GetLogger(Type type);

  Log GetLogger(string name);
}