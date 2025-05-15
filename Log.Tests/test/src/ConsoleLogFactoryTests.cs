namespace Tandbox.Log.Tests;

using Tandbox.Log;
using System;
using Shouldly;
using Xunit;

public class ConsoleLogFactoryTests {
  [Fact]
  public void GetLogger_ByType_ReturnsSameInstance_ForSameType() {
    ILogFactory factory = new ConsoleLogFactory();

    var logger1 = factory.GetLogger<ConsoleLogFactoryTests>();
    var logger2 = factory.GetLogger(typeof(ConsoleLogFactoryTests));

    logger1.ShouldBeSameAs(logger2);
    logger1.Name.ShouldBe(nameof(ConsoleLogFactoryTests));
  }

  [Fact]
  public void GetLogger_ByName_ReturnsSameInstance_ForSameName() {
    ILogFactory factory = new ConsoleLogFactory();

    var logger1 = factory.GetLogger("TestLogger");
    var logger2 = factory.GetLogger("TestLogger");

    logger1.ShouldBeSameAs(logger2);
    logger1.Name.ShouldBe("TestLogger");
  }

  [Fact]
  public void GetLogger_ByType_ShouldReturnLogger_WhenFullNameIsNotNull() {
    ILogFactory factory = new ConsoleLogFactory();
    var logger = factory.GetLogger(typeof(ConsoleLogFactoryTests));

    logger.ShouldNotBeNull();
    logger.Name.ShouldBe(nameof(ConsoleLogFactoryTests));
  }

  [Theory]
  [InlineData(null)]
  [InlineData("")]
  [InlineData("   ")]
  public void GetLogger_ByName_ThrowsException_WhenNameIsNullOrWhitespace(string? name) {
    ILogFactory factory = new ConsoleLogFactory();

    var ex = Should.Throw<ArgumentException>(() => factory.GetLogger(name!));
    ex.Message.ShouldContain("name must not be null or whitespace");
  }

  [Fact]
  public void Level_GetterAndSetter_WorksCorrectly() {
    ILogFactory factory = new ConsoleLogFactory();
    factory.Level = Level.Warn;

    factory.Level.ShouldBe(Level.Warn);
  }
}