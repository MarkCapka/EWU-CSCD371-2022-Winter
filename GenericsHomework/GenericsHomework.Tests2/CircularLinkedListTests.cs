using GenericsHomework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CircularLinkedListTests;
[TestClass]
public class CircularLinkedListTests
{
    [TestMethod]
    public void Constructor_CreateFromData_Success()
    {
        string value = "hello";
        CircularLinkedList<string> list = new(value);

        Assert.IsTrue(list.Contains(value));
        Assert.IsTrue(list.Count == 1);
    }

    [TestMethod]
    public void Constructor_CreateFromNode_Success()
    {
        string value = "howdy";
        Node<string> node = new(value);
        CircularLinkedList<string> list = new(node);

        Assert.IsTrue(list.Contains(value));
        Assert.IsTrue(list.Count == 1);
    }

    [TestMethod]
    public void Append_AddsNodeToLinkedList_Success()
    {
        int value = 1;
        int value2 = 2;
        int value3 = 3;
        int value4 = 4;

        CircularLinkedList<int> list = new CircularLinkedList<int>(value);

        list.Append(value2);
        list.Append(value3);
        list.Append(value4);

        Assert.AreEqual<string>("4->1->2->3", list.ToString());
        Assert.IsTrue(list.Count == 4);
    }

    [TestMethod]
    public void Clear_ClearsTheLinkedList_Success()
    {
        string value = "hello";
        string value2 = "howdy";
        string value3 = "all alone";


        CircularLinkedList<string> list = new CircularLinkedList<string>(value);

        list.Append(value2);
        list.Append(value3);
        list.Clear(); //only last appended value (which is the current value) should remain

        Assert.AreEqual(value3, list.ToString());
        Assert.AreEqual(value3, list.GetData()); //points back to itself
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void Append_PreventAddingDuplicate_ThrowsError()
    {
        string value = "hello";
        string value2 = "howdy";
        string value3 = "hello";


        CircularLinkedList<string> list = new CircularLinkedList<string>(value);

        list.Append(value2);
        list.Append(value3); // Add hello again, should throw error
    }

}