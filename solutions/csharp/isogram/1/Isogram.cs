public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var letters = word.ToLower().Where(char.IsLetter);
        bool result = letters.Distinct().Count() == letters.Count();
            
        return result;
    }
}
