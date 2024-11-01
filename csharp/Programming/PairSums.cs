namespace Programming;

public class PairSums
{
    public static int NumberOfWaysImp(int[] arr, int k)
    {
        var numsCounter = new Dictionary<int, int>();
        int total = 0;

        foreach (int n in arr)
        {
            if (n > k)
            {
                continue;
            }

            int diff = k - n;
            if (numsCounter.TryGetValue(diff, out int diffCount))
            {
                total += diffCount;
            }

            int count = numsCounter.GetValueOrDefault(n, 0);
            numsCounter[n] = count + 1;
        }

        return total;
    }

    public static void Test()
    {
        int numberOfWays1 = NumberOfWaysImp(new int[] { 1, 2, 3, 4, 3 }, 6);
        Console.WriteLine(numberOfWays1 == 2);

        int numberOfWays2 = NumberOfWaysImp(new int[] { 1, 2, 3, 4, 3, 3 }, 6);
        Console.WriteLine(numberOfWays2 == 4);
    }
}
