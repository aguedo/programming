namespace Programming;

public class ScoreboardInferenceChapter2
{
    public static int GetMinProblemCount(int n, int[] s)
    {
        bool rest0 = false;
        int rest1 = 0;
        int rest2 = 0;
        int secondMax = 0;
        int max = int.MinValue;
        int min = int.MaxValue;
        const int maxPointValue = 3;

        foreach (int score in s)
        {
            if (score > max)
            {
                secondMax = max;
                max = score;
            }

            if (score < min)
            {
                min = score;
            }

            if (rest0 && score % maxPointValue == 0)
            {
                rest0 = true;
            }

            if (score % maxPointValue == 1)
            {
                rest1++;
            }

            if (rest2 == 0 && score % maxPointValue == 2)
            {
                rest2 = 1;
            }
        }

        if (rest2 > 0 && rest1 > 0 && min > 1)
        {
            rest2 = 2;
            rest1 = 0;
        }
        else if (rest1 > 0)
        {
            rest1 = 1;
        }

        int combine = 0;
        if ((rest1 == 1 && rest2 == 1 && max % maxPointValue == 0) ||        // Combine a '2' and a '1' to make a '3'.
            (rest2 == 2 && max % maxPointValue == 1 && secondMax < max - 1)) // Combine two '2' to make a '4' 
        {                                                                    // Only if the second max doesn need a '3'.
            combine = 1;
        }

        return (max / maxPointValue) + rest1 + rest2 - combine;
    }
}
