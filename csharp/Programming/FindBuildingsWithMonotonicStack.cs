using System;

namespace Programming;

public class FindBuildingsWithMonotonicStack
{
    public int[] FindBuildings(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < heights.Length; i++)
        {
            int height = heights[i];
            while (stack.Count > 0 && heights[stack.Peek()] <= height)
            {
                stack.Pop();
            }

            stack.Push(i);
        }

        int[] buildings = new int[stack.Count];
        for (int i = buildings.Length - 1; i >= 0; i--)
        {
            buildings[i] = stack.Pop();
        }

        return buildings;
    }
}
