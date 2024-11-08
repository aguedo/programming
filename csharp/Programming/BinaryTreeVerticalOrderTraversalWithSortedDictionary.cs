namespace Programming;

public class BinaryTreeVerticalOrderTraversalWithSortedDictionary
{
    public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        if (root == null)
        {
            return new List<IList<int>>();
        }

        SortedDictionary<int, List<int>> indexMap = new SortedDictionary<int, List<int>>();
        var queue = new Queue<NodeIndex>();
        queue.Enqueue(new NodeIndex(root, 0));

        while (queue.Count > 0)
        {
            var nodeIndex = queue.Dequeue();

            int index = nodeIndex.Index;
            TreeNode node = nodeIndex.Node;

            List<int> list = indexMap.GetValueOrDefault(index, null);
            if (list == null)
            {
                list = new List<int>();
                indexMap[index] = list;
            }
            list.Add(node.val);

            if (node.left != null)
            {
                queue.Enqueue(new NodeIndex(node.left, index - 1));
            }

            if (node.right != null)
            {
                queue.Enqueue(new NodeIndex(node.right, index + 1));
            }
        }

        IList<IList<int>> res = new List<IList<int>>();
        foreach (var kvp in indexMap)
        {
            res.Add(kvp.Value);
        }

        return res;
    }

    class NodeIndex
    {
        public TreeNode Node { get; set; }
        public int Index { get; set; }

        public NodeIndex(TreeNode node, int index)
        {
            Node = node;
            Index = index;
        }
    }

    public class TreeNode
    {
        public int val { get; set; }
        public TreeNode left { get; set; }
        public TreeNode right { get; set; }
    }
}
