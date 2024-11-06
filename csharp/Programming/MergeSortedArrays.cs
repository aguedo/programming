namespace Programming;

public class MergeSortedArrays
{
    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        int right = n + m - 1;
        int index1 = m - 1;
        int index2 = n - 1;

        while (right >= 0)
        {
            if (index1 < 0 || (index2 >= 0 && nums2[index2] >= nums1[index1]))
            {
                nums1[right] = nums2[index2];
                index2--;
            }
            else if (index2 < 0 || (index1 >= 0 && nums2[index2] < nums1[index1]))
            {
                nums1[right] = nums1[index1];
                index1--;
            }

            right--;
        }
    }
}
