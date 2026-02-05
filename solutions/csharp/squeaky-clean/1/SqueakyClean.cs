public static class Identifier
{
    public static string Clean(string identifier)
    {
        string result ="";
        bool capitalizeNext = false;
        foreach (char c in identifier)
        {
            if (capitalizeNext is true)
            {
                result += char.ToUpper(c);
                capitalizeNext = false;
                continue;
            }
            else if (c == '-'){capitalizeNext = true;}
            else if (c == ' '){result += '_';}
            else if (char.IsControl(c)){result += "CTRL";}
            else if (!char.IsLetter(c))continue;
            else if (c >= 'α' && c <= 'ω') continue;
            
            else result +=c;
        }
        return result;
    }
}
