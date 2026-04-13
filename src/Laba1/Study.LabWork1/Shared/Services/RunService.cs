using System.Security.AccessControl;
using System.Xml.Linq;
using Study.LabWork1.Features.Task1;
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
    public void RunTask1()
    {
        Console.WriteLine("Введите числитель: ");
        int numerator = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите знаменатель: ");
        int denomirator = int.Parse(Console.ReadLine());

        var rationalNumber = new RationalNumbers(numerator, denomirator);
        Console.WriteLine($"Ответ: {rationalNumber}");
    }

    /// <summary>
    /// Задание 2
    /// </summary>
    public void RunTask2() => throw new NotImplementedException();

    /// <summary>
    /// Задание 3
    /// </summary>
    public void RunTask3() => throw new NotImplementedException();
}
