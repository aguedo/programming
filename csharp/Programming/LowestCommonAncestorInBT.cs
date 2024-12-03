using System;

namespace Programming;

public class LowestCommonAncestorInBT
{
    private bool _pFound;
    private bool _qFound;
    private TreeNode _ancestor;

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

        _pFound = false;
        _qFound = false;
        _ancestor = null;

        FindLowestCommonAncestor(root, p, q);
        return _ancestor;
    }

    private void FindLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null || (_pFound && _qFound))
        {
            return;
        }

        if (_pFound)
        {
            if (root == q)
            {
                _qFound = true;
            }

            FindLowestCommonAncestor(root.left, p, q);
            if (_qFound)
            {
                return;
            }

            FindLowestCommonAncestor(root.right, p, q);
        }
        else if (_qFound)
        {
            if (root == p)
            {
                _pFound = true;
            }

            FindLowestCommonAncestor(root.left, p, q);
            if (_pFound)
            {
                return;
            }

            FindLowestCommonAncestor(root.right, p, q);
        }
        else // None is found
        {
            if (root == p)
            {
                _pFound = true;

                FindLowestCommonAncestor(root.left, p, q);
                if (_qFound)
                {
                    _ancestor = root;
                    return;
                }

                FindLowestCommonAncestor(root.right, p, q);
                if (_qFound)
                {
                    _ancestor = root;
                    return;
                }
            }
            else if (root == q)
            {
                _qFound = true;

                FindLowestCommonAncestor(root.left, p, q);
                if (_pFound)
                {
                    _ancestor = root;
                    return;
                }

                FindLowestCommonAncestor(root.right, p, q);
                if (_pFound)
                {
                    _ancestor = root;
                    return;
                }
            }
            else
            {
                FindLowestCommonAncestor(root.left, p, q);
                if (_pFound && _qFound)
                {
                    return;
                }

                if (_pFound)
                {
                    FindLowestCommonAncestor(root.right, p, q);
                    if (_qFound)
                    {
                        _ancestor = root;
                    }
                }
                else if (_qFound)
                {
                    FindLowestCommonAncestor(root.right, p, q);
                    if (_pFound)
                    {
                        _ancestor = root;
                    }
                }
                else
                {
                    FindLowestCommonAncestor(root.right, p, q);
                }
            }
        }
    }

    public class TreeNode
    {
        public int val { get; }
        public TreeNode left { get; }
        public TreeNode right { get; }
    }
}
