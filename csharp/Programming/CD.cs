using System.Text;

namespace Programming;

public class CD
{
    public static string CDImp(string cwd, string arg)
    {
        var stack = new Stack<string>();
        if (arg[0] != '/')
        {
            string[] cwdArr = cwd.Split("/");
            for (int i = 1; i < cwdArr.Length; i++)
            {
                string s = cwdArr[i];
                stack.Push(s);
            }
        }

        string[] argArr = arg.Split("/");
        foreach (string s in argArr)
        {
            if (s == "..")
            {
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (s != "." && s != string.Empty)
            {
                stack.Push(s);
            }
        }

        StringBuilder sb = new StringBuilder();
        sb.Append('/');
        string[] reversedArr = stack.Reverse().ToArray();
        for (int i = 0; i < reversedArr.Length; i++)
        {
            sb.Append(reversedArr[i]);
            if (i != reversedArr.Length - 1)
            {
                sb.Append('/');

            }
        }

        return sb.ToString();
    }

    public static void Test()
    {
        string res1 = CDImp("/bar/a", "a/../b/c/../");
        System.Console.WriteLine(res1);
    }
}
