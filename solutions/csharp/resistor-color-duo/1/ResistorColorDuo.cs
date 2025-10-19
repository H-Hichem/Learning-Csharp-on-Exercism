public static class ResistorColorDuo
{
    private static readonly Dictionary<string, int> colorMap = new()
        {{ "black", 0 },
        { "brown", 1 },
        { "red", 2 },
        { "orange", 3 },
        { "yellow", 4 },
        { "green", 5 },
        { "blue", 6 },
        { "violet", 7 },
        { "grey", 8 },
        { "white", 9 }};
    
    public static int Value(string[] colors)
    {
        int value1 = colorMap[colors[0].ToLower()];
        int value2 = colorMap[colors[1].ToLower()];

        return value1 * 10 + value2;
    }
}
