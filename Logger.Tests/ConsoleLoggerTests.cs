using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Logger.Tests;
[TestClass]
public class ConsoleLoggerTests
{

    [TestMethod]
    public void Log_LogFunctionWritesToConsole_Success()
    {

        //arrange
      
        string message = "This log will be written to the console.";
        logger.Log(LogLevel.Information, message);

        //TODO -- Assert something

        Assert.IsTrue(logger.Contains($"FileLoggerTests Information: {message}"));
    }


}

