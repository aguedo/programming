using System;

namespace Programming;

public class InorderSuccessorBSTRecursive
{
    private TreeNode _p;
    private TreeNode _last;
    private TreeNode _successor;

    public TreeNode InorderSuccessor(TreeNode root, TreeNode p)
    {
        if (root == null)
        {
            return null;
        }

        _p = p;
        Traverse(root);
        return _successor;
    }

    private void Traverse(TreeNode node)
    {
        if (_successor != null)
        {
            return;
        }

        if (node.left != null && _p.val < node.val)
        {
            Traverse(node.left);
        }

        if (_successor != null)
        {
            return;
        }

        if (_last == _p)
        {
            _successor = node;
            return;
        }

        _last = node;

        if (node.right != null && node.val <= _p.val)
        {
            Traverse(node.right);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

}
