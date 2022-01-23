using System;
using System.Collections.Generic;

namespace Logger.Tests
{
    [TestClass]
    public class BaseLoggerMixinsTests
    {


        //-----------------------------------------------------------------------------------
        //Error
        //-----------------------------------------------------------------------------------

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Error(null!, "");   //TODO need error message? 

            // Assert
        }

        [TestMethod]
        public void Error_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Error("Error Message {0} {1}", 42, "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Error Message 42 test", logger.LoggedMessages[0].Message);
        }

        //-----------------------------------------------------------------------------------
        //Warning
        //-----------------------------------------------------------------------------------

        [TestMethod]
        [DataRow(false, "test {0}")]
        [DataRow(true, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Warning_WithNullLogger_ThrowsException(bool useValidClass, string message)
        {
            // Arrange
            var logger = new TestLogger();
            int[] array = { 42 };

            // Act

            BaseLoggerMixins.Warning(useValidClass ? logger : null!, message!, array);

            // Assert
        }



        [TestMethod]
        public void Warning_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Warning Message {0} {1}", 42, "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Warning Message 42 test", logger.LoggedMessages[0].Message);
        }

        //{message }, {logLevel }, ["this is the message", "Warning"];


        //-----------------------------------------------------------------------------------
        //Information
        //-----------------------------------------------------------------------------------



        //TODO
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Information(null!, "");

            // Assert


        }


        //TODO
        [TestMethod]
        public void Information_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Information Message {0} {1}", 42, "test");


            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Information Message 42 test", logger.LoggedMessages[0].Message);
        }




        //-----------------------------------------------------------------------------------
        //Debug
        //-----------------------------------------------------------------------------------

        //TODO
        [TestMethod]
        public void Debug_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act                    //  logger.Debug("Debug Message {0} {1}", [42, secondArgument]);
            logger.Debug("Debug Message {0} {1}", 42, "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Debug Message 42 test", logger.LoggedMessages[0].Message);
        }



        //TODO
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException()
        {
            // Arrange

            // Act
            BaseLoggerMixins.Debug(null!, "");

            // Assert
        }
    }

    public class TestLogger : BaseLogger
    {
        public List<(LogLevel LogLevel, string Message)> LoggedMessages { get; } = new List<(LogLevel, string)>();

        public override void Log(LogLevel logLevel, string message)
        {
            LoggedMessages.Add((logLevel, message));
        }
    }
}
