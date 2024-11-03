using System;

namespace Programming;

public class ArtisticPhotographCountNaive
{
    public static int GetArtisticPhotographCount(int n, string c, int x, int y)
    {
        int count = 0;

        for (int i = 0; i < c.Length; i++)
        {
            if (c[i] == 'P' || c[i] == 'B')
            {
                count += GetArtisticPhotographFrom(i, c, x, y);
            }
        }

        return count;
    }

    private static int GetArtisticPhotographFrom(int start, string c, int x, int y)
    {
        int count = 0;
        char leftCell = c[start];
        char rightCell = leftCell == 'B' ? 'P' : 'B';
        int firstAIndex = start + x;
        int lastAIndex = start + y;
        for (int i = firstAIndex; i < c.Length && i <= lastAIndex; i++)
        {
            if (c[i] == 'A')
            {
                count += GetArtisticPhotographTo(i, c, rightCell, x, y);
            }
        }

        return count;
    }

    private static int GetArtisticPhotographTo(int start, string c, char rightCell, int x, int y)
    {
        int count = 0;
        int firstAIndex = start + x;
        int lastAIndex = start + y;

        for (int i = firstAIndex; i < c.Length && i <= lastAIndex; i++)
        {
            if (c[i] == rightCell)
            {
                count++;
            }
        }

        return count;
    }
}
