namespace CodeJunkie.Log.Tests;

using CodeJunkie.Log;
using Shouldly;
using System;
using System.Text.RegularExpressions;
using Xunit;

public partial class DefaultLogFormatterTests {
  private readonly ILogFormatter _formatter = new DefaultLogFormatter();

  [GeneratedRegex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3} \[Info\] TestLogger - Hello World$")]
  private static partial Regex LogPattern();

  [GeneratedRegex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3} \[Error\] TestLogger - Something went wrong$")]
  private static partial Regex LogPatternWithException();

  [Fact]
  public void FormatMessage_WithoutException_FormatsCorrectly() {
    var message = _formatter.FormatMessage("TestLogger", Level.Info, "Hello World");

    LogPattern().IsMatch(message).ShouldBeTrue($"Actual message: {message}");
  }

  [Fact]
  public void FormatMessage_WithException_FormatsCorrectly() {
    var ex = new InvalidOperationException("Some error");
    var message = _formatter.FormatMessage("TestLogger", Level.Error, "Something went wrong", ex);

    LogPatternWithException().IsMatch(message).ShouldBeTrue($"Actual message: {message}");
  }
}
