namespace Programming;

public class InsertDeleteGetRandom
{
    private List<int> _vals;
    private Dictionary<int, int> _indexMap;
    private Random _random;

    public InsertDeleteGetRandom()
    {
        _vals = new List<int>();
        _indexMap = new Dictionary<int, int>();
        _random = new Random();
    }

    public bool Insert(int val)
    {
        if (_indexMap.ContainsKey(val))
        {
            return false;
        }

        _indexMap[val] = _vals.Count;
        _vals.Add(val);
        return true;
    }

    public bool Remove(int val)
    {
        if (!_indexMap.ContainsKey(val))
        {
            return false;
        }

        int valIndex = _indexMap[val];
        int lastIndex = _vals.Count - 1;
        int lastVal = _vals[lastIndex];

        _indexMap[lastVal] = valIndex;
        _vals[valIndex] = lastVal;
        _indexMap.Remove(val);
        _vals.RemoveAt(lastIndex);

        return true;
    }

    public int GetRandom()
    {
        int index = _random.Next(_vals.Count);
        return _vals[index];
    }
}
