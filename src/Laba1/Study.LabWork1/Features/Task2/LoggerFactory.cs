using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace Study.LabWork1.Features.Task2
{
    public enum LoggerType
    {
        Console,
        File,
        Server
    }

    public static class LoggerFactory
    {
        public static ILogger CreateLogger(LoggerType type, string? path = "app.log", string? url = null)
        {
            return type switch
            {
                LoggerType.Console => new ConsoleLogger(),
                LoggerType.File => new FileLogger(path),
                LoggerType.Server => new ServerLogger(url),
                _ => throw new ArgumentException($"Неизвестный тип логгера: {type}")
            };
        }
    }
}
