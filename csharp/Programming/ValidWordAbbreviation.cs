namespace Programming;

public class ValidWordAbbreviation
{
    public static bool ValidWordAbbreviationImp(string word, string abbr)
    {
        int wordIndex = 0;
        int abbrIndex = 0;

        while (wordIndex < word.Length && abbrIndex < abbr.Length)
        {
            if (abbr[abbrIndex] == '0')
            {
                return false;
            }

            int number = 0;
            int numLen = 1;
            while (abbrIndex < abbr.Length && char.IsDigit(abbr[abbrIndex])) // Parse the number.
            {
                int digit = abbr[abbrIndex] - '0';
                number *= numLen;
                number += digit;
                numLen *= 10;
                abbrIndex++;
            }

            wordIndex += number;
            if (wordIndex >= word.Length || abbrIndex >= abbr.Length)
            {
                break;
            }

            if (word[wordIndex] != abbr[abbrIndex])
            {
                return false;
            }

            wordIndex++;
            abbrIndex++;
        }

        return wordIndex == word.Length && abbrIndex == abbr.Length;
    }
}
