using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace GenericsHomework.Tests;
[TestClass]
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

    [TestMethod]
    public void Next_NextPropertyAccessesNextNode_Success()
    {
        Node<int> firstNode = new(1);
        Node<int> secondNode = new(2);
        firstNode.Next = secondNode;

        Assert.IsTrue(firstNode.Next.NodeData == 2);
    }
}