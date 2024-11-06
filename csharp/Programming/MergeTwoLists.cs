using System;

namespace Programming;

public class MergeTwoLists
{
    public static ListNode MergeTwoListsImpl(ListNode list1, ListNode list2)
    {
        ListNode head = null;
        ListNode prev = null;

        while (list1 != null || list2 != null)
        {
            ListNode next = null;
            if (list1 == null)
            {
                next = list2;
                list2 = list2.next;
            }
            else if (list2 == null)
            {
                next = list1;
                list1 = list1.next;
            }
            else if (list1.val <= list2.val)
            {
                next = list1;
                list1 = list1.next;
            }
            else
            {
                next = list2;
                list2 = list2.next;
            }

            if (head == null)
            {
                head = new ListNode(next.val);
                prev = head;
            }
            else
            {
                prev.next = new ListNode(next.val);
                prev = prev.next;
            }
        }

        return head;
    }

    public class ListNode
    {
        public int val { get; set; }

        public ListNode next { get; set; }

        public ListNode(int val)
        {
            this.val = val;
        }
    }
}
