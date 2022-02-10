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

    [TestMethod]
    public void GetEnumerator_EnumeratorEnumerates_Success()
    {
        int value = 1;
        int value2 = 2;
        int value3 = 3;
        int value4 = 4;

        CircularLinkedList<int> list = new CircularLinkedList<int>(value);

        list.Append(value2);
        list.Append(value3);
        list.Append(value4);
        list.Next();
        var enumerator = list.GetEnumerator();

        Assert.IsNotNull(enumerator);

        for (int i = 1; i <= 4; i++)
        {
            enumerator.MoveNext();
            Assert.AreEqual(i, enumerator.Current);
        }
    }

    [TestMethod]
    public void IEnumerableGetEnumerator_CircularLinkedListsAreEnumerable_Success()
    {
        CircularLinkedList<int>[] lists = new CircularLinkedList<int>[3];
        lists[0] = new(1);
        lists[0].Append(2);
        lists[0].Append(3);
        lists[0].Next();

        lists[1] = new(4);
        lists[1].Append(5);
        lists[1].Append(6);
        lists[1].Next();

        lists[2] = new(7);
        lists[2].Append(8);
        lists[2].Append(9);
        lists[2].Next();

        var enumerator = lists.GetEnumerator();

        Assert.IsNotNull(enumerator);

        enumerator.MoveNext();
        Assert.AreEqual(1 + "->" + 2 + "->" + 3, enumerator.Current.ToString());
        enumerator.MoveNext();
        Assert.AreEqual(4 + "->" + 5 + "->" + 6, enumerator.Current.ToString());
        enumerator.MoveNext();
        Assert.AreEqual(7 + "->" + 8 + "->" + 9, enumerator.Current.ToString());
    }

}