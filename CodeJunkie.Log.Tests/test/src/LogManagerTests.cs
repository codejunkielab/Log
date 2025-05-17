namespace CodeJunkie.Log.Tests;

using CodeJunkie.Log;
using LightMock;
using LightMock.Generator;
using Shouldly;
using System;
using Xunit;

public class LogManagerTests {
  private Mock<ILogFactory> _mockFactory;

  public LogManagerTests() {
    _mockFactory = new Mock<ILogFactory>();

    LogManager.Registry(null!); // Factoryをnullにして、デフォルトのFactoryを使用
  }

  [Fact]
  public void GetLogger_ShouldReturnLogger_WhenFactoryIsRegistered() {
    Type loggerType = typeof(LogManagerTests);

    var logger = LogManager.GetLogger(loggerType);

    Assert.NotNull(logger);
    logger.Name.ShouldBe(loggerType.Name);
  }

  [Fact]
  public void GetLogger_ShouldReturnLogger_WhenFactoryIsNotRegistered() {
    var logger = LogManager.GetLogger(typeof(LogManagerTests));

    Assert.NotNull(logger);
    logger.Name.ShouldBe(typeof(LogManagerTests).Name);
  }
}
