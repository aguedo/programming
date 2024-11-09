using System;

namespace Programming;

public class FindMissingRanges
{
    public static IList<IList<int>> FindMissingRangesImp(int[] nums, int lower, int upper)
    {
        IList<IList<int>> res = new List<IList<int>>();
        if (nums.Length == 0)
        {
            res.Add(new List<int> { lower, upper });
            return res;
        }

        if (lower < nums[0])
        {
            res.Add(new List<int> { lower, nums[0] - 1 });
        }

        for (int i = 0; i < nums.Length - 1; i++)
        {
            int current = nums[i];
            int next = nums[i + 1];

            int start = current + 1;
            if (start == next)
            {
                continue;
            }

            int end = next - 1;
            res.Add(new List<int> { start, end });
        }

        if (upper > nums[nums.Length - 1])
        {
            res.Add(new List<int> { nums[nums.Length - 1] + 1, upper });
        }

        return res;
    }
}
