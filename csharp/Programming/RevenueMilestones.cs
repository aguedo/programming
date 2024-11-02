namespace Programming;

class RevenueMilestones
{
    public static int[] GetMilestoneDays(int[] revenues, int[] milestones)
    {
        Milestone[] milestoneRefs = milestones
          .Select((m, i) => new Milestone { Index = i, Value = m })
          .OrderBy(m => m.Value)
          .ToArray();
        int milestoneIndex = 0;
        int totalRevenue = 0;
        int[] milestoneDays = new int[milestones.Length];

        for (int day = 0; day < revenues.Length; day++)
        {
            int revenue = revenues[day];
            totalRevenue += revenue;
            while (milestoneIndex < milestones.Length && totalRevenue >= milestoneRefs[milestoneIndex].Value)
            {
                milestoneDays[milestoneRefs[milestoneIndex].Index] = day + 1;
                milestoneIndex++;
            }

            if (milestoneIndex == milestones.Length)
            {
                return milestoneDays;
            }
        }

        for (int i = milestoneIndex; i < milestones.Length; i++)
        {
            milestoneDays[milestoneRefs[i].Index] = -1;
        }

        return milestoneDays;
    }

    public static void Test()
    {
        int[] days = GetMilestoneDays(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 }, new int[] { 100, 200, 10000, 500 });
        Console.WriteLine(string.Join(",", days));
    }

    class Milestone
    {
        public int Index { get; set; }
        public int Value { get; set; }
    }
}
