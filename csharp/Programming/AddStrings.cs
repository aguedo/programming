using System.Text;

namespace Programming;

public class AddStrings
{
    public string AddStringsImp(string num1, string num2)
    {
        List<char> res = new List<char>();
        int index1 = num1.Length - 1;
        int index2 = num2.Length - 1;
        int carry = 0;

        while (index1 >= 0 || index2 >= 0)
        {
            int dig1 = 0;
            if (index1 >= 0)
            {
                dig1 = num1[index1] - '0';
            }

            int dig2 = 0;
            if (index2 >= 0)
            {
                dig2 = num2[index2] - '0';
            }

            int sum = dig1 + dig2 + carry;
            if (sum >= 10)
            {
                carry = 1;
                sum -= 10;
            }
            else
            {
                carry = 0;
            }

            res.Add((char)(sum + '0'));

            index1--;
            index2--;
        }

        if (carry > 0)
        {
            res.Add('1');
        }

        StringBuilder sb = new StringBuilder();
        for (int i = res.Count - 1; i >= 0; i--)
        {
            sb.Append(res[i]);
        }

        return sb.ToString();
    }
}
