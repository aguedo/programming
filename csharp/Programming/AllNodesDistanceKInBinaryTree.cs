using System;

namespace Programming;

public class AllNodesDistanceKInBinaryTree
{
    private int _k;
    private int _target;
    private List<int> _inDistance;

    public IList<int> DistanceK(TreeNode root, TreeNode target, int k)
    {
        _k = k;
        _target = target.val;
        _inDistance = new List<int>();

        FindTarget(root);
        return _inDistance;
    }

    private int FindTarget(TreeNode node)
    {
        if (node.val == _target)
        {
            if (node.left != null)
            {
                FindDistances(node.left, 1);
            }

            if (node.right != null)
            {
                FindDistances(node.right, 1);
            }

            if (_k == 0)
            {
                _inDistance.Add(node.val);
            }

            return 1;
        }

        if (node.left != null)
        {
            int leftDist = FindTarget(node.left);
            if (leftDist > 0)
            {
                if (leftDist == _k)
                {
                    _inDistance.Add(node.val);
                }
                else if (leftDist < _k && node.right != null)
                {
                    FindDistances(node.right, leftDist + 1);
                }

                return leftDist + 1;
            }
        }

        if (node.right != null)
        {
            int rightDist = FindTarget(node.right);
            if (rightDist > 0)
            {
                if (rightDist == _k)
                {
                    _inDistance.Add(node.val);
                }
                else if (rightDist <= _k && node.left != null)
                {
                    FindDistances(node.left, rightDist + 1);
                }

                return rightDist + 1;
            }
        }

        return -1;
    }

    private void FindDistances(TreeNode node, int distance)
    {
        if (distance > _k)
        {
            return;
        }

        if (distance == _k)
        {
            _inDistance.Add(node.val);
            return;
        }

        if (node.left != null)
        {
            FindDistances(node.left, distance + 1);
        }

        if (node.right != null)
        {
            FindDistances(node.right, distance + 1);
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
