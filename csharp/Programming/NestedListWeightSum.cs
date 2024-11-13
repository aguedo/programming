using System;

namespace Programming;

public class NestedListWeightSum
{
    private int _total;

    public int DepthSum(IList<NestedInteger> nestedList)
    {
        _total = 0;
        DepthSumHelper(nestedList, 1);
        return _total;
    }

    public void DepthSumHelper(IList<NestedInteger> nestedList, int depth)
    {
        foreach (var item in nestedList)
        {
            if (item.IsInteger())
            {
                _total += (item.GetInteger() * depth);
            }
            else
            {
                DepthSumHelper(item.GetList(), depth + 1);
            }
        }
    }

    public interface NestedInteger
    {
        bool IsInteger();

        int GetInteger();

        IList<NestedInteger> GetList();
    }
}
