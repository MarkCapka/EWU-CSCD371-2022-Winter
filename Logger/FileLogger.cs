using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//Assignment 2: .NET PROGRAMMING CSCD371
//Tyler Rose & Mark Capka           //--students
//@TylerRose8    //@MarkCapka      //--github

//.NET 6.0  MSTest Visual Studio 2022

namespace Logger;
public class FileLogger : BaseLogger
{
    public string FilePath { get; }

    public FileLogger(string filePath)
    {
        FilePath = filePath;
    }

    public override void Log(LogLevel logLevel, string message, [System.Runtime.CompilerServices.CallerFilePath] string loggedBy = "")
    {
        string loggedByFileName = loggedBy.Substring(loggedBy.LastIndexOf("\\"), loggedBy.LastIndexOf("."));
        string logEvent = $"{DateTime.Now} {loggedByFileName} {logLevel}: {message}\n";
        File.AppendAllText(FilePath, logEvent);
    }
}
