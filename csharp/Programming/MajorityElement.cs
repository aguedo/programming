namespace Programming;

public class MajorityElement
{
    public int MajorityElementImp(int[] nums)
    {
        int count = 0;
        int majority = 0;

        foreach (int n in nums)
        {
            if (count == 0)
            {
                majority = n;
            }

            if (majority == n)
            {
                count++;
            }
            else
            {
                count--;
            }
        }

        return majority;
    }
}
