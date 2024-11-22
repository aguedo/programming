using System;

namespace Programming;

public class ContainsNearbyDuplicate
{
    public bool ContainsNearbyDuplicateImp(int[] nums, int k)
    {
        var set = new HashSet<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (!set.Add(nums[i]))
            {
                return true;
            }

            if (set.Count > k)
            {
                set.Remove(nums[i - k]);
            }
        }

        return false;
    }

    public bool ContainsNearbyDuplicate1(int[] nums, int k)
    {
        var indexMap = new Dictionary<int, int>();

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int prevIndex = indexMap.GetValueOrDefault(num, -1);

            if (prevIndex >= 0 && i - prevIndex <= k)
            {
                return true;
            }

            indexMap[num] = i;
        }

        return false;
    }
}
