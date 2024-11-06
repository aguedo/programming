using System;

namespace Programming;

public class TwoSum
{
    public static int[] TwoSumWithDictionary(int[] nums, int target)
    {
        var numIndexes = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int diff = target - nums[i];
            int index = numIndexes.GetValueOrDefault(diff, -1);
            if (index >= 0)
            {
                return new int[] { index, i };
            }

            numIndexes[nums[i]] = i;
        }

        throw new Exception("Target not found.");
    }

    public static int[] TwoSumSorting(int[] nums, int target)
    {
        int[] indices = new int[nums.Length];
        for (int i = 0; i < nums.Length; i++)
        {
            indices[i] = i;
        }

        Array.Sort(nums, indices);

        int left = 0;
        int right = nums.Length - 1;

        while (left < right)
        {
            int sum = nums[left] + nums[right];
            if (sum < target)
            {
                left++;
            }
            else if (sum > target)
            {
                right--;
            }
            else
            {
                return new int[] { indices[left], indices[right] };
            }
        }

        throw new Exception("No sum found.");
    }
}
