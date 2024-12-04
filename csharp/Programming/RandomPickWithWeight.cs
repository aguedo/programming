namespace Programming;

public class RandomPickWithWeight
{
    private int[] _prefixSum;
    private int _sum;
    private Random _random = new Random();

    public RandomPickWithWeight(int[] w)
    {
        _prefixSum = new int[w.Length];
        for (int i = 0; i < w.Length; i++)
        {
            _sum += w[i];
            _prefixSum[i] = _sum;
        }
    }

    public int PickIndex()
    {
        int r = _random.Next(1, _sum + 1);

        int start = 0;
        int end = _prefixSum.Length - 1;

        while (start <= end)
        {
            int midIndex = start + (end - start) / 2;
            int mid = _prefixSum[midIndex];

            if (mid == r)
            {
                return midIndex;
            }

            if (r < mid)
            {
                end = midIndex - 1;
            }
            else
            {
                start = midIndex + 1;
            }
        }

        return end + 1;
    }
}
