using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests //: IJesterOutput
    {

        //TODO this is one of the mock methods i wrote for the ConsoleLogger so needs work.
        //TODO fix the names of this method, i was just outlining pretty much. 
        [TestMethod]
        public void Jester_JesterFunctionWritesJokeToConsole_Success()
        {
            string? joke = "This joke will be written to the console.";


            var mockJesterOutput = new Mock<IJesterOutput>();
            mockJesterOutput.Setup(x => x.ReadLine()).Returns(joke);
            var jester = new Jester(mockJesterOutput.Object);

            joke.Jester(Joke.Jester, joke);

            mockJesterOutput.Verify(x => x.WriteLine("This joke will be written to the console. {0}", joke), Times.Once());
        }



    }
}
