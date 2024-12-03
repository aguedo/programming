using System;

namespace Programming;

public class LowestCommonAncestorInBST
{
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
        {
            return null;
        }

        if (p == q)
        {
            return p;
        }

        TreeNode ancestor = null;
        TreeNode pNode = root;
        TreeNode qNode = root;

        while (true)
        {
            if (pNode == qNode)
            {
                ancestor = pNode;
            }
            else
            {
                return ancestor;
            }

            if (p.val < pNode.val)
            {
                pNode = pNode.left;
            }
            else if (p.val > pNode.val)
            {
                pNode = pNode.right;
            }

            if (q.val < qNode.val)
            {
                qNode = qNode.left;
            }
            else if (q.val > qNode.val)
            {
                qNode = qNode.right;
            }
        }

        return null;
    }

    public class TreeNode
    {
        public int val { get; }
        public TreeNode left { get; }
        public TreeNode right { get; }
    }
}
