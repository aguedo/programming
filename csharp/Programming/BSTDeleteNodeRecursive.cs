using System;

namespace Programming;

public class BSTDeleteNodeRecursive
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        if (root == null)
        {
            return null;
        }

        if (root.val < key)
        {
            root.right = DeleteNode(root.right, key);
        }
        else if (root.val > key)
        {
            root.left = DeleteNode(root.left, key);
        }
        else if (root.left == null && root.right == null)
        {
            root = null;
        }
        else if (root.left == null)
        {
            root = root.right;
        }
        else if (root.right == null)
        {
            root = root.left;
        }
        else
        {
            int succVal = FindRightSuccessor(root.right);
            root.right = DeleteNode(root.right, succVal);
            root.val = succVal;
        }

        return root;
    }

    private int FindRightSuccessor(TreeNode node)
    {
        while (node.left != null)
        {
            node = node.left;
        }

        return node.val;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}
