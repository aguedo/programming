namespace Programming;

public class LowestCommonAncestorWithHashSet
{
    public static Node LowestCommonAncestor(Node p, Node q)
    {
        HashSet<Node> path = new HashSet<Node>();

        while (p != null)
        {
            path.Add(p);
            p = p.parent;
        }

        while (q != null)
        {
            if (path.Contains(q))
            {
                return q;
            }

            q = q.parent;
        }

        throw new Exception("No common ancestor.");
    }

    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node parent;
    }
}
