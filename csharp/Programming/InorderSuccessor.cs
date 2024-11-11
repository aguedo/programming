using System;

namespace Programming;

public class InorderSuccessor
{
    public TreeNode InorderSuccessorImp(TreeNode root, TreeNode p)
    {
        TreeNode lastBiggerThanP = null;
        TreeNode node = root;

        // Similar to successor in a binary search.
        while (node != null)
        {
            if (p.val < node.val)
            {
                lastBiggerThanP = node;
                node = node.left;
            }
            else
            {
                node = node.right;
            }
        }

        return lastBiggerThanP;
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }
}
