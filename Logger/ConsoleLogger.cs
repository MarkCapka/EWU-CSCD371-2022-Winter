namespace Logger;

public class ConsoleLogger : BaseLogger
{

    private readonly IConsoleIO? ConsoleIO;

    public ConsoleLogger()
    {
        ConsoleIO? consoleIO = new ConsoleIO();
    }

    public ConsoleLogger(IConsoleIO? consoleIO)
    {
        ConsoleIO = consoleIO;
    }

    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerFilePath] string loggedBy = "")
    {
        string logEvent = $"{DateTime.Now} {loggedBy} {logLevel}: {message}\n";
        ConsoleIO?.WriteLine(logEvent);

    }
}