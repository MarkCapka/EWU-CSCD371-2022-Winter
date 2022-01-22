
namespace Logger
{
    public class LogFactory
    {
        public bool IsConfigured { get; private set; }
        private string? _filePath;

        public LogFactory()
        {
            IsConfigured = false;
        }

        public void ConfigureFileLogger(string path)
        {
            IsConfigured = true;
            _filePath = path;
        }

        public BaseLogger CreateLogger(string className)
        {
            if (!IsConfigured)
            {
                return null!;
            }
            BaseLogger fileLogger = new FileLogger(_filePath!)
            {
                ClassName = className,
            };
            return fileLogger;
        }





    }
}


