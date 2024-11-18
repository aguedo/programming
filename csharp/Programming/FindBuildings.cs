namespace Programming;

public class FindBuildings
{
    public int[] FindBuildingsImp(int[] heights)
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(heights.Length - 1);
        for (int i = heights.Length - 2; i >= 0; i--)
        {
            if (heights[i] > heights[stack.Peek()])
            {
                stack.Push(i);
            }
        }

        int[] buildings = new int[stack.Count];
        for (int i = 0; i < buildings.Length; i++)
        {
            buildings[i] = stack.Pop();
        }

        return buildings;
    }
}
