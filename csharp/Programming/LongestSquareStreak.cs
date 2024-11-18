using System;

namespace Programming;

public class LongestSquareStreakWithSorting
{
    public int LongestSquareStreak(int[] nums)
    {
        if (nums == null || nums.Length < 2)
        {
            return -1;
        }

        Array.Sort(nums);
        int longest = -1;
        var numsMap = new Dictionary<int, int>();
        numsMap[nums[nums.Length - 1]] = 1;

        for (int i = nums.Length - 2; i >= 0; i--)
        {
            int num = nums[i];
            int square = num * num;
            int squareCount = numsMap.GetValueOrDefault(square, 0);
            numsMap[num] = squareCount + 1;

            if (squareCount > 0 && squareCount + 1 > longest)
            {
                longest = squareCount + 1;
            }
        }

        return longest;
    }
}
