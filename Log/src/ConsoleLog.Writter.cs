namespace Tandbox.Log;

using System;
using System.Diagnostics.CodeAnalysis;

[ExcludeFromCodeCoverage(Justification = "Console output is untestable")]
public sealed class ConsoleLogWriter : ILogWriter {
  public void Debug(object message) {
    Console.WriteLine(message);
  }

  public void Info(object message) {
    Console.WriteLine(message);
  }

  public void Warn(object message) {
    Console.WriteLine(message);
  }

  public void Error(object message) {
    Console.Error.WriteLine(message);
  }

  public void Fatal(object message) {
    Console.Error.WriteLine(message);
  }
}