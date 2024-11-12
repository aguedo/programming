using System;

namespace Programming;

public class BSTDeleteNodeIterative
{
    public TreeNode DeleteNode(TreeNode root, int key)
    {
        TreeNode parent = null;
        TreeNode node = root;

        while (node != null && node.val != key)
        {
            parent = node;
            if (node.val < key)
            {
                node = node.right;
            }
            else
            {
                node = node.left;
            }
        }

        if (node == null)
        {
            return root;
        }

        if (node.left == null && node.right == null)
        {
            if (parent == null)
            {
                root = null;
            }
            else
            {
                RemoveLeaf(parent, node);
            }
        }
        else if (node.left == null)
        {
            if (parent == null)
            {
                root = root.right;
                node.right = null;
            }
            else
            {
                ReplaceParent(parent, node, node.right);
            }
        }
        else if (node.right == null)
        {
            if (parent == null)
            {
                root = root.left;
                node.left = null;
            }
            else
            {
                ReplaceParent(parent, node, node.left);
            }
        }
        else
        {
            TreeNode succ = node.right;
            TreeNode succParent = node;
            while (succ.left != null)
            {
                succParent = succ;
                succ = succ.left;
            }

            if (succParent == node)
            {
                succ.left = node.left;
                if (parent == null)
                {
                    root = succ;
                }
                else
                {
                    ReplaceParent(parent, node, succ);
                }
            }
            else
            {
                succParent.left = succ.right;
                succ.left = node.left;
                succ.right = node.right;

                if (parent == null)
                {
                    root = succ;
                }
                else
                {
                    ReplaceParent(parent, node, succ);
                }
            }
        }

        return root;
    }

    private void RemoveLeaf(TreeNode parent, TreeNode node)
    {
        if (parent.left == node)
        {
            parent.left = null;
        }
        else
        {
            parent.right = null;
        }
    }

    private void ReplaceParent(TreeNode parent, TreeNode node, TreeNode newNode)
    {
        if (parent.left == node)
        {
            parent.left = newNode;
        }
        else
        {
            parent.right = newNode;
        }
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
