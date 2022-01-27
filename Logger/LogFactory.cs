
namespace Logger;
    public class LogFactory
    {
        public bool FileLoggerIsConfigured { get; private set; }
        private string? _filePath;

        public LogFactory()
        {
            FileLoggerIsConfigured = false;
        }

        public void ConfigureFileLogger(string path)
        {
            FileLoggerIsConfigured = true;
            _filePath = path;
        }

        public BaseLogger? CreateLogger(string className)
        {
            switch (className)
            {
            case "FileLogger":
                if (FileLoggerIsConfigured)
                {
                    return new FileLogger(_filePath!);
                }
                break;
            case "ConsoleLogger":
                    return new ConsoleLogger();        //TODO I think the issue is with passing a parameter here. 
            }
            return null;
        }
    }



