using System;

namespace Programming;

public class IsPalindromeAlphanumeric
{
    public static bool IsPalindrome(string s)
    {
        int left = 0;
        int right = s.Length - 1;

        while (left < right)
        {
            if (char.IsLetterOrDigit(s[left]) && char.IsLetterOrDigit(s[right]))
            {
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }

                left++;
                right--;
            }
            else
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                }

                if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                }
            }
        }

        return true;
    }

}
