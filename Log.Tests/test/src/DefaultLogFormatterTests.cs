namespace Tandbox.Log.Tests;

using Tandbox.Log;
using Shouldly;
using System;
using System.Text.RegularExpressions;
using Xunit;

public class DefaultLogFormatterTests {
  private readonly ILogFormatter _formatter = new DefaultLogFormatter();

  private static readonly Regex _logPattern = new(
    @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3} \[Info\] TestLogger - Hello World$",
    RegexOptions.Compiled);

  private static readonly Regex _logPatternWithException = new(
    @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}\.\d{3} \[Error\] TestLogger - Something went wrong$",
    RegexOptions.Compiled);

  [Fact]
  public void FormatMessage_WithoutException_FormatsCorrectly() {
    var message = _formatter.FormatMessage("TestLogger", Level.Info, "Hello World");

    _logPattern.IsMatch(message).ShouldBeTrue($"Actual message: {message}");
  }

  [Fact]
  public void FormatMessage_WithException_FormatsCorrectly() {
    var ex = new InvalidOperationException("Some error");
    var message = _formatter.FormatMessage("TestLogger", Level.Error, "Something went wrong", ex);

    _logPatternWithException.IsMatch(message).ShouldBeTrue($"Actual message: {message}");
  }
}