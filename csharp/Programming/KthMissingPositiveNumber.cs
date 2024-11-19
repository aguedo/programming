namespace Programming;

public class KthMissingPositiveNumber
{
    public int FindKthPositive(int[] nums, int k)
    {
        if (k < nums[0])
        {
            return k;
        }

        int endMissCount = MissCount(nums, nums.Length - 1);
        if (endMissCount < k)
        {
            return nums[nums.Length - 1] + k - endMissCount;
        }

        int index = FindIndex(nums, k);
        // int missCount = MissCount(nums, index);
        // return nums[index] - (missCount - k + 1);
        return index + k;
    }

    private int FindIndex(int[] nums, int k)
    {
        int start = 0;
        int end = nums.Length - 1;
        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            int missCount = MissCount(nums, mid);

            if (missCount >= k)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return end + 1;
    }

    private int MissCount(int[] nums, int i)
    {
        return nums[i] - i - 1;
    }
}
