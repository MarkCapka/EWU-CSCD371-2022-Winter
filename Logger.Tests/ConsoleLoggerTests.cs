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


        var mockConsoleIO = new Mock<IConsoleIO>();
        mockConsoleIO.Setup(x => x.ReadLine()).Returns(message);
        var consoleLogger = new ConsoleLogger(mockConsoleIO.Object);
        
        //act
        consoleLogger.Log(LogLevel.Information, message);



        // Assert 
        mockConsoleIO.Verify(x => x.WriteLine("This log will be written to the console."), Times.Once()); 


    }


}

