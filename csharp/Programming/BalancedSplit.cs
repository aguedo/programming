namespace Programming;

class BalancedSplit
{
    public static bool BalancedSplitExists(int[] arr)
    {
        if (arr.Length < 2)
        {
            return false;
        }

        Array.Sort(arr);
        int leftSum = 0;
        int rightSum = 0;
        int leftIndex = 0;
        int rightIndex = arr.Length - 1;

        while (leftIndex <= rightIndex)
        {
            if (leftSum <= rightSum)
            {
                do
                {
                    leftSum += arr[leftIndex];
                    leftIndex++;
                }
                while (leftIndex <= rightIndex && arr[leftIndex - 1] == arr[leftIndex]);
            }
            else
            {
                do
                {
                    rightSum += arr[rightIndex];
                    rightIndex--;
                }
                while (rightIndex >= leftIndex && arr[rightIndex] == arr[rightIndex + 1]);
            }
        }


        return leftSum == rightSum;
    }

    public static void Test(string[] args)
    {
        bool isBalanced = BalancedSplitExists(new int[] { 1, 5, 7, 1 });
        Console.WriteLine(isBalanced);

        bool isBalanced2 = BalancedSplitExists(new int[] { 12, 7, 6, 7, 6 });
        Console.WriteLine(isBalanced2);

        bool isBalanced3 = BalancedSplitExists(new int[] { 1, 1, 1, 1 });
        Console.WriteLine(isBalanced3);

        bool isBalanced4 = BalancedSplitExists(new int[] { 2, 1, 1, 1, 1 });
        Console.WriteLine(isBalanced4);

        bool isBalanced5 = BalancedSplitExists(new int[] { 1, 1, 1, 1, 2, 2 });
        Console.WriteLine(isBalanced5);
    }
}
