using System;

namespace Programming;

public class MyPow
{
    public double MyPowImp(double x, long n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n == 1)
        {
            return x;
        }

        if (x == 1.0)
        {
            return 1;
        }

        long absN = Math.Abs(n);
        double pow = MyPowRec(x, absN);
        return n > 0 ? pow : 1.0 / pow;
    }

    public double MyPowRec(double x, long n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n == 1)
        {
            return x;
        }

        if (n == 2)
        {
            return x * x;
        }

        double extra = 1;
        if (n % 2 != 0)
        {
            extra = x;
            n--;
        }

        double pow = MyPowRec(x * x, n / 2);
        return pow * extra;
    }
}
