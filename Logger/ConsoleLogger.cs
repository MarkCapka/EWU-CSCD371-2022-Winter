namespace Logger;

public class ConsoleLogger : BaseLogger
{
    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerFilePath] string loggedBy = "")
    {
        string loggedByFileName;
        if (string.IsNullOrEmpty(loggedBy))
        {
            loggedByFileName = "";
        }
        else
        {
            //use .Remove to delete everything before the file name, then use .Remove again to delete the file extension
            loggedByFileName = loggedBy.Remove(0, loggedBy.LastIndexOf("\\")+1);
            loggedByFileName = loggedByFileName.Remove(loggedByFileName.LastIndexOf("."));
        }
        string logEvent = $"{DateTime.Now} {loggedByFileName} {logLevel}: {message}\n";
        Console.WriteLine(logEvent);
    }
}