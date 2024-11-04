namespace Programming;

public class MinCodeEntryTime
{
    public static long GetMinCodeEntryTime(int n, int m, int[] c)
    {
        long count = 0;
        int currentCode = 1;
        int mid = n / 2;

        foreach (int code in c)
        {
            int diff = Math.Abs(code - currentCode);
            if (diff <= mid)
            {
                count += diff;
            }
            else
            {
                count += n - diff;
            }

            currentCode = code;
        }

        return count;
    }
}
