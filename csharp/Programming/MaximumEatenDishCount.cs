using System;

namespace Programming;

public class MaximumEatenDishCount
{
    /// <summary>
    /// Also known as Kaitenzushi.
    /// </summary>
    public static int GetMaximumEatenDishCount(int n, int[] d, int k)
    {
        int count = 0;
        var eatenDishes = new HashSet<int>();
        var eatenQueue = new Queue<int>();

        for (int i = 0; i < d.Length; i++)
        {
            int dish = d[i];

            if (eatenDishes.Add(dish))
            {
                count++;
                eatenQueue.Enqueue(dish);
                if (eatenDishes.Count > k)
                {
                    int dishToRemove = eatenQueue.Dequeue();
                    eatenDishes.Remove(dishToRemove);
                }
            }
        }

        return count;
    }
}
