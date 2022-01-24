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
         
            try
            {

                // Act
              //  #pragma warning disable CS8625        //TODO maybe delete? now that i've added in the try-catch, I don't think that we need to disable the warning to confirm that it is taking in nullable
                BaseLoggerMixins.Error(useValidClass ? logger : null!, message!, array);
                // #pragma warning restore CS8625         //TODO maybe delete? now that i've added in the try-catch, I don't think that we need to disable the warning to confirm that it is taking in nullable
            }
            catch (ArgumentNullException exception)
            {
                //ArgumentNullException argumentNullException = Assert.ThrowsException<ArgumentNullException>(exception.ParamName);  //TODO probably can delete this line, just think that we need to throw if we can't proceed.
                //I believe the flag above the method  [ExpectedException(typeof(ArgumentNullException))] signifies that the exception will be thrown so no need to assert? 
                throw exception;
              
            }

            // Assert

           Assert.AreEqual(nameof(logger), "Error");         //added to confirm that the logger is still seeing this as an "Error" even if passed in as null. 
           Assert.AreNotEqual(nameof(logger), "Warning");
          
            // Assert.AreEqual(LogLevel.Error, logger.LoggedMessages[0].LogLevel);              //probably extraneous, just testing
            //Assert.AreEqual("Error Message 42 test", logger.LoggedMessages[0].Message);


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
            try
            {
                BaseLoggerMixins.Warning(useValidClass ? logger : null!, message!, array);
       
            }
            catch (ArgumentNullException exception)
            {
               
                throw exception;

            }
            // Assert
            Assert.AreNotEqual(nameof(logger), "Error");
            Assert.AreEqual(nameof(logger), "Warning");
            
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
