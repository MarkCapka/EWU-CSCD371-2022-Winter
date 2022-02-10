using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;
[Microsoft.VisualStudio.TestTools.UnitTesting.TestClass]
public class NodeTests
{
    [TestMethod]
    public void Constructor_CreateFromData_Success()
    {
        string value = "hello";
        Node<string> helloNode = new Node<string>(value);

        Assert.IsTrue(helloNode.NodeData.Equals(value));
        Assert.IsTrue(helloNode.Next == helloNode);
    }
}