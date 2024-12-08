namespace Programming;

public class TakeKOfEachCharacterFromLeftAndRightRecursive
{
    private string _s;
    private int _k;
    private bool _found;

    /// <summary>
    /// Fails for large inputs.
    /// </summary>
    public int TakeCharacters(string s, int k)
    {
        _s = s;
        _k = k;
        _found = false;

        int count = TakeCharacters(0, s.Length - 1, k, k, k);
        return _found ? count : -1;
    }

    public int TakeCharacters(int left, int right, int a, int b, int c)
    {
        if (a <= 0 && b <= 0 && c <= 0)
        {
            _found = true;
            return 0;
        }

        if (left > right)
        {
            return 0;
        }

        int takingLeft = 1;
        if (_s[left] == 'a')
        {
            takingLeft += TakeCharacters(left + 1, right, a - 1, b, c);
        }
        else if (_s[left] == 'b')
        {
            takingLeft += TakeCharacters(left + 1, right, a, b - 1, c);
        }
        else if (_s[left] == 'c')
        {
            takingLeft += TakeCharacters(left + 1, right, a, b, c - 1);
        }

        int takingRight = 1;
        if (_s[right] == 'a')
        {
            takingRight += TakeCharacters(left, right - 1, a - 1, b, c);
        }
        else if (_s[right] == 'b')
        {
            takingRight += TakeCharacters(left, right - 1, a, b - 1, c);
        }
        else if (_s[right] == 'c')
        {
            takingRight += TakeCharacters(left, right - 1, a, b, c - 1);
        }

        return Math.Min(takingLeft, takingRight);
    }
}
