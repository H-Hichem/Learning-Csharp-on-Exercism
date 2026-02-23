public static class Pangram
{
    public static bool IsPangram(string input)
    {

        bool[] letters = new bool[26];
        input = input.ToLower();
    
        foreach (char c in input)
        {
            if (c >= 'a' && c <= 'z')
                letters[c - 'a'] = true;
        }
    
        return letters.All(x => x);

    }
}
