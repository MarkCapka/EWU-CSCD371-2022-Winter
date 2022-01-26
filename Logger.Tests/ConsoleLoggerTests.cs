using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests;
[TestClass]
public class ConsoleLoggerTests
{

    [TestMethod]
    public void Log_LogFunctionWritesToConsole_Success()
    {
        LogFactory logFactory = new LogFactory();
        BaseLogger logger = logFactory.CreateLogger(nameof(ConsoleLogger))!;
        string message = "This log will be written to the console.";
        logger.Log(LogLevel.Information, message);
        
        //TODO -- Assert something
    }
}

