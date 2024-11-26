using System.Text;

namespace Programming;

public class LongestCommonPrefix
{
    public string LongestCommonPrefixImp(string[] strs)
    {
        StringBuilder sb = new StringBuilder();

        int index = 0;
        while (true)
        {
            char c = default;
            foreach (string s in strs)
            {
                if (index >= s.Length)
                {
                    return sb.ToString();
                }

                if (c == default)
                {
                    c = s[index];
                }
                else if (c != s[index])
                {
                    return sb.ToString();
                }
            }

            index++;
            sb.Append(c);
        }
    }
}
