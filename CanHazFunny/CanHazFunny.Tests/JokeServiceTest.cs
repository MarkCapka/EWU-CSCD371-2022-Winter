using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CanHazFunny.Tests;
[TestClass]
public class JokeServiceTest
{
    [TestMethod]
    public void GetJoke_GetsAValidJokeFromAPI_Success()
    {
        JokeService service = new JokeService();
        string newJoke = service.GetJoke();

        Assert.IsNotNull(newJoke);
        Assert.IsTrue(!newJoke.ToLower().Contains("chuck") & !newJoke.ToLower().Contains("norris"));
    }
}
