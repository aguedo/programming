using System;

namespace Programming;

public class MinimumWindowSubstringCheckingEachIteration
{
    public string MinWindow(string s, string t)
    {
        if (string.IsNullOrEmpty(s) || string.IsNullOrEmpty(t))
        {
            return "";
        }

        var charMap = new Dictionary<char, int>();
        foreach (char c in t)
        {
            int count = charMap.GetValueOrDefault(c, 0);
            charMap[c] = count - 1;
        }

        int start = 0;
        int bestStart = 0;
        int bestEnd = -1;

        for (int end = 0; end < s.Length; end++)
        {
            char c = s[end];
            if (charMap.TryGetValue(c, out int count))
            {
                count++;
                charMap[c] = count;
            }

            // TODO: avoid using IsValidWindow
            while (start <= end && IsValidWindow(charMap))
            {
                if (bestEnd < 0 || end - start < bestEnd - bestStart)
                {
                    bestStart = start;
                    bestEnd = end;
                }

                char startC = s[start];
                if (charMap.TryGetValue(startC, out int startCount))
                {
                    charMap[startC] = startCount - 1;
                }

                start++;
            }
        }

        if (bestEnd < 0)
        {
            return "";
        }

        return s.Substring(bestStart, bestEnd - bestStart + 1);
    }

    private bool IsValidWindow(Dictionary<char, int> charMap)
    {
        foreach (int count in charMap.Values)
        {
            if (count < 0)
            {
                return false;
            }
        }

        return true;
    }
}
