using System;

namespace Programming;

public class IsCompleteTreeBT
{
    public bool IsCompleteTree(TreeNode root)
    {
        if (root == null)
        {
            return true;
        }

        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        queue.Enqueue(null);
        bool lastLevel = false;

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            if (node == null)
            {
                if (queue.Count > 0)
                {
                    queue.Enqueue(null);
                }

                continue;
            }

            if (lastLevel && (node.left != null || node.right != null))
            {
                return false;
            }

            if (node.left == null && node.right != null)
            {
                return false;
            }

            if (node.left != null && node.right == null)
            {
                lastLevel = true;
                queue.Enqueue(node.left);
            }
            else if (node.left != null && node.right != null)
            {
                queue.Enqueue(node.left);
                queue.Enqueue(node.right);
            }
            else
            {
                lastLevel = true;
            }
        }

        return true;
    }

    public class TreeNode
    {
        public int val { get; }
        public TreeNode left { get; }
        public TreeNode right { get; }
    }
}
