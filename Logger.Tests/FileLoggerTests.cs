using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLoggerTests));
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
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLoggerTests));
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
        BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLoggerTests));
        string originalMessage = "This log will instantiate a file at the given path.";
        loggerWithFile.Log(LogLevel.Information, originalMessage);
        Assert.IsTrue(File.Exists(TEST_FILE));

        string appendedMessage = "This log will be appended to the file";
        loggerWithFile.Log(LogLevel.Information, appendedMessage);

        string[] fileContents = File.ReadAllLines(TEST_FILE);

        Assert.IsTrue(fileContents[0].Contains(originalMessage));
        Assert.IsTrue(fileContents[1].Contains(appendedMessage));
        File.Delete(TEST_FILE);
    }

    [TestMethod]
    [Ignore("Not Implemented Yet")]
    public void GetFilePath_ReturnsFileThatExists_Success()
    {
        // Arrange

        // Act
        //string filePath = Logger.GetFilePath();

        // Assert
        //Assert.IsTrue(File.Exists(filePath));
    }


    [TestMethod]
    [Ignore("Not Implemented Yet")]
    public void Log_AppendsFile_Success()
    {
        // Arrange

        //TODO

        // Act
        //TODO: load filepath
        // string filePath = Logger.GetFilePath();

        //TODO message outputs: 
        //current date/time                                 
        //name of the class created the logger
        //log level
        //message
        //format: "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"


        //TODO confirm that there is no overwrite of any previous messages. 

        //// Assert
        //Assert.IsTrue(File.Exists(filePath));
    }

}

