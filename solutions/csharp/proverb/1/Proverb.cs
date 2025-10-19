public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0) return Array.Empty<string>();
    
        var lines = subjects.Take(subjects.Length - 1)                 
            .Select((subject, index) => $"For want of a {subject} the {subjects[index +1]} was lost.")
            .ToList();
    
        lines.Add($"And all for the want of a {subjects[0]}.");
    
        return lines.ToArray();
    }
}