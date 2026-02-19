public class Robot
{
    private static readonly HashSet<string> _usedNames = new();
    
    private string _name;
    
    public string Name => string.IsNullOrEmpty(_name)
        ? _name = GetOrGenerateUniqueName()
        : _name;
    
    private string GetOrGenerateUniqueName()
    {
        string candidate;
        do
        {candidate = GenerateRandomName();} 
        while (!_usedNames.Add(candidate));
    
        return candidate;
    }

    
    private string GenerateRandomName()
    {
        char letter1 = (char)('A' + Random.Shared.Next(26));
        char letter2 = (char)('A' + Random.Shared.Next(26));
        int digits = Random.Shared.Next(1000);
        return $"{letter1}{letter2}{digits:000}";
    }
    
    public Robot() { _ = Name; }
    
    public void Reset()
    {
        _usedNames.Remove(_name);
        _name = null;
    }

    
}
