namespace Programming;

public class CalculateWithStack
{
    public static int Calculate(string s)
    {
        int index = 0;
        char op = '+';
        var stack = new Stack<int>();

        while (index < s.Length)
        {
            if (char.IsDigit(s[index]))
            {
                int number = 0;
                while (index < s.Length && s[index] == '0')
                {
                    index++; // Skip leading zeroes.
                }

                while (index < s.Length && char.IsDigit(s[index]))
                {
                    int digit = s[index] - '0';
                    number *= 10;
                    number += digit;
                    index++;
                }

                if (op == '+')
                {
                    stack.Push(number);
                }
                else if (op == '-')
                {
                    stack.Push(-number);
                }
                else
                {
                    int op1 = stack.Pop();
                    if (op == '*')
                    {
                        stack.Push(op1 * number);
                    }
                    else
                    {
                        stack.Push(op1 / number);
                    }
                }
            }
            else if (s[index] != ' ')
            {
                op = s[index];
                index++;
            }
            else
            {
                index++;
            }
        }

        int res = stack.Pop();

        while (stack.Count > 0)
        {
            res += stack.Pop();
        }

        return res;
    }
}
