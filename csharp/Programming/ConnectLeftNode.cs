namespace Programming;

public class ConnectLeftNode
{
    public Node Connect(Node root)
    {
        if (root == null)
        {
            return null;
        }

        var queue = new Queue<Node>();
        queue.Enqueue(root);
        queue.Enqueue(null);

        while (queue.Count > 0)
        {
            Node node = queue.Dequeue();
            if (node == null)
            {
                if (queue.Count > 0)
                {
                    queue.Enqueue(null);
                }

                continue;
            }

            node.next = queue.Peek();

            if (node.left != null)
            {
                queue.Enqueue(node.left);
            }

            if (node.right != null)
            {
                queue.Enqueue(node.right);
            }
        }


        return root;
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}
