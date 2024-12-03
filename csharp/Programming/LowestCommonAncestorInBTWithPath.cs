using System;

namespace Programming;

public class LowestCommonAncestorInBTWithPath
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

        LinkedList<TreeNode> pPath = FindPath(root, p);
        if (pPath == null)
        {
            return null;
        }

        LinkedList<TreeNode> qPath = FindPath(root, q);
        if (qPath == null)
        {
            return null;
        }

        TreeNode ancestor = null;
        LinkedListNode<TreeNode> qNode = qPath.First;
        LinkedListNode<TreeNode> pNode = pPath.First;
        while (qNode != null && pNode != null && pNode.Value == qNode.Value)
        {
            ancestor = qNode.Value;
            qNode = qNode.Next;
            pNode = pNode.Next;
        }

        return ancestor;
    }

    private LinkedList<TreeNode> FindPath(TreeNode root, TreeNode node)
    {
        if (root == null)
        {
            return null;
        }

        if (root == node)
        {
            var res = new LinkedList<TreeNode>();
            res.AddFirst(root);
            return res;
        }

        LinkedList<TreeNode> left = FindPath(root.left, node);
        if (left != null)
        {
            left.AddFirst(root);
            return left;
        }

        LinkedList<TreeNode> right = FindPath(root.right, node);
        if (right != null)
        {
            right.AddFirst(root);
            return right;
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
