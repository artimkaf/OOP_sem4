using Study.LabWork1.Features.Task2;
using Study.LabWork1.Shared.Abstractions;

namespace Study.LabWork1.Shared.Services;

/// <summary>
/// Реализация заданий Л/Р
/// </summary>
public class RunService : IRunService
{
    /// <summary>
    /// Задание 1
    /// </summary>
    public void RunTask1() => throw new NotImplementedException();

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2()
    {
        ILogger consoleLogger = LoggerFactory.CreateLogger(LoggerType.Console);
        ILogger fileLogger = LoggerFactory.CreateLogger(LoggerType.File, "application.log");
        ILogger serverLogger = LoggerFactory.CreateLogger(LoggerType.Server);

        // Логируем сообщения
        consoleLogger.Log("Приложение запущено");
        fileLogger.Log("Пользователь нажал кнопку");
        serverLogger.Log("Не удалось подключиться к БД");
    }

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
