namespace Programming;

public class BSTIterator
{
    private Stack<TreeNode> _stack = new Stack<TreeNode>();

    public BSTIterator(TreeNode root)
    {
        PushMin(root);
    }

    public bool HasNext()
    {
        return _stack.Count > 0;
    }

    public int Next()
    {
        var next = _stack.Pop();
        PushMin(next.right);
        return next.val;
    }

    private void PushMin(TreeNode node)
    {
        while (node != null)
        {
            _stack.Push(node);
            node = node.left;
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
