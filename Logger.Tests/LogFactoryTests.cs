using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void CreateLogger_ConfiguredLoggerReturnsLogger_Success()
        {
            LogFactory logFactory = new LogFactory();

            logFactory.ConfigureFileLogger("log.txt");
            BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;

            Assert.IsNotNull(loggerWithFile);
        }

        [TestMethod]
        public void CreateLogger_UnconfiguredFileLoggerReturnsNull_Success()
        {
            LogFactory logFactory = new LogFactory();

            BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(FileLogger))!;

            Assert.IsNull(loggerWithFile);
        }

        [TestMethod]
        public void CreateLogger_ConsoleLoggerReturnsLogger_Success()
        {
            LogFactory logFactory = new LogFactory();

            BaseLogger consoleLogger = logFactory.CreateLogger(nameof(ConsoleLogger))!;

            Assert.IsNotNull(consoleLogger);
        }

        [TestMethod]
        public void CreateLogger_UnknownLoggerReturnsNull_Success()
        {
            LogFactory logFactory = new LogFactory();

            BaseLogger unknownLogger = logFactory.CreateLogger("FancyUnknownLogger")!;

            Assert.IsNull(unknownLogger);
        }
    }
}
