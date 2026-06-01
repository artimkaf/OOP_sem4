using System.Collections.Generic;
using System.Text;
using System;

namespace Study.LabWork2.Feature.Task1.SubTask1;

public static class PrimeChecker
{
    public static bool IsPrime(int n)
    {
        if (n < 2) return false;
        if (n == 2) return true;
        if (n % 2 == 0) return false;

        int limit = (int)Math.Sqrt(n);
        for (int d = 3; d <= limit; d += 2)
            if (n % d == 0) return false;

        return true;
    }
}
