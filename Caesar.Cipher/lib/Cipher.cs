namespace Caesar.Cipher.lib;
using System.Text;
public static class Cipher
{
    private readonly static int AlphabetLength = 26;
    public static string Crypt(int key, string text)
    {
        int validKey = ParseKey(key, AlphabetLength);
        StringBuilder result = new();
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int position = (c - BaseChar(c) + validKey) % AlphabetLength;
                char newChar = (char)(BaseChar(c) + position);
                result.Append(newChar);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
    public static string DeCrypt(int key, string text)
    {
        int validKey = ParseKey(key, AlphabetLength);
        StringBuilder result = new();
        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                int position = (c - BaseChar(c) - validKey) % AlphabetLength;
                position = position < 0 ? position += AlphabetLength : position;
                char newChar = (char)(BaseChar(c) + position);
                result.Append(newChar);
            }
            else
            {
                result.Append(c);
            }
        }
        return result.ToString();
    }
    private static int ParseKey(int key, int alphabetLength)
    {
        int result = key %= alphabetLength;
        if (result < 0)
        {
            result += alphabetLength;
        }
        return result;
    }
    private static char BaseChar(char c)
    {
        return char.IsUpper(c) ? 'A' : 'a';
    }
}