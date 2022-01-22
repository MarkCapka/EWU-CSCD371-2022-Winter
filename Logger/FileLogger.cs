using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger;
internal class FileLogger : BaseLogger
{
    public string FilePath { get; }

    public FileLogger(string filePath)
    {
        FilePath = filePath;
        
    }

    public override void Log(LogLevel logLevel, string message)
    {
        string logEvent = $"{DateTime.Now} {ClassName} {logLevel}: {message}\n";
        File.AppendAllText(FilePath, logEvent);
   }
}
