namespace Programming;

public class MinimumWindowSubstring
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
        int unbalancedCount = charMap.Count;

        for (int end = 0; end < s.Length; end++)
        {
            char c = s[end];
            if (charMap.TryGetValue(c, out int count))
            {
                count++;
                charMap[c] = count;

                if (count == 0)
                {
                    unbalancedCount--;
                }
            }

            while (start <= end && unbalancedCount == 0)
            {
                if (bestEnd < 0 || end - start < bestEnd - bestStart)
                {
                    bestStart = start;
                    bestEnd = end;
                }

                char startC = s[start];
                if (charMap.TryGetValue(startC, out int startCount))
                {
                    if (startCount == 0)
                    {
                        unbalancedCount++;
                    }

                    startCount--;
                    charMap[startC] = startCount;
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
}
