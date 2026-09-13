using System;

static class LogLine
{
    public static string Message(string logLine)
    {
        int colonIndex = logLine.IndexOf(':');
        
        string message = logLine.Substring(colonIndex + 1);
        
        return message.Trim();
    }

    public static string LogLevel(string logLine)
    {
        int closingBracketIndex = logLine.IndexOf(']');
        
        string level = logLine.Substring(1, closingBracketIndex - 1);
        
        return level.ToLower();
    }

    public static string Reformat(string logLine)
    {
        return $"{Message(logLine)} ({LogLevel(logLine)})";
    }
    public static void Main()
    {
        Console.WriteLine(LogLine.Message("[ERROR]: Invalid operation"));
        Console.WriteLine(LogLine.LogLevel("[ERROR]: Invalid operation"));
        Console.WriteLine(LogLine.Reformat("[INFO]: Operation completed"));
    }
}
