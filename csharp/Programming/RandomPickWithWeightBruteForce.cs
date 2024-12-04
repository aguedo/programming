namespace Programming;

public class RandomPickWithWeightBruteForce
{
    private int[] _w;
    private int _sum;
    private Random _random = new Random();

    public RandomPickWithWeightBruteForce(int[] w)
    {
        _w = w;
        _sum = _w.Sum();
    }

    public int PickIndex()
    {
        int r = _random.Next(1, _sum + 1);

        for (int i = 0; i < _w.Length; i++)
        {
            r -= _w[i];
            if (r <= 0)
            {
                return i;
            }
        }

        throw new Exception("Invalid sum.");
    }
}
