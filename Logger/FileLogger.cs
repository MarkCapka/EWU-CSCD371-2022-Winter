namespace Logger;
public class ConsoleLogger : BaseLogger
{ 

    public override void Log(LogLevel logLevel, string message)
    {
        string logEvent = $"{DateTime.Now} {nameof(ConsoleLogger)} {logLevel}: {message}\n";
        System.Console.WriteLine(logEvent);
   }
}
