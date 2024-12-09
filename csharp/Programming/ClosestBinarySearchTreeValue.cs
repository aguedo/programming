using System;

namespace Programming;

public class ClosestBinarySearchTreeValue
{
    private int? _prev;
    private int? _next;
    private double _target;
    bool _found;

    public int ClosestValue(TreeNode root, double target)
    {
        _prev = null;
        _next = null;
        _target = target;
        _found = false;
        FindClosestValue(root);

        double prevDiff = _prev != null ? target - _prev.Value : double.MaxValue;
        double nextDiff = _next != null ? _next.Value - target : double.MaxValue;

        if (prevDiff <= nextDiff)
        {
            return _prev.Value;
        }

        return _next.Value;
    }

    private void FindClosestValue(TreeNode node)
    {
        if (_found || (_prev != null && _next != null))
        {
            return;
        }

        if (node.left != null)
        {
            FindClosestValue(node.left);
        }

        if (_found || (_prev != null && _next != null))
        {
            return;
        }

        int val = node.val;
        if (_target <= val)
        {
            if (node.left == null && _prev == null)
            {
                _found = true;
            }

            _next = val;
        }
        else
        {
            _prev = val;
        }

        if (node.right != null)
        {
            FindClosestValue(node.right);
        }
    }

    public class TreeNode
    {
        public TreeNode right;
        public TreeNode left;
        public int val;
    }
}
