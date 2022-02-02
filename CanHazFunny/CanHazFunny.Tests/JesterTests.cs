using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests //: IJesterOutput
    {

         [TestMethod]
#pragma warning disable INTL0003 // IGNORES Methods PascalCase     REASON       //Test, shouldn't be named with PascalCase
#pragma warning disable CA1707 //  IGNORES  Identifiers should not contain underscores      REASON //Test, should be named with underscores 
        public void JesterGetJoke_JesterGetsJokeFromJsonAPI_Success()
#pragma warning restore CA1707 // Identifiers should not contain underscores      REASON //Test, should be named with underscores 
#pragma warning restore INTL0003 // Methods PascalCase              //Test, shouldn't be named with PascalCase
        {
     

            string joke = "This joke will be written to the console.";

            var mockTestJesterGetJoke = new Mock<IJokeService>();
            mockTestJesterGetJoke.SetupSequence(jester => jester.GetJoke()).Returns(joke).Returns("Again: " + joke);

            Assert.AreEqual<string>(joke, mockTestJesterGetJoke.Object.GetJoke());
            Assert.AreEqual<string>("Again: " + joke, mockTestJesterGetJoke.Object.GetJoke());

            mockTestJesterGetJoke.Verify<string>(jester => jester.GetJoke(), Times.Exactly(2));
        }

        [TestMethod]
#pragma warning disable INTL0003 // IGNORES Methods PascalCase     REASON       //Test, shouldn't be named with PascalCase
#pragma warning disable CA1707 //  IGNORES  Identifiers should not contain underscores      REASON //Test, should be named with underscores 
        public void JesterTellJoke_TellJokePrintsToConsole_Success()
#pragma warning restore CA1707 // Identifiers should not contain underscores      REASON //Test, should be named with underscores 
#pragma warning restore INTL0003 // Methods PascalCase              //Test, shouldn't be named with PascalCase
        {

            string joke = "This joke will be written to the console.";

            var mockJesterOutput = new Mock<IJesterOutput>();
            mockJesterOutput.Setup(jester => jester.JesterPrint(joke));

            //Console redirect code: https://stackoverflow.com/a/11911722
            var originalConsoleOut = Console.Out; // preserve the original stream
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                //Console.WriteLine("some stuff"); // or make your DLL calls :)
                mockJesterOutput.Object.JesterPrint(joke);
                Console.WriteLine(joke);

                writer.Flush(); // when you're done, make sure everything is written out

                var myString = writer.GetStringBuilder().ToString();
                Console.WriteLine(myString);
                Assert.IsTrue(myString.Equals(value: joke + "\r\n", StringComparison.OrdinalIgnoreCase));
            }
            Console.SetOut(originalConsoleOut);
        }
    }
}