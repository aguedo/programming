using System.Data;
using System.Text;

namespace Programming;

public class ExpressionAddOperators
{
    private char[] _nums;
    private char[] _operators;
    private int _target;
    private IList<string> _res;
    DataTable _dt = new DataTable();

    public IList<string> AddOperators(string num, int target)
    {
        _target = target;
        _operators = new char[num.Length - 1];
        _nums = new char[num.Length];
        for (int i = 0; i < num.Length; i++)
        {
            _nums[i] = num[i];
        }

        _res = new List<string>();

        GenerateOperators(0);
        return _res;
    }

    private void GenerateOperators(int index)
    {
        if (index >= _operators.Length)
        {
            EvaluateExpression();
            return;
        }

        _operators[index] = '*';
        GenerateOperators(index + 1);

        _operators[index] = '+';
        GenerateOperators(index + 1);

        _operators[index] = '-';
        GenerateOperators(index + 1);

        _operators[index] = 'c';
        GenerateOperators(index + 1);
    }

    private void EvaluateExpression()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_nums[0]);
        bool leadingZero = _nums[0] == '0';

        for (int i = 0; i < _operators.Length; i++)
        {
            char op = _operators[i];
            char digit = _nums[i + 1];
            if (op != 'c')
            {
                sb.Append(op);
                if (digit == '0')
                {
                    leadingZero = true;
                }
                else
                {
                    leadingZero = false;
                }
            }
            else if (leadingZero)
            {
                return;
            }


            sb.Append(digit);
        }

        string expr = sb.ToString();
        try
        {
            int n = Convert.ToInt32(_dt.Compute(expr, ""));
            if (n == _target)
            {
                _res.Add(expr);
            }
        }
        catch (Exception ex)
        { }

    }
}
