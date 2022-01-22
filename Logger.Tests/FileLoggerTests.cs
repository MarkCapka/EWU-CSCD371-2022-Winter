using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class FileLoggerTests
    {


        //TODO:File Logger: derives from BaseLogger:
        //takes path to write a file for a log into. 
        //Appends message on own line when Log() is called. 

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentNullException))]
        [Ignore("Not Implemented Yet")]
        public void SetsFilePath_FilePathExistsAndSet_Success()
        {
            //string filePath = Path.GetRandomFileName();
            LogFactory logFactory = new LogFactory();
            logFactory.ConfigureFileLogger("testLogFile.txt");
            BaseLogger logger = logFactory.CreateLogger(nameof(FileLoggerTests));     //currently -> nameof(FileLoggerTests)) 
            logger.Log(LogLevel.Error, "Test Error Log");
            // Arrange

            //    filePath = FileLoggerTests.setFilePath("C:");

            //    // Act


            //    // Assert 
            //    Assert.AreEqual();
            //}
            //finally
            //{
            //    File.Delete(filePath);
            //}
        }

        [TestMethod]
        [Ignore("Not Implemented Yet")]
        public void GetFilePath_ReturnsFileThatExists_Success()
        {
            // Arrange

            //// Act
            //string filePath = Logger.GetFilePath();

            //// Assert
            //Assert.IsTrue(File.Exists(filePath));
        }


        [TestMethod]
        [Ignore("Not Implemented Yet")]
        public void Log_AppendsFile_Success()
        {
            // Arrange

            //TODO

            // Act
            //TODO: load filepath
            // string filePath = Logger.GetFilePath();

            //TODO message outputs: 
                //current date/time                                 
                //name of the class created the logger
                //log level
                //message
                //format: "10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"


            //TODO confirm that there is no overwrite of any previous messages. 

            //// Assert
            //Assert.IsTrue(File.Exists(filePath));
        }






    }
}
