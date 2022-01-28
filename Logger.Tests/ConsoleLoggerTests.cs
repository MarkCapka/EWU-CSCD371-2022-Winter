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
        string? message = "This log will be written to the console.";
        logger.Log(LogLevel.Information, message);

        //TODO -- Assert something
        IExecuteProcessActivity? activity = new ExecuteProcessActivity("dotnet");
        Console.WriteLine("Invoking((IExecuteProcessActivity)activity).Run()");


        ((IExecuteProcessActivity?)activity.Run();
        Console.WriteLine("Invoking activity.Run()");
        activity.Run();

        Assert.AreEqual(activity.Run(), logger.Contains($"FileLoggerTests Information: {message}"));
    }


}

