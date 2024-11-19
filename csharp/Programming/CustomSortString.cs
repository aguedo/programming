using System;

namespace Programming;

public class CustomSortString
{
    public string CustomSortStringImp(string order, string s)
    {
        Dictionary<char, int> charCount = new Dictionary<char, int>();
        foreach (char c in s)
        {
            int count = charCount.GetValueOrDefault(c, 0);
            charCount[c] = count + 1;
        }

        char[] sArr = new char[s.Length];
        int index = 0;

        foreach (char c in order)
        {
            int count = charCount.GetValueOrDefault(c, 0);
            while (count > 0)
            {
                sArr[index] = c;
                index++;
                count--;
            }

            charCount.Remove(c);
        }

        foreach (var kv in charCount)
        {
            int count = kv.Value;
            while (count > 0)
            {
                sArr[index] = kv.Key;
                index++;
                count--;
            }
        }

        return new string(sArr);
    }
}
