namespace Programming;

public class ScoreboardInferenceChapter1
{
    public static int GetMinProblemCount(int n, int[] s)
    {
        bool hasOdd = false;
        int max = int.MinValue;

        foreach (int score in s)
        {
            if (score > max)
            {
                max = score;
            }

            if (!hasOdd && score % 2 == 1)
            {
                hasOdd = true;
            }
        }

        return (max / 2) + (hasOdd ? 1 : 0);
    }
}
