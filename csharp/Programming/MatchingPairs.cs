namespace Programming;

public class MatchingPairs
{
    public static int MatchingPairsImp(string s, string t)
    {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == t[i])
            {
                count++;
            }
        }

        if (count >= s.Length - 1)
        {
            // Find a duplicate to swap.
            var charSet = new HashSet<char>();
            foreach (char c in s)
            {
                if (!charSet.Add(c)) // There is at least onr duplicate.
                {
                    return count;
                }
            }

            if (count == s.Length)
            {
                count -= 2;
            }
            else
            {
                count -= 1;
            }
        }
        else
        {
            // TODO: think a better way to find the best pair to swap.
            bool oneMatch = false;
            for (int i = 0; i < s.Length; i++) // Find the best pair to swap.
            {
                if (s[i] != t[i])
                {
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] != t[j] && t[i] == s[j])
                        {
                            oneMatch = true;
                            if (t[j] == s[i])
                            {
                                return count + 2;
                            }
                        }
                    }
                }
            }

            if (oneMatch)
            {
                return count + 1;
            }
        }

        return count;
    }

    public static void Test()
    {
        int count1 = MatchingPairsImp("abcd", "adcb");
        Console.WriteLine(count1);
        Console.WriteLine(count1 == 4);

        int count2 = MatchingPairsImp("mno", "mno");
        Console.WriteLine(count2);
        Console.WriteLine(count2 == 1);
    }
}
