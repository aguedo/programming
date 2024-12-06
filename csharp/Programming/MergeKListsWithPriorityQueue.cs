namespace Programming;

public class MergeKListsWithPriorityQueue
{
    public ListNode MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }

        var queue = new PriorityQueue<NodeIndex, int>();
        for (int i = 0; i < lists.Length; i++)
        {
            ListNode node = lists[i];
            if (node != null)
            {
                var nodeIndex = new NodeIndex(node, i);
                queue.Enqueue(nodeIndex, node.val);
            }
        }

        ListNode head = null;
        ListNode curr = null;

        while (queue.Count > 0)
        {
            var nodeIndex = queue.Dequeue();

            if (head == null)
            {
                head = nodeIndex.Node;
                curr = head;
            }
            else
            {
                curr.next = nodeIndex.Node;
                curr = curr.next;
            }

            int index = nodeIndex.Index;
            lists[index] = lists[index].next;
            if (lists[index] != null)
            {
                var nextNodeIndex = new NodeIndex(lists[index], index);
                queue.Enqueue(nextNodeIndex, lists[index].val);
            }
        }

        if (curr != null) // TODO: maybe not needed.
        {
            curr.next = null;
        }

        return head;
    }

    class NodeIndex
    {
        public int Index { get; }
        public ListNode Node { get; }

        public NodeIndex(ListNode node, int index)
        {
            Index = index;
            Node = node;
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
