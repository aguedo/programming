namespace Programming;

public class MinimumLengthSubstrings
{
    public static int MinLengthSubstringImp(string s, string t)
    {
        var tCharCounter = new Dictionary<char, int>();
        foreach (char c in t)
        {
            int count = tCharCounter.GetValueOrDefault(c, 0);
            tCharCounter[c] = count + 1;
        }

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (tCharCounter.TryGetValue(c, out int count))
            {
                if (count == 1)
                {
                    tCharCounter.Remove(c);
                    if (tCharCounter.Count == 0)
                    {
                        return i + 1;
                    }
                }
                else
                {
                    tCharCounter[c] = count - 1;
                }
            }
        }

        return -1;
    }

    public static void Test()
    {
        int count = MinLengthSubstringImp("dcbefebce", "fd");
        Console.WriteLine(count == 5);

        int count2 = MinLengthSubstringImp("dcbefebce", "fdm");
        Console.WriteLine(count2 == -1);
    }
}
