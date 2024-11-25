using System;

namespace Programming;

public class IsPalindromeNumber
{
    public bool IsPalindrome(int x)
    {
        if (x < 0 || (x > 0 && x % 10 == 0))
        {
            return false;
        }

        int num = x;
        int reverse = 0;
        while (num > 0)
        {
            reverse *= 10;
            int digit = num % 10;
            reverse += digit;
            num /= 10;
        }

        return x == reverse;
    }
}
