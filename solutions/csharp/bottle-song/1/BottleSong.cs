using System.Collections.Generic;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        IEnumerable<string> song;
        static string ToWord(int n)
        {
            return n switch
            {
                0 => "no green bottles",
                1 => "One green bottle",
                2 => "Two green bottles",
                3 => "Three green bottles",
                4 => "Four green bottles",
                5 => "Five green bottles",
                6 => "Six green bottles",
                7 => "Seven green bottles",
                8 => "Eight green bottles",
                9 => "Nine green bottles",
                10 => "Ten green bottles"
            };
        }
        
        for (int i = 0; i < takeDown; i++)
        {
            int current = startBottles - i;
            int next = current - 1;
    
            yield return $"{ToWord(current)} hanging on the wall,";
            yield return $"{ToWord(current)} hanging on the wall,";
            yield return "And if one green bottle should accidentally fall,";
            yield return $"There'll be {ToWord(next).ToLower()} hanging on the wall.";
    
            if (i < takeDown - 1)
                yield return ""; // blank line between verses
        
        }
    }
}
