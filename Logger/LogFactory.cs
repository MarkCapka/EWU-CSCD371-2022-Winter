
namespace Logger;
    public class LogFactory
    {
        public bool FileLoggerIsConfigured { get; private set; }
        private string? _FilePath;

        public LogFactory()
        {
            FileLoggerIsConfigured = false;
        }

        public void ConfigureFileLogger(string path)
        {
            FileLoggerIsConfigured = true;
            _FilePath = path;
        }

    public BaseLogger? CreateLogger(string className)
    {
        switch (className)
        {
            case "FileLogger":
                if (FileLoggerIsConfigured)
                {
                    return new FileLogger(_FilePath!);
                }
                break;
            case "ConsoleLogger":
                return new ConsoleLogger();
            }
            return null;
        }
    }



