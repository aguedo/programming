using System;

namespace Programming;

public class FindKthLargestWithHeap
{
    public int FindKthLargest(int[] nums, int k) {
        BuildHeap(nums);

        int count = nums.Length;
        while (k > 1)
        {
            ExtractMax(nums, count);
            k--;
            count--;
        }

        return nums[0];
    }

    private int ExtractMax(int[] nums, int count)
    {
        int max = nums[0];
        nums[0] = nums[count - 1];
        Heapify(nums, 0, count - 1);
        return max;
    }

    private void BuildHeap(int[] nums)
    {
        int lastInternal = LastInternal(nums.Length);
        for (int i = lastInternal; i >= 0; i--)
        {
            Heapify(nums, i, nums.Length);
        }
    }

    private void Heapify(int[] nums, int i, int count)
    {
        int largest = i;
        int leftChild = LeftChild(i);
        if (leftChild < count && nums[leftChild] > nums[largest])
        {
            largest = leftChild;
        }

        int rightChild = RightChild(i);
        if (rightChild < count && nums[rightChild] > nums[largest])
        {
            largest = rightChild;
        }

        if (largest != i)
        {
            Swap(nums, i, largest);
            Heapify(nums, largest, count);
        }
    }

    private int Parent(int i)
    {
        return (i - 1)/ 2;
    }

    private int LeftChild(int i)
    {
        return 2 * i + 1;
    }

    private int RightChild(int i)
    {
        return 2 * i + 2;
    }

    private int LastInternal(int count)
    {
        return count / 2 - 1;
    }

    private void Swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }
}
