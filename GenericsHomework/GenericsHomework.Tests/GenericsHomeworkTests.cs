using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class GenericsHomeworkTests
    {
        [TestMethod]
        public void Node_ConstructsHeadNode_Success()
        {
            //TODO just playing around - need to confirm that these are "behaving"
            //TODO I thin ki need to add construction
         
  
            string value = "hello";
            Head = new Node<T>(value);

            node.Next = Head; //since only thing it will point to itself

            Assert.AreEqual<T>(value, "hello");
            Assert.AreEqual<T>(Head.Next, Head);
        }

        [TestMethod]
        public void Node_ConstructsNode_Success()
        {
            //TODO just playing around - need to confirm that these are "behaving"
            //TODO I thin ki need to add construction
            
            Node<string> head = new Node<string>(value);
            Node<string> node1 = new();
            Node<string> node2 = new();
         //   Node<int> node3 = new(); //TODO consider if we can just use the generic to swap with the int mid-class. 
            Head.Append(node1);

            node1.Append(node2);


            string value = "hello";
            Head = new Node<T>(value);

            node.Next = Head; //since only thing it will point to itself

            Assert.AreEqual<string>(value, "hello");
            Assert.AreEqual<Node<string>>(Head.Next, Head);
        }

        [TestMethod]
        public void SimpleLinkedList_AppendsNode_Success()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
            //TODO test for empty linkedlist
        }

        [TestMethod]
        public void SimpleLinkedList_RemovesNode_Success()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
        }

        [TestMethod]
        public void Node_StringsNode_Success()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
        }



        [TestMethod]
        public void SimpleLinkedList_ClearsList_Success()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
        }



        [TestMethod]
        public void SimpleLinkedList_AddsDuplicate_Fail()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
        }



        [TestMethod]
        [ExpectedException]
        public void SimpleLinkedList_AttemptToAddDuplicateThowsException_Fail()
        {
            throw new NotImplementedException();

            //Assert.AreEqual<T>();
        }

    }
}
