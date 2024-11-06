using System;

namespace Programming;

public class ValidPalindromeAllowingDelete
{
    public static bool ValidPalindrome(string s)
    {
        return ValidPalindrome(s, 0, s.Length - 1, true);
    }

    private static bool ValidPalindrome(string s, int left, int right, bool allowDelete)
    {
        while (left < right)
        {
            if (s[left] != s[right])
            {
                if (!allowDelete)
                {
                    return false;
                }

                return ValidPalindrome(s, left + 1, right, false) ||
                       ValidPalindrome(s, left, right - 1, false);
            }

            left++;
            right--;
        }

        return true;
    }
}
