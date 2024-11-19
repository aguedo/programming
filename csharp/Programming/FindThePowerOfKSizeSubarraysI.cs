using System;

namespace Programming;

public class FindThePowerOfKSizeSubarraysI
{
    public int[] ResultsArray(int[] nums, int k)
    {
        int[] res = new int[nums.Length - k + 1];
        int start = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (i - start + 1 > k) // The previuos k are in ascending order.
            {
                res[start] = nums[i - 1];
                start++;
            }

            if (nums[i] != nums[i - 1] + 1)
            {
                // Reset the start to the current index, and set -1 to all values in between.
                while (start < res.Length && start < i)
                {
                    res[start] = -1;
                    start++;
                }

                if (start == res.Length)
                {
                    return res;
                }
            }
        }

        if (start < nums.Length)
        {
            res[start] = nums[nums.Length - 1];
        }

        return res;
    }
}
