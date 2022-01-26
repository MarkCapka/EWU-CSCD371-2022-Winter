namespace Logger
{
    public abstract class BaseLogger
    {
        public string? CallingClassName { get; set; }

        public abstract void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerFilePath] string loggedBy = "");
    }
}
