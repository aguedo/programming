using System;

namespace Programming;

public class FindKthLargest
{
    private int[] _nums;
    private int _k;
    private Random _random = new Random();

    public int FindKthLargestImp(int[] nums, int k)
    {
        _k = nums.Length - k;
        _nums = nums;
        return FindKthLargestImp(0, nums.Length - 1);
    }

    private int FindKthLargestImp(int start, int end)
    {
        if (start == end)
        {
            return _nums[start];
        }

        if (start > end)
        {
            return -1;
        }

        int equalCount = 0;
        int partition = Partition(start, end, out equalCount);

        if (partition == _k)
        {
            return _nums[partition];
        }

        if (partition < _k)
        {
            if (partition + equalCount - 1 >= _k)
            {
                return _nums[partition];
            }

            return FindKthLargestImp(partition + 1, end);
        }

        return FindKthLargestImp(start, partition - 1);
    }

    private int Partition(int start, int end, out int equalCount)
    {
        equalCount = 0;

        if (start == end)
        {
            return start;
        }

        int pivotIndex = _random.Next(start, end + 1);
        int pivot = _nums[pivotIndex];
        int index = start;
        Swap(pivotIndex, end);

        for (int i = start; i < end; i++)
        {
            if (_nums[i] < pivot)
            {
                if (index != i)
                {
                    Swap(index, i);
                }

                index++;
            }
            else if (_nums[i] == pivot)
            {
                equalCount++;
            }
        }

        Swap(index, end);
        return index;
    }

    private void Swap(int i, int j)
    {
        int temp = _nums[i];
        _nums[i] = _nums[j];
        _nums[j] = temp;
    }
}
