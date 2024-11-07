using System.Text;

namespace Programming;

public class MinRemoveToMakeValid
{
    public static string MinRemoveToMakeValidImp(string s)
    {
        var exclude = new bool[s.Length];
        var stack = new Stack<int>();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == '(')
            {
                stack.Push(i);
            }
            else if (c == ')')
            {
                if (stack.Count == 0)
                {
                    exclude[i] = true;
                }
                else
                {
                    stack.Pop();
                }
            }
        }

        while (stack.Count > 0)
        {
            exclude[stack.Pop()] = true;
        }

        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (!exclude[i])
            {
                sb.Append(s[i]);
            }
        }

        return sb.ToString();
    }
}
