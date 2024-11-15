namespace Programming;

public class IntervalIntersection
{
    public int[][] IntervalIntersectionRefactored(int[][] firstList, int[][] secondList)
    {
        int fIndex = 0;
        int sIndex = 0;
        List<int[]> res = new List<int[]>();

        while (fIndex < firstList.Length && sIndex < secondList.Length)
        {
            int fStart = firstList[fIndex][0];
            int fEnd = firstList[fIndex][1];
            int sStart = secondList[sIndex][0];
            int sEnd = secondList[sIndex][1];

            int start = Math.Max(fStart, sStart);
            int end = Math.Min(fEnd, sEnd);

            if (start <= end)
            {
                res.Add(new int[] { start, end });
            }

            if (fEnd < sEnd)
            {
                fIndex++;
            }
            else
            {
                sIndex++;
            }
        }

        return res.ToArray();
    }

    public int[][] IntervalIntersectionImp(int[][] firstList, int[][] secondList)
    {
        int fIndex = 0;
        int sIndex = 0;
        List<int[]> res = new List<int[]>();

        while (fIndex < firstList.Length && sIndex < secondList.Length)
        {
            var fInterval = firstList[fIndex];
            int fStart = fInterval[0];
            int fEnd = fInterval[1];
            var sInterval = secondList[sIndex];
            int sStart = sInterval[0];
            int sEnd = sInterval[1];
            int[] intersection = null;

            if (fEnd < sStart)
            {
                // Case 1
                // a = |----|
                // b =         |-----|
                fIndex++;
            }
            else if (fStart <= sStart && sStart <= fEnd && fEnd <= sEnd)
            {
                // Case 2
                // a = |----|
                // b =    |-----|
                fIndex++;
                intersection = new int[] { sStart, fEnd };
            }
            else if (fStart <= sStart && fEnd >= sEnd)
            {
                // Case 3
                // a =  |-------|
                // b =    |---|
                sIndex++;
                intersection = new int[] { sStart, sEnd };
            }
            else if (fStart >= sStart && fEnd <= sEnd)
            {
                // Case 4
                // a =    |---|
                // b =  |-------|
                fIndex++;
                intersection = new int[] { fStart, fEnd };
            }
            else if (fStart >= sStart && fStart <= sEnd && fEnd >= sEnd)
            {
                // Case 5
                // a =   |------|
                // b = |----|
                sIndex++;
                intersection = new int[] { fStart, sEnd };
            }
            else
            {
                // Case 6
                // a =         |---|
                // b = |---|
                sIndex++;
            }

            if (intersection != null)
            {
                res.Add(intersection);
            }
        }

        return res.ToArray();
    }

}
