using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class FileLoggerTests
{
    public const string _TestFile = "testLogFile.txt";

    [TestMethod]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "INTL0003:Methods PascalCase", Justification = "<Pending>")]
    public void SetFilePath_ConfigureFileLoggerSetsFilePath_Success()
    {
        File.Delete(_TestFile);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(_TestFile);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        Assert.IsFalse(File.Exists(_TestFile));

        logFactory.ConfigureFileLogger(_TestFile);

        Assert.AreEqual(((FileLogger)loggerWithFile).FilePath, "testLogFile.txt");
    }

    [TestMethod]
    public void Log_LogFunctionCreatesFileWhenFileDoesntExist_Success()
    {
        File.Delete(_TestFile);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(_TestFile);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        Assert.IsFalse(File.Exists(_TestFile));

        loggerWithFile.Log(LogLevel.Information, "This log will instantiate a file at the given path.");

        Assert.IsTrue(File.Exists(_TestFile));
        File.Delete(_TestFile);
    }

    [TestMethod]
    public void Log_LogFunctionAppendsToFileWhenFileExist_Success()
    {
        File.Delete(_TestFile);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(_TestFile);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        string originalMessage = "This log will instantiate a file at the given path.";
        loggerWithFile.Log(LogLevel.Information, originalMessage);
        Assert.IsTrue(File.Exists(_TestFile));

        string appendedMessage = "This log will be appended to the file";
        loggerWithFile.Log(LogLevel.Information, appendedMessage);

        string[] fileContents = File.ReadAllLines(_TestFile);

        Assert.IsTrue(fileContents[0].Contains($"FileLoggerTests Information: {originalMessage}"));
        Assert.IsTrue(fileContents[1].Contains($"FileLoggerTests Information: {appendedMessage}"));
        File.Delete(_TestFile);
    }
}

