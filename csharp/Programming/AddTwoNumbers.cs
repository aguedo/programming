using System;

namespace Programming;

public class AddTwoNumbers
{
    public ListNode AddTwoNumbersImp(ListNode l1, ListNode l2)
    {
        ListNode head = new ListNode();
        ListNode curr = head;
        bool hasCarry = false;

        while (true)
        {
            int sum = 0;
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            if (hasCarry)
            {
                sum++;
            }

            if (sum >= 10)
            {
                sum -= 10;
                hasCarry = true;
            }
            else
            {
                hasCarry = false;
            }

            curr.val = sum;

            if (l1 != null || l2 != null || hasCarry)
            {
                curr.next = new ListNode();
                curr = curr.next;
            }
            else
            {
                return head;
            }
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}
