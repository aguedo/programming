using System;

namespace Programming;

public class MaximumSwap
{
    public int MaximumSwapImp(int num)
    {
        List<int> digits = GetDigits(num);
        Dictionary<int, int> digitsMap = MapDigitIndex(digits);

        for (int i = digits.Count - 1; i >= 1; i--)
        {
            int currentDigit = digits[i];
            for (int digit = 9; digit >= 1; digit--)
            {
                if (currentDigit >= digit)
                {
                    break;
                }

                int digitIndex = digitsMap.GetValueOrDefault(digit, -1);
                if (digitIndex >= 0 && digitIndex < i)
                {
                    int temp = digits[i];
                    digits[i] = digits[digitIndex];
                    digits[digitIndex] = temp;
                    return BuildNumber(digits);
                }
            }
        }

        return num;
    }

    private int BuildNumber(List<int> digits)
    {
        int num = 0;
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            num *= 10;
            num += digits[i];
        }

        return num;
    }

    private Dictionary<int, int> MapDigitIndex(List<int> digits)
    {
        Dictionary<int, int> digitsMap = new Dictionary<int, int>();

        for (int i = digits.Count - 1; i >= 0; i--)
        {
            digitsMap[digits[i]] = i;
        }

        return digitsMap;
    }

    private List<int> GetDigits(int num)
    {
        List<int> digits = new List<int>();

        while (num > 0)
        {
            int digit = num % 10;
            digits.Add(digit);
            num /= 10;
        }

        return digits;
    }
}
