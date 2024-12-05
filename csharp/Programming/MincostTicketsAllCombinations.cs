using System;

namespace Programming;

public class MincostTicketsAllCombinations
{
    private int[] _best;

    public int MincostTickets(int[] days, int[] costs)
    {
        _best = new int[days.Length];
        return MincostTickets(days, costs, 0);
    }

    public int MincostTickets(int[] days, int[] costs, int index)
    {
        if (index == days.Length)
        {
            return 0;
        }

        if (_best[index] > 0)
        {
            return _best[index];
        }

        int oneDayCost = costs[0] + MincostTickets(days, costs, index + 1);

        int sevenDaysIndex = ShiftDays(days, index, 7);
        int sevenDayCost = costs[1] + MincostTickets(days, costs, sevenDaysIndex);

        int thirtyDaysIndex = ShiftDays(days, index, 30);
        int thirtyDayCost = costs[2] + MincostTickets(days, costs, thirtyDaysIndex);

        int min = Math.Min(Math.Min(oneDayCost, sevenDayCost), thirtyDayCost);
        _best[index] = min;
        return min;
    }

    private int ShiftDays(int[] days, int index, int shift)
    {
        int day = days[index];
        index++;

        while (index < days.Length && days[index] - day < shift)
        {
            index++;
        }

        return index;
    }
}
