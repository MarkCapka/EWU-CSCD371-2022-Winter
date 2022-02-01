using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests //: IJesterOutput
    {

        //TODO this is one of the mock methods i wrote for the ConsoleLogger so needs work. 
        //TODO fix the names of this method, i was just outlining pretty much. 
        [TestMethod]
        public void JesterGetJoke_JesterGetsJokeFromJsonAPI_Success()
        {
            /*
            Mock<ISavable> mock = new();
            mock.SetupSequence(
                savable => savable.ToText()).Returns("Something").Returns("SomethingElse");

            Assert.AreEqual<string?>("Something", mock.Object.ToText());
            Assert.AreEqual<string?>("SomethingElse", mock.Object.ToText());
            
            mock.Verify<string?>(savable => savable.ToText(), Times.Exactly(2));
            */

            string? joke = "This joke will be written to the console.";


            var mockTestJesterGetJoke = new Mock<IJokeService>();
            mockTestJesterGetJoke.SetupSequence(jester => jester.GetJoke()).Returns(joke).Returns("Again: " + joke);

            Assert.AreEqual<string?>(joke, mockTestJesterGetJoke.Object.GetJoke());
            Assert.AreEqual<string?>("Again: " + joke, mockTestJesterGetJoke.Object.GetJoke());

            mockTestJesterGetJoke.Verify<string?>(jester => jester.GetJoke(), Times.Exactly(2));
        }

        [TestMethod]
        public void JesterTellJoke_TellJokePrintsToConsole_Success()
        {

            string? joke = "This joke will be written to the console.";

            var mockJesterOutput = new Mock<IJesterOutput>();
            mockJesterOutput.Setup(jester => jester.JesterPrint(joke));

            //Console redirect code: https://stackoverflow.com/a/11911722
            var originalConsoleOut = Console.Out; // preserve the original stream
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                //Console.WriteLine("some stuff"); // or make your DLL calls :)
                mockJesterOutput.Object.JesterPrint(joke);
                System.Console.WriteLine(joke);

                writer.Flush(); // when you're done, make sure everything is written out

                var myString = writer.GetStringBuilder().ToString();
                System.Console.WriteLine(myString);
                Assert.IsTrue(myString.Equals(joke+"\r\n"));
            }
            Console.SetOut(originalConsoleOut);
        }
    }
}
