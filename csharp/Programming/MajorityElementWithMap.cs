using System;

namespace Programming;

public class MajorityElementWithMap
{
    public int MajorityElement(int[] nums)
    {
        int majorityCount = 0;
        int majority = 0;
        var cansecutivesMap = new Dictionary<int, int>();
        int half = nums.Length / 2;

        if (nums[0] == nums[nums.Length - 1])
        {
            majorityCount = 1;
            majority = nums[0];
            cansecutivesMap[majority] = 1;
        }

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                int count = cansecutivesMap.GetValueOrDefault(nums[i], 0);
                count++;
                cansecutivesMap[nums[i]] = count;
                if (count > majorityCount)
                {
                    majorityCount = count;
                    majority = nums[i];
                }

                if (count > half)
                {
                    return majority;
                }
            }
        }

        return majority;
    }
}
