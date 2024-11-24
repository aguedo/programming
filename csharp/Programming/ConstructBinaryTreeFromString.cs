namespace Programming;

public class ConstructBinaryTreeFromString
{
    private string _s;
    private int _index;

    public TreeNode Str2tree(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return null;
        }

        _s = s;
        return Str2tree();
    }

    private TreeNode Str2tree()
    {
        if (_index >= _s.Length)
        {
            return null;
        }

        int sign = 1;
        int val = 0;
        while (_index < _s.Length && _s[_index] != '(' && _s[_index] != ')')
        {
            if (_s[_index] == '-')
            {
                sign = -1;
            }
            else
            {
                int digit = _s[_index] - '0';
                val *= 10;
                val += digit;
            }

            _index++;
        }

        val *= sign;
        TreeNode node = new TreeNode(val);

        if (_index >= _s.Length)
        {
            return node;
        }

        if (_s[_index] == '(')
        {
            _index++; // Opening '(' of the left child.
            TreeNode left = Str2tree();
            node.left = left;
            _index++; // Closing ')' of the left child.

            if (_index < _s.Length && _s[_index] == '(')
            {
                _index++; // Opening '(' of the right child.
                TreeNode right = Str2tree();
                node.right = right;
                _index++; // Closing ')' of the right child.
            }
        }

        return node;
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
