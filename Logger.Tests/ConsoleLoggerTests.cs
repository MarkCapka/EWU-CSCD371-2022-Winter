using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Logger.Tests;
[TestClass]
public class ConsoleLoggerTests
{

    [TestMethod]
    public void Log_LogFunctionWritesToConsole_Success()
    {

        //arrange
        ConsoleLogger? logger = new();
        string message = "This log will be written to the console.";

        //TODO -- Assert something

        //Console redirect code: https://stackoverflow.com/a/11911722
        var originalConsoleOut = Console.Out; // preserve the original stream
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);

            //Console.WriteLine("some stuff"); // or make your DLL calls :)
            logger.Log(LogLevel.Information, message);

            writer.Flush(); // when you're done, make sure everything is written out

            var myString = writer.GetStringBuilder().ToString();
            Assert.AreEqual(message, myString);
        }

        Console.SetOut(originalConsoleOut);
    }


}

