using System.Text;

namespace Programming;

public class AddBlankSpaces
{
    public static string AddBlankSpacesImp(string str, ITrieNode root)
    {
        ITrieNode node = root;
        StringBuilder sb = new StringBuilder();
        int index = 0;

        while (index < str.Length)
        {
            char c = str[index];
            ITrieNode child = node.FindChild(c);
            if (child == null)
            {
                break;
            }

            sb.Append(c);

            if (child.IsEndOfWord)
            {
                sb.Append(' ');
                node = root;
            }
            else
            {
                node = child;
            }

            index++;
        }

        // Add the remainning characters that don't make a word.
        while (index < str.Length)
        {
            sb.Append(str[index]);
            index++;
        }

        return sb.ToString();
    }
}

public interface ITrieNode
{
    bool IsEndOfWord { get; }
    ITrieNode FindChild(char c);
}
