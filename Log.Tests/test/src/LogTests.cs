namespace Tandbox.Log.Tests;

using Tandbox.Log;
using LightMock;
using LightMock.Generator;
using Shouldly;
using Xunit;

public class LogTests {
  private readonly Mock<ILogFactory> _mockLogFactory;
  private readonly Mock<ILogFormatter> _mockLogFormatter;
  private readonly Mock<ILogWriter> _mockLogWriter;
  private readonly Log _log;

  public LogTests() {
    _mockLogFactory = new Mock<ILogFactory>();
    _mockLogFormatter = new Mock<ILogFormatter>();
    _mockLogWriter = new Mock<ILogWriter>();

    _log = new Log("TestLogger", _mockLogFactory.Object, _mockLogFormatter.Object, _mockLogWriter.Object);
  }

  [Fact]
  public void Constructor_ShouldInitializeProperties() {
    _log.Name.ShouldBe("TestLogger");
  }

  [Fact]
  public void IsDebugEnabled_ShouldReturnFalse_WhenLevelIsOff() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.All);
    Assert.True(_log.IsDebugEnabled);
    Assert.True(_log.IsInfoEnabled);
    Assert.True(_log.IsWarnEnabled);
    Assert.True(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }

  [Fact]
  public void IsDebugEnabled_ShouldReturnTrue_WhenLevelIsDebug() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.Debug);
    Assert.True(_log.IsDebugEnabled);
    Assert.True(_log.IsInfoEnabled);
    Assert.True(_log.IsWarnEnabled);
    Assert.True(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }

  [Fact]
  public void IsInfoEnabled_ShouldReturnTrue_WhenLevelIsInfo() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.Info);
    Assert.False(_log.IsDebugEnabled);
    Assert.True(_log.IsInfoEnabled);
    Assert.True(_log.IsWarnEnabled);
    Assert.True(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }

  [Fact]
  public void IsWarnEnabled_ShouldReturnTrue_WhenLevelIsWarn() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.Warn);
    Assert.False(_log.IsDebugEnabled);
    Assert.False(_log.IsInfoEnabled);
    Assert.True(_log.IsWarnEnabled);
    Assert.True(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }

  [Fact]
  public void IsErrorEnabled_ShouldReturnTrue_WhenLevelIsError() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.Error);
    Assert.False(_log.IsDebugEnabled);
    Assert.False(_log.IsInfoEnabled);
    Assert.False(_log.IsWarnEnabled);
    Assert.True(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }

  [Fact]
  public void IsFatalEnabled_ShouldReturnTrue_WhenLevelIsFatal() {
    _mockLogFactory.Arrange(f => f.Level).Returns(Level.Fatal);
    Assert.False(_log.IsDebugEnabled);
    Assert.False(_log.IsInfoEnabled);
    Assert.False(_log.IsWarnEnabled);
    Assert.False(_log.IsErrorEnabled);
    Assert.True(_log.IsFatalEnabled);
  }
}