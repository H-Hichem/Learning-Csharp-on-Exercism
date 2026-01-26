public static class ScrabbleScore
{
    public static int Score(string input)
    {
        input = input.ToLower(); 
    
        return input.Sum(c => c switch
        {
            'd' or 'g' => 2,
            'b' or 'c' or 'm' or 'p' => 3,
            'f' or 'h' or 'v' or 'w' or 'y' => 4,
            'k' => 5,
            'j' or 'x' => 8,
            'q' or 'z' => 10,
            _ => 1  // default for all other characters
        });
    }
}