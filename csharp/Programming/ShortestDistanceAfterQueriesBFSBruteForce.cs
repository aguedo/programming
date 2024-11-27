using System;

namespace Programming;

public class ShortestDistanceAfterQueriesBFSBruteForce
{
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries)
    {
        var graph = new Graph(n);
        for (int i = 0; i < n - 1; i++)
        {
            graph.AddEdge(i, i + 1);
        }

        int[] answers = new int[queries.Length];
        for (int i = 0; i < queries.Length; i++)
        {
            graph.AddEdge(queries[i]);
            answers[i] = GetDistance(graph, n - 1);
        }

        return answers;
    }

    private int GetDistance(Graph graph, int target)
    {
        var visited = new HashSet<int>();
        Queue<int> queue = new Queue<int>();
        visited.Add(0);
        queue.Enqueue(0);
        queue.Enqueue(-1);
        int dist = 1;

        while (queue.Count > 0)
        {
            int node = queue.Dequeue();
            if (node == -1)
            {
                if (queue.Count > 0)
                {
                    queue.Enqueue(-1);
                }

                dist++;
                continue;
            }

            foreach (int adj in graph.GetAdjacents(node))
            {
                if (adj == target)
                {
                    Console.WriteLine("Node: {0}", node);
                    Console.WriteLine("Adj: {0}", adj);
                    Console.WriteLine("Dist: {0}", dist);
                    return dist;
                }

                if (visited.Add(adj))
                {
                    queue.Enqueue(adj);
                }
            }
        }

        throw new Exception("Node not found.");
    }

    class Graph
    {
        private Dictionary<int, HashSet<int>> _adjMap;

        public Graph(int n)
        {
            _adjMap = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                _adjMap[i] = new HashSet<int>();
            }
        }

        public void AddEdge(int[] edge)
        {
            AddEdge(edge[0], edge[1]);
        }

        public void AddEdge(int i, int j)
        {
            _adjMap[i].Add(j);
        }

        public IEnumerable<int> GetAdjacents(int node)
        {
            return _adjMap[node];
        }
    }
}
