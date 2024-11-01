using System;

namespace Programming;

public class RotationalCipher
{
    /// <summary>
    /// Cipher the input string using the rotation factor.
    /// </summary>
    public static string RotationalCipherImp(string input, int rotationFactor)
    {
        char[] charArr = new char[input.Length];

        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (char.IsLetterOrDigit(c))
            {
                charArr[i] = Rotate(c, rotationFactor);
            }
            else
            {
                charArr[i] = c;
            }
        }

        return new string(charArr);
    }

    private static char Rotate(char c, int rotationFactor)
    {
        int firstCharIndex = 'a';
        int charCount = 'z' - 'a' + 1;
        if (char.IsDigit(c))
        {
            firstCharIndex = '0';
            charCount = 10;
        }
        else if (char.IsUpper(c))
        {
            firstCharIndex = 'A';
            charCount = 'Z' - 'A' + 1;
        }

        int charIndex = c - firstCharIndex;
        int nextIndex = (charIndex + rotationFactor) % charCount;
        return (char)(nextIndex + firstCharIndex);
    }

    public static void Test()
    {
        string res = RotationalCipherImp("Zebra-493?", 3);
        Console.WriteLine(res);
        Console.WriteLine(res == "Cheud-726?");

        string res2 = RotationalCipherImp("abcdefghijklmNOPQRSTUVWXYZ0123456789", 39);
        Console.WriteLine(res2);
        Console.WriteLine(res2 == "nopqrstuvwxyzABCDEFGHIJKLM9012345678");
    }
}
