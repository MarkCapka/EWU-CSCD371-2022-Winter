using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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
            BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(LogFactoryTests));

            Assert.IsNotNull(loggerWithFile);
        }

        [TestMethod]
        public void CreateLogger_UnconfiguredLoggerReturnsNull_Success()
        {
            LogFactory logFactory = new LogFactory();

            BaseLogger loggerWithFile = logFactory.CreateLogger(nameof(LogFactoryTests));

            Assert.IsNull(loggerWithFile);
        }
    }
}
