namespace Logger;

public class ConsoleLogger : BaseLogger
{

    private readonly IExecuteProcessActivity? ExecuteProcessActivity;

    public ConsoleLogger()
    {
        ConsoleLogger? logger = new();
    }

    public ConsoleLogger(ConsoleLogger? logger)
    {
        ExecuteProcessActivity = (IExecuteProcessActivity?)logger;
    }

    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerFilePath] string loggedBy = "")
    {
        string logEvent = $"{DateTime.Now} {loggedBy} {logLevel}: {message}\n";
        Console.WriteLine(logEvent);

    }





}