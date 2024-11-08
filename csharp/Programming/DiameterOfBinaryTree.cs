namespace Programming;

public class DiameterOfBinaryTree
{
    private int _bestDiameter;

    public int DiameterOfBinaryTreeImp(TreeNode root)
    {
        _bestDiameter = 0;
        DiameterOfBinaryTreeHelper(root);
        return _bestDiameter;
    }

    private int DiameterOfBinaryTreeHelper(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }

        int left = DiameterOfBinaryTreeHelper(root.left);
        int right = DiameterOfBinaryTreeHelper(root.right);

        int diameter = left + right;
        if (diameter > _bestDiameter)
        {
            _bestDiameter = diameter;
        }

        return 1 + Math.Max(left, right);
    }

    public class TreeNode
    {
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }
}
