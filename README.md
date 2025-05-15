# Tandbox.Log

The `Log` library provides a flexible and efficient logging framework for .NET applications. It supports multiple log levels, customizable log formats, and various output destinations.

## Installation

Install the latest version of the `Tandbox.Log` package from NuGet:

```sh
dotnet add package Tandbox.Log
```
## Features

- **Multi-Level Logging**: Supports `Debug`, `Info`, `Warn`, `Error`, and `Fatal` log levels.
- **Customizable Log Format**: Easily configure log message formats to suit your needs.
- **Multiple Output Destinations**: Write logs to the console, files, or custom destinations.
- **Thread-Safe Logging**: Ensures safe logging in multi-threaded environments.

## Key Components

### `LogManager`

The central class for managing loggers. Use this to configure and retrieve logger instances.

### `ConsoleLog.Factory`

A factory class for creating console-based loggers.

### `Log`

The main logging class that provides methods for logging messages at various levels.

## Usage

Here is a quick example of how to use the `Log` library:

```csharp
using Tandbox.Log;

class Program
{
    static void Main(string[] args)
    {
        // Initialize the LogManager
        LogManager.Registry(new ConsoleLog.Factory());

        // Get a logger instance
        var logger = LogManager.GetLogger("ExampleLogger");

        // Log messages at different levels
        logger.Debug("This is a debug message.");
        logger.Info("This is an info message.");
        logger.Warn("This is a warning message.");
        logger.Error("This is an error message.");
        logger.Fatal("This is a fatal error message.");
    }
}
```

## Namespace

Tandbox.Log
