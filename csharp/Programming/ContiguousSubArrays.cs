using System;

namespace Programming;

public class ContiguousSubArrays
{
    /// <summary>
    /// Count of contiguous sub array starting or ending at 'i', and with arr[i] as the max.
    /// </summary>
    public static int[] CountSubarrays(int[] arr)
    {
        var indexStack = new Stack<int>();
        int[] res = new int[arr.Length];
        res[arr.Length - 1] = 1;
        indexStack.Push(arr.Length - 1);

        for (int i = arr.Length - 2; i >= 0; i--)
        {
            res[i] = 1;
            int current = arr[i];
            while (indexStack.Count > 0 && arr[indexStack.Peek()] <= current)
            {
                res[i] += res[indexStack.Pop()];
            }

            indexStack.Push(i);
        }

        indexStack.Clear();
        int[] res1 = new int[arr.Length];
        indexStack.Push(0);
        for (int i = 1; i < arr.Length; i++)
        {
            int current = arr[i];
            while (indexStack.Count > 0 && arr[indexStack.Peek()] <= current)
            {
                res1[i] += res1[indexStack.Pop()] + 1;
            }

            res[i] += res1[i];
            indexStack.Push(i);
        }

        return res;
    }

    public static void Test()
    {
        int[] input = [3, 4, 1, 6, 2];
        int[] res = CountSubarrays(input);
        Console.WriteLine(string.Join(" ", res));
    }
}
