namespace Programming;

public class CopyRandomList
{
    public static Node CopyRandomListImp(Node head)
    {
        if (head == null)
        {
            return null;
        }

        var nodeMap = new Dictionary<Node, Node>(); Node node = head;
        while (node != null)
        {
            Node newNode = nodeMap.GetValueOrDefault(node, null);
            if (newNode == null)
            {
                newNode = new Node(node.val);
                nodeMap[node] = newNode;
            }

            if (node.next != null)
            {
                Node next = nodeMap.GetValueOrDefault(node.next, null);
                if (next == null)
                {
                    next = new Node(node.next.val);
                    nodeMap[node.next] = next;
                }
                newNode.next = next;
            }

            if (node.random != null)
            {
                Node random = nodeMap.GetValueOrDefault(node.random, null);
                if (random == null)
                {
                    random = new Node(node.random.val);
                    nodeMap[node.random] = random;
                }
                newNode.random = random;
            }

            node = node.next;
        }

        return nodeMap[head];
    }

    public class Node
    {
        public Node next { get; set; }
        public Node random { get; set; }
        public int val { get; set; }

        public Node(int val)
        {
            this.val = val;
        }
    }
}
