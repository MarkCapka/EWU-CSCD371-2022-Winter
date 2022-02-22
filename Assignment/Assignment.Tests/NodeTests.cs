using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class MyTestClass
    {
        [TestMethod]
        public void GetEnumerator_CanCircleThroughList()
        {
            Node<int> head = new(1);
            head.Append(2);
            head.Next.Append(3);
            IEnumerator<Node<int>> nodeEnumerator = head.GetEnumerator();
            Assert.IsTrue(nodeEnumerator.MoveNext());
            Assert.IsTrue(nodeEnumerator.Current.Value == 1);
            Assert.IsTrue(nodeEnumerator.MoveNext());
            Assert.IsTrue(nodeEnumerator.Current.Value == 2);
            Assert.IsTrue(nodeEnumerator.MoveNext());
            Assert.IsTrue(nodeEnumerator.Current.Value == 3);
            Assert.IsFalse(nodeEnumerator.MoveNext());

        }

        [TestMethod]
        public void ChildItems_ReturnsRequestedNodesOnly()
        {
            Node<int> head = new Node<int>(1);
            head.Append(2);
            head.Next.Append(3);
            head.Next.Next.Append(4);
            head.Next.Next.Next.Append(5);
            IEnumerable<Node<int>> childItems = head.ChildItems(3);
            IEnumerator<Node<int>> E = childItems.GetEnumerator();
            Assert.IsTrue(E.MoveNext());
            Assert.IsTrue(E.Current.Value == 1);
            Assert.IsTrue(E.MoveNext());
            Assert.IsTrue(E.Current.Value == 2);
            Assert.IsTrue(E.MoveNext());
            Assert.IsTrue(E.Current.Value == 3);
            Assert.IsFalse(E.MoveNext());

        }



        [TestMethod]
        public void Node_NullArg_Exception()
        {
            Node<string> test;
            Assert.ThrowsException<ArgumentNullException>(() => test = new(null!));
        }

        [TestMethod]
        public void Node_SingleNodePointsToSelf_Success()
        {
            Node<string> testNode = new("test string");
            Assert.AreEqual<string>("test string", testNode.Next.Value);
        }
        
        [TestMethod]
        public void Append_ListIsCircular_Success()
        {
            Node<string> testNode = new("first node string value");
            testNode.Append("2nd node 42");
            testNode.Next.Append("3 is magic");

            Node<string> Cursor = testNode.Next;
            Assert.AreEqual<string>("2nd node 42", Cursor.Value);

            Cursor = Cursor.Next;
            Assert.AreEqual<string>("3 is magic", Cursor.Value);

            Cursor = Cursor.Next;
            Assert.AreEqual<string>("first node string value", Cursor.Value);

            Assert.IsTrue(Cursor == testNode);

        }

        [TestMethod]
        public void Append_DuplicateValue_Exception()
        {
            Node<double> testNode = new(0.0);
            testNode.Append(42);
            Assert.ThrowsException<InvalidOperationException>(() => testNode.Append(0.0));
        }

        [TestMethod]
        public void Clear_WorksOnFirstNode_Success()
        {
            Node<string> testNode = new("first node string value");
            testNode.Append("2nd node 42");
            testNode.Next.Append("3 is magic");

            testNode.Clear();
            Assert.AreEqual<string>("first node string value", testNode.Value);
            Assert.AreEqual<string>("first node string value", testNode.Next.Value);
        }
        [TestMethod]
        public void Clear_WorksOnLastNode()
        {
            Node<string> testNode = new("first node string value");
            testNode.Append("2nd node 42");
            testNode.Next.Append("3 is magic");
            Node<string> cursor = testNode.Next.Next;

            cursor.Clear();
            Assert.AreEqual<string>("3 is magic", cursor.Value);
            Assert.AreEqual<string>("3 is magic", cursor.Next.Value);

            // idea:
            // add moq here, return cursor or something, and then test to see 
            // if testNode has value after the moq. If it doesnt, then that shows that outside the scope
            // even though we returned testNode, cursor had nothing pointing to it
            // and has be sufficiently garbage collected
        }

        [TestMethod]
        public void Exists_ValuePresentAndSizeGreaterThan1_Sucess()
        {
            Node<string> testNode = new("first node string value");
            testNode.Append("2nd node 42");
            testNode.Next.Append("3 is magic");

            Assert.IsTrue(testNode.Exists("3 is magic"));
        }
        [TestMethod]
        public void Exists_ValueNotPresentAndSizeGreaterThan1_Sucess()
        {
            Node<string> testNode = new("first node string value");
            testNode.Append("2nd node 42");
            testNode.Next.Append("3 is magic");

            Assert.IsFalse(testNode.Exists("strawberry fields 4ever"));
        }
        [TestMethod]
        public void Exists_ValuePresentAndSizeIs1_Sucess()
        {
            Node<int> testNode = new(777);
            

            Assert.IsTrue(testNode.Exists(777));
        }
        [TestMethod]
        public void Exists_ValueNotPresentAndSizeIs1_Sucess()
        {
            Node<int> testNode = new(777);

            Assert.IsFalse(testNode.Exists(42));
        }



    }

}
