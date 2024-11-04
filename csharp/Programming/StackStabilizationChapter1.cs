namespace Programming;

public class StackStabilizationChapter1
{
    public static int GetMinimumDeflatedDiscCount(int n, int[] r)
    {
        int count = 0;

        for (int i = r.Length - 1; i >= 0; i--)
        {
            int prefixLen = i;
            int discRadius = r[i];
            if (discRadius <= prefixLen)
            {
                return -1;
            }

            if (i < r.Length - 1 && r[i] >= r[i + 1])
            {
                r[i] = r[i + 1] - 1;
                count++;
            }
        }

        return count;
    }
}
