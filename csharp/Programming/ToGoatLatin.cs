using System.Text;

namespace Programming;

public class ToGoatLatin
{
    public string ToGoatLatinImp(string sentence)
    {
        StringBuilder sb = new StringBuilder();
        StringBuilder sbA = new StringBuilder("a");
        HashSet<char> vowels = new HashSet<char>() { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
        bool startOfWord = true;
        char sufix = '-';

        for (int i = 0; i < sentence.Length; i++)
        {
            char c = sentence[i];

            if (startOfWord)
            {
                if (vowels.Contains(c))
                {
                    sufix = '-';
                    sb.Append(c);
                }
                else
                {
                    sufix = c;
                }

                startOfWord = false;
            }
            else if (c == ' ')
            {
                EndOfWord(sb, sufix, sbA);
                sb.Append(' ');
                sbA.Append('a');
                startOfWord = true;
            }
            else
            {
                sb.Append(c);
            }
        }

        EndOfWord(sb, sufix, sbA);
        return sb.ToString();
    }

    private void EndOfWord(StringBuilder sb, char sufix, StringBuilder sbA)
    {
        if (sufix != '-')
        {
            sb.Append(sufix);
        }

        sb.Append("ma");
        sb.Append(sbA.ToString());
    }
}
