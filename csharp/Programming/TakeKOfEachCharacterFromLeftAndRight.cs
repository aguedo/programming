namespace Programming;

public class TakeKOfEachCharacterFromLeftAndRight
{
    public int TakeCharacters(string s, int k)
    {
        int a = 0;
        int b = 0;
        int c = 0;

        foreach (char ch in s)
        {
            if (ch == 'a')
            {
                a++;
            }
            else if (ch == 'b')
            {
                b++;
            }
            else
            {
                c++;
            }
        }

        if (a < k || b < k || c < k)
        {
            return -1;
        }

        int bestExcludingLength = 0;

        int left = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char ch = s[right];
            if (ch == 'a')
            {
                a--;
            }
            else if (ch == 'b')
            {
                b--;
            }
            else
            {
                c--;
            }

            while (a < k || b < k || c < k)
            {
                ch = s[left];
                if (ch == 'a')
                {
                    a++;
                }
                else if (ch == 'b')
                {
                    b++;
                }
                else
                {
                    c++;
                }

                left++;
            }

            int excludingLength = right - left + 1;
            if (excludingLength > bestExcludingLength)
            {
                bestExcludingLength = excludingLength;
            }
        }

        return s.Length - bestExcludingLength;
    }
}
