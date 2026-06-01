using System.Diagnostics;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1;
using Study.LabWork2.Abstractions.Feature.Task1.SubTask1.DtoModels;

namespace Study.LabWork2.Feature.Task1.SubTask1;

/// <summary>
/// Версия 2. Использует Mutex для синхронизации
/// </summary>
public sealed class MutexService : IPrimeCounter
{
    public PrimeCountResultDto CountPrimes(int start, int end, int threadCount)
    {
        if (start > end) throw new ArgumentException("start must be <= end");
        if (threadCount <= 0) throw new ArgumentException("threadCount must be positive");

        int primeCount = 0;
        var foundPrimes = new List<int>();
        using var mutex = new Mutex();

        var threads = CreateThreads(start, end, threadCount, (rangeStart, rangeEnd, threadId) =>
        {
            for (int num = rangeStart; num <= rangeEnd; num++)
            {
                Console.WriteLine($"Поток {threadId}: проверяю число {num}");

                if (PrimeChecker.IsPrime(num))
                {
                    Console.WriteLine($"Поток {threadId}: число {num} ПРОСТОЕ");
                    mutex.WaitOne();
                    try
                    {
                        primeCount++;
                        foundPrimes.Add(num);
                    }
                    finally
                    {
                        mutex.ReleaseMutex();
                    }
                }
            }
        });

        var sw = Stopwatch.StartNew();
        StartAndJoinThreads(threads);
        sw.Stop();

        return new PrimeCountResultDto
        {
            PrimeCount = primeCount,
            ExecutionTime = sw.Elapsed,
            ThreadCount = threadCount,
            SynchronizationType = GetVersionName(),
            FoundPrimes = foundPrimes
        };
    }

    public string GetVersionName() => "Mutex";

    private static Thread[] CreateThreads(int start, int end, int threadCount, Action<int, int, int> action)
    {
        var threads = new Thread[threadCount];
        int totalNumbers = end - start + 1;
        int numbersPerThread = totalNumbers / threadCount;
        int remainder = totalNumbers % threadCount;

        int currentStart = start;
        for (int i = 0; i < threadCount; i++)
        {
            int threadStart = currentStart;
            int threadEnd = currentStart + numbersPerThread - 1;
            if (i == threadCount - 1)
                threadEnd += remainder;

            int threadId = i + 1;
            threads[i] = new Thread(() => action(threadStart, threadEnd, threadId));

            currentStart = threadEnd + 1;
        }
        return threads;
    }

    private static void StartAndJoinThreads(Thread[] threads)
    {
        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();
    }
}
