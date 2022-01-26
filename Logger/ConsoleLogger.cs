namespace Logger;

public class ConsoleLogger : BaseLogger
{

    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerMemberName] string loggedBy = "")
    {
        string logEvent = $"{DateTime.Now} {loggedBy} {logLevel}: {message}\n";
        System.Console.WriteLine(logEvent);
    }
}