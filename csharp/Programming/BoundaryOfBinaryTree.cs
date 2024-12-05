using System;

namespace Programming;

public class BoundaryOfBinaryTree
{
    private IList<int> _boundary;

    public IList<int> BoundaryOfBinaryTreImp(TreeNode root)
    {
        if (root == null)
        {
            return new List<int>();
        }

        _boundary = new List<int> { root.val };
        if (root.left != null)
        {
            LeftBoundaryWithLeaves(root.left, true);
        }

        if (root.right != null)
        {
            RightBoundaryWithLeaves(root.right, true);
        }

        return _boundary;
    }

    private void RightBoundaryWithLeaves(TreeNode node, bool isRightBoundary)
    {
        if (node.left == null && node.right == null)
        {
            _boundary.Add(node.val);
            return;
        }

        if (node.right != null)
        {
            if (node.left != null)
            {
                RightBoundaryWithLeaves(node.left, false);
            }
            RightBoundaryWithLeaves(node.right, isRightBoundary);
        }
        else // left not null && right null
        {
            RightBoundaryWithLeaves(node.left, isRightBoundary);
        }

        if (isRightBoundary)
        {
            _boundary.Add(node.val);
        }
    }

    private void LeftBoundaryWithLeaves(TreeNode node, bool isLeftBoundary)
    {
        if (node.left == null && node.right == null)
        {
            _boundary.Add(node.val);
            return;
        }

        if (isLeftBoundary)
        {
            _boundary.Add(node.val);
        }

        if (node.left != null)
        {
            LeftBoundaryWithLeaves(node.left, isLeftBoundary);
            if (node.right != null)
            {
                LeftBoundaryWithLeaves(node.right, false);
            }
        }
        else // left null && right not null
        {
            LeftBoundaryWithLeaves(node.right, isLeftBoundary);
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
