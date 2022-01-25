using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [DataRow(false, "test {0}")]
        [DataRow(true, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Error_WithNullLogger_ThrowsException(bool useValidClass, string message)
        {
            // Arrange
            var logger = new TestLogger();
            int[] array = { 42 };

          
                // Act
                BaseLoggerMixins.Error(useValidClass ? logger : null!, message!, array);

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
            int[] array = { 25 };

            // Act
            BaseLoggerMixins.Warning(useValidClass ? logger : null!, message!, array);


        }


        [TestMethod]
        public void Warning_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Warning("Warning Message {0} {1}", 25, "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Warning, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Warning Message 25 test", logger.LoggedMessages[0].Message);
        }

        //{message }, {logLevel }, ["this is the message", "Warning"];


        //-----------------------------------------------------------------------------------
        //Information
        //-----------------------------------------------------------------------------------



        [TestMethod]
        [DataRow(false, "test {0}")]
        [DataRow(true, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Information_WithNullLogger_ThrowsException(bool useValidClass, string message)
        {
            var logger = new TestLogger();
            int[] array = { 33 };

            // Act
        
                BaseLoggerMixins.Information(useValidClass ? logger : null!, message!, array);

       

        }


        //TODO
        [TestMethod]
        public void Information_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act
            logger.Information("Information Message {0} {1}", 33, "test");


            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Information, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Information Message 33 test", logger.LoggedMessages[0].Message);
        }




        //-----------------------------------------------------------------------------------
        //Debug
        //-----------------------------------------------------------------------------------
        [TestMethod]
        public void Debug_LogMessageWithValidData_Success()
        {
            // Arrange
            var logger = new TestLogger();

            // Act                    //  logger.Debug("Debug Message {0} {1}", [42, secondArgument]);
            logger.Debug("Debug Message {0} {1}", 24, "test");

            // Assert
            Assert.AreEqual(1, logger.LoggedMessages.Count);
            Assert.AreEqual(LogLevel.Debug, logger.LoggedMessages[0].LogLevel);
            Assert.AreEqual("Debug Message 24 test", logger.LoggedMessages[0].Message);
        }


        [TestMethod]
        [DataRow(false, "test {0}")]
        [DataRow(true, null)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Debug_WithNullLogger_ThrowsException(bool useValidClass, string message)
        {

            //Arrange
            var logger = new TestLogger();
            int[] array = { 24 };
            // Act
            BaseLoggerMixins.Debug(useValidClass ? logger : null!, message!, array);
            
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
