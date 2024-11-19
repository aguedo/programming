using System;

namespace Programming;

public class KClosestPointsToOriginSorting
{
    public int[][] KClosest(int[][] points, int k)
    {
        Array.Sort(points, Comparer<int[]>.Create((a, b) => Distance(a[0], a[1]).CompareTo(Distance(b[0], b[1]))));
        int[][] res = new int[k][];
        for (int i = 0; i < k; i++)
        {
            res[i] = points[i];
        }

        return res;
    }

    private double Distance(int x, int y)
    {
        return Math.Sqrt(x * x + y * y);
    }
}
