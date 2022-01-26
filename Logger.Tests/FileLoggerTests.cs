using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class FileLoggerTests
{
    public static string TEST_FILE = "testLogFile.txt";

    [TestMethod]
    public void SetFilePath_ConfigureFileLoggerSetsFilePath_Success()
    {
        File.Delete(TEST_FILE);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(TEST_FILE);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        Assert.IsFalse(File.Exists(TEST_FILE));

        logFactory.ConfigureFileLogger(TEST_FILE);

        Assert.AreEqual(((FileLogger)loggerWithFile).FilePath, "testLogFile.txt");
    }

    [TestMethod]
    public void Log_LogFunctionCreatesFileWhenFileDoesntExist_Success()
    {
        File.Delete(TEST_FILE);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(TEST_FILE);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        Assert.IsFalse(File.Exists(TEST_FILE));

        loggerWithFile.Log(LogLevel.Information, "This log will instantiate a file at the given path.");

        Assert.IsTrue(File.Exists(TEST_FILE));
        File.Delete(TEST_FILE);
    }

    [TestMethod]
    public void Log_LogFunctionAppendsToFileWhenFileExist_Success()
    {
        File.Delete(TEST_FILE);
        LogFactory logFactory = new LogFactory();
        logFactory.ConfigureFileLogger(TEST_FILE);
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;
        string originalMessage = "This log will instantiate a file at the given path.";
        loggerWithFile.Log(LogLevel.Information, originalMessage);
        Assert.IsTrue(File.Exists(TEST_FILE));

        string appendedMessage = "This log will be appended to the file";
        loggerWithFile.Log(LogLevel.Information, appendedMessage);

        string[] fileContents = File.ReadAllLines(TEST_FILE);

        Assert.IsTrue(fileContents[0].Contains($"FileLoggerTests Information: {originalMessage}"));
        Assert.IsTrue(fileContents[1].Contains($"FileLoggerTests Information: {appendedMessage}"));
        File.Delete(TEST_FILE);
    }
}

