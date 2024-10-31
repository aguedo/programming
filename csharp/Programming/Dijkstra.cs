namespace Programming;

public class Dijkstra
{
    /// <summary>
    /// A Dijkstra implementation using the C# PriorityQueue. It uses lazy deletion to update
    /// the distance of nodes already included in the priority queue.
    /// </summary>
    /// <param name="graph">The graph conatining nodes from 0 to N - 1.</param>
    /// <param name="startNode">The starting node.</param>
    /// <returns>The array containing the distances from the startNode, or -1 if there is no path.</returns>
    public static int[] ComputeDistances(IGraph graph, int startNode)
    {
        int[] distances = new int[graph.NodesCount];
        for (int i = 0; i < distances.Length; i++)
        {
            distances[i] = -1;
        }

        var visited = new bool[graph.NodesCount];
        distances[startNode] = 0;
        var queue = new PriorityQueue<int, int>();
        queue.Enqueue(startNode, 0);

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            if (visited[node]) // Skiping duplicate nodes in the queue.
            {
                continue;
            }

            visited[node] = true;
            int nodeDistance = distances[node];
            IEnumerable<Edge> adjacents = graph.GetAdjacents(node);

            foreach (Edge edge in adjacents)
            {
                int adj = edge.To;
                int distance = nodeDistance + edge.Value;
                if (!visited[adj] && (distances[adj] == -1 || distances[adj] > distance))
                {
                    distances[adj] = distance;
                    queue.Enqueue(adj, distance); // Duplicate values will be skipped when dequeued.
                }
            }
        }

        return distances;
    }
}

public interface IGraph
{
    public IEnumerable<Edge> GetAdjacents(int node);
    public int NodesCount { get; }
}

public class Edge
{
    public int From { get; set; }
    public int To { get; set; }
    public int Value { get; set; }
}
