using System;

namespace Programming;

public class CalculateWithoutStack
{
    public static int Calculate(string s)
    {
        int res = 0;
        char lastOp = '+';
        int lastNumber = 0;
        char op = '+';
        int index = 0;

        while (index < s.Length)
        {
            char c = s[index];
            if (c == ' ')
            {
                index++;
                continue;
            }

            if (char.IsDigit(c))
            {
                int number = 0;

                while (index < s.Length && char.IsDigit(s[index]))
                {
                    number *= 10;
                    int digit = s[index] - '0';
                    number += digit;
                    index++;
                }

                if (op == '*')
                {
                    lastNumber *= number;
                }
                else if (op == '/')
                {
                    lastNumber /= number;
                }
                else
                {
                    lastNumber = number;
                    lastOp = op;
                }
            }
            else if (c == '*' || c == '/')
            {
                op = c;
                index++;
            }
            else if (c == '+' || c == '-')
            {
                if (lastOp == '+')
                {
                    res += lastNumber;
                }
                else
                {
                    res -= lastNumber;
                }

                op = c;
                index++;
            }
        }

        if (lastOp == '+')
        {
            res += lastNumber;
        }
        else
        {
            res -= lastNumber;
        }

        return res;
    }
}
