using System;

namespace Programming;

public class MergeKListsBruteforce
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }

        ListNode head = null;
        ListNode curr = null;

        while (true)
        {
            ListNode min = null;
            int minIndex = -1;
            for (int i = 0; i < lists.Length; i++)
            {
                ListNode node = lists[i];
                if (node == null)
                {
                    continue;
                }

                if (min == null || node.val < min.val)
                {
                    min = node;
                    minIndex = i;
                }
            }

            if (min != null)
            {
                lists[minIndex] = lists[minIndex].next;

                if (head == null)
                {
                    head = min;
                    curr = min;
                }
                else
                {
                    curr.next = min;
                    curr = min;
                }
            }
            else
            {
                if (curr != null) // TODO: maybe not needed.
                {
                    curr.next = null;
                }

                return head;
            }
        }

        throw new Exception("Invalid operation.");
    }
}
