public static class SecretHandshake
{
    public static string[] Commands(int commandValue)
    {
        string command = Convert.ToString(commandValue, 2).PadLeft(5, '0');
        var secretCommands = new List<string>();
        if (command[4] == '1') secretCommands.Add("wink") ;
        if (command[3] == '1') secretCommands.Add("double blink");
        if (command[2] == '1') secretCommands.Add("close your eyes");
        if (command[1] == '1') secretCommands.Add("jump");
        if (command[0] == '1') secretCommands.Reverse();

        return secretCommands.ToArray();
        
    }
}
