using Study.LabWork2.Feature.Task1.SubTask1;

namespace Study.LabWork2;

public static class Program
{
    public static void Main()
    {
        int start = 1;
        int end = 10000;
        int threadCount = 4;

        var monitor = new MonitorService();
        var resultMonitor = monitor.CountPrimes(start, end, threadCount);
        Console.WriteLine(resultMonitor.ToString());
        Console.WriteLine();

        var mutex = new MutexService();
        var resultMutex = mutex.CountPrimes(start, end, threadCount);
        Console.WriteLine(resultMutex.ToShortString());
        Console.WriteLine();

        var semaphore = new SemaphoreService();
        var resultSemaphore = semaphore.CountPrimes(start, end, threadCount);
        Console.WriteLine(resultSemaphore.ToShortString());
    }
}
