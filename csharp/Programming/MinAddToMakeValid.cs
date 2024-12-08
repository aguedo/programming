namespace Programming;

public class MinAddToMakeValid
{
    public int MinAddToMakeValidImp(string s)
    {
        int minAddToMakeValid = 0;
        int balance = 0;

        foreach (char c in s)
        {
            if (c == '(')
            {
                balance++;
            }
            else
            {
                balance--;
            }

            if (balance < 0)
            {
                minAddToMakeValid++;
                balance++;
            }
        }

        return minAddToMakeValid + balance;
    }
}
