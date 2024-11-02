using System;

namespace Programming;

class BillionUsers
{
    public static int GetBillionUsersDay(float[] growthRates)
    {
        double oneBillion = 1000000000.0;
        double totalUsers = 0;
        int time = 1;

        while (totalUsers < oneBillion)
        {
            time *= 2;
            totalUsers = ComputeTotalUsers(growthRates, time);
        }

        int start = time / 2;
        int end = time;

        while (start <= end)
        {
            int mid = start + (end - start) / 2;
            double numberOfUsers = ComputeTotalUsers(growthRates, mid);

            if (numberOfUsers == oneBillion)
            {
                return mid;
            }

            if (numberOfUsers > oneBillion)
            {
                end = mid - 1;
            }
            else
            {
                start = mid + 1;
            }
        }

        return end + 1;
    }

    private static double ComputeTotalUsers(float[] growthRates, int time)
    {
        double total = 0;

        foreach (float g in growthRates)
        {
            total += Math.Pow(g, time);
        }

        return total;
    }

    public static void Test()
    {
        int days = GetBillionUsersDay(new float[] { 1.5F });
        Console.WriteLine(days == 52);

        int days2 = GetBillionUsersDay(new float[] { 1.1F, 1.2F, 1.3F });
        Console.WriteLine(days2 == 79);
    }
}
