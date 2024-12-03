using System.Text;

namespace Programming;

public class SimplifyPath
{
    public static string SimplifyPathImp(string path)
    {
        string[] pathArr = path.Split("/");
        var stack = new Stack<string>();

        for (int i = 1; i < pathArr.Length; i++)
        {
            string s = pathArr[i]; // c
            if (s == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (!string.IsNullOrEmpty(s) && s != ".")
            {
                stack.Push(s);
            }
        }

        if (stack.Count == 0)
        {
            return "/";
        }

        StringBuilder sb = new StringBuilder();
        foreach (string s in stack.Reverse())
        {
            sb.Append("/");
            sb.Append(s);
        }

        return sb.ToString();
    }
}
