using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {

        [TestMethod]
        public void JesterGetJoke_JesterGetsJokeFromJsonAPI_Success()
        {
            string joke = "This joke will be written to the console.";

            var mockTestJesterGetJoke = new Mock<IJokeService>();
            mockTestJesterGetJoke.SetupSequence(jester => jester.GetJoke()).Returns(joke).Returns("Again: " + joke);

            Assert.AreEqual<string>(joke, mockTestJesterGetJoke.Object.GetJoke());
            Assert.AreEqual<string>("Again: " + joke, mockTestJesterGetJoke.Object.GetJoke());

            mockTestJesterGetJoke.Verify<string>(jester => jester.GetJoke(), Times.Exactly(2));
        }

        [TestMethod]
        public void JesterTellJoke_TellJokePrintsValidJokeToConsole_Success()
        {
            Jester joker = new();

            //Console redirect code from: https://stackoverflow.com/a/11911722
            // Preserve the original stream
            var originalConsoleOut = Console.Out;

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                joker.TellJoke();

                writer.Flush(); // Make sure everything is written out

                var myString = writer.GetStringBuilder().ToString();
                Console.WriteLine(myString);
                Assert.IsNotNull(myString);
                Assert.IsTrue(myString.Length > 0);
                Assert.IsTrue(!myString.ToLower().Contains("chuck") & !myString.ToLower().Contains("norris"));
            }
            //Restore the original console stream
            Console.SetOut(originalConsoleOut);
        }
    }
}
