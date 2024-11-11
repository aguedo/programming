using System;

namespace Programming;

public class InorderSuccessorWithParent
{
    public Node InorderSuccessor(Node node)
    {
        if (node == null)
        {
            return null;
        }

        if (node.right != null)
        {
            node = node.right;
            while (node.left != null)
            {
                node = node.left;
            }

            return node;
        }

        while (node.parent != null)
        {
            if (node.parent.val > node.val)
            {
                return node.parent;
            }

            node = node.parent;
        }

        return null;
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }
}
