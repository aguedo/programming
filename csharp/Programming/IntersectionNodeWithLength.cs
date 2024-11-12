using System;

namespace Programming;

public class IntersectionNodeWithLength
{
    public ListNode GetIntersectionNodeWithLength(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
        {
            return null;
        }

        int lenA = GetLength(headA);
        int lenB = GetLength(headB);

        int diff = Math.Abs(lenA - lenB);
        if (lenA > lenB)
        {
            headA = Shift(headA, diff);
        }
        else
        {
            headB = Shift(headB, diff);
        }

        while (headA != null)
        {
            if (headA == headB)
            {
                return headA;
            }

            headA = headA.next;
            headB = headB.next;
        }

        return null;
    }

    private ListNode Shift(ListNode head, int diff)
    {
        while (diff > 0)
        {
            head = head.next;
            diff--;
        }

        return head;
    }

    private int GetLength(ListNode head)
    {
        int len = 0;
        while (head != null)
        {
            len++;
            head = head.next;
        }

        return len;
    }

    public class ListNode
    {
        public ListNode next { get; set; }
    }
}
