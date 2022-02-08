using Microsoft.VisualStudio.TestTools.UnitTesting;



//NOTE: Did as much as we could, but the way that we wrote the class with Enumerators made it tough to complete the tests on time.
//will ask questions tomorrow and rework tests before final due date on Thursday --Mark Capka
//maybe with this approach would need to do the following? public static object Parse (Type enumType, string value);

namespace GenericsHomework.Tests
{
    [TestClass]
    public class GenericsHomeworkTests
    {
        //[TestMethod]
        //public void Node_ConstructsHeadNode_Success()
        //{
        //    //TODO just playing around - need to confirm that these are "behaving"
        //    //string value = "hello";
        //    Node<string> head = new Node<string>(value); or maybe  //Head = new Node<T>(value);


        //    //node.Next = Head; //since only thing it will point to itself

        //    //Assert.AreEqual<T>(value, "hello");
        //    //Assert.AreEqual<T>(Head.Next, Head);
        //}

        [TestMethod]
        public void Node_ConstructsNode_Success()
        {

            string value = "hello";
            string value2 = "howdy";
            Node<string> head = new Node<string>(value);
            Node<string> node2 = new Node<string>(value2);
            SimpleLinkedList<Node<string>> list = new SimpleLinkedList<Node<string>>(head);
            //Node<T> SimpleLinkedList<Node<T>>.Current => Head;


            // SimpleLinkedList<Node<string>>.Node<string>.Head = head; 
           // list.Append((string)value);
            //list.Append(head);
            list.Append(node2);

            //Node<string> node1 = new();
            //Node<string> node2 = new();
            //   Node<int> node3 = new(); //TODO consider if we can just use the generic to swap with the int mid-class. 
            // Head.Append(node1);

            //            node1.Append(node2);
            //Head = new Node<T>(value);
            //node.Next = Head; //since only thing it will point to itself

            Assert.AreEqual<string>(list.ToString(), "hello->howdy");
            //  Assert.AreEqual<Node<string>>(Head.Next, Head);
        }

        [TestMethod]
        public void SimpleLinkedList_AppendsNode_Success()
        {
            //    throw new NotImplementedException();


            //TODO test for empty linkedlist

            string value = "hello";
            bool value2 = true;
            int value3 = 0;
            string value4 = "goodbye";


            SimpleLinkedList<object> list = new SimpleLinkedList<object>(value);

            list.Append(value);
            list.Append(value2);
            list.Append(value3);
            list.Append(value4);

            //TODO for the test below, might need to do bool.toString()? may also need cast in appends
            Assert.AreEqual<string>(list.ToString(), "hello->true->0->goodbye");
            Assert.AreEqual<string>(typeof(list[3]).ToString(), "string"); //TODO confirm if best way to call this... probably not
          //  Assert.IsTrue(list.(SimpleLinkedList<string>.Next()), "goodbye"); //points back to itself

        }

        [TestMethod]
        public void SimpleLinkedList_ClearClears_Success()
        {
            string value = "hello";
            string value2 = "howdy";
            string value3 = "all alone";


            //SimpleLinkedList<Node<string>> list = new SimpleLinkedList<Node<string>(value as Node<string>);
            SimpleLinkedList<string> list = new SimpleLinkedList<string>(value);

            list.Append(value2);
            list.Append(value3); 
            list.Clear(); //only last appended value (which is the current value) should remain

            Assert.AreEqual(list.ToString(), value3);
            Assert.IsTrue(list.MoveNext(), value3); //points back to itself

        }



        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SimpleLinkedList_AddsDuplicate_Fail()
        {
            string value = "hello";
            string value2 = "howdy";
            string value3 = "hello";


            //SimpleLinkedList<Node<string>> list = new SimpleLinkedList<Node<string>(value as Node<string>);
            SimpleLinkedList<string> list = new SimpleLinkedList<string>(value);

            list.Append(value2);
            list.Append(value3);
            //only last appended value (which is the current value) should remain

            Assert.AreEqual<string>(list.ToString(), "hello->howdy");
          //  Assert.AreEqual<string>(SimpleLinkedlist.Node<string>.Next, value3); //another attempt
          //  Assert.AreEqual<string>(list.Next, "howdy"); //points back to itself //this was  MoveNext from SimpleLInkedLIst and is is a boolean return, but depending on that boolean will detmine action? 
            
        }


        //[TestMethod]   //TODO this might be a duplicate with the one above
        ////[ExpectedException]
        //public void SimpleLinkedList_AttemptToAddDuplicateThowsException_Fail()
        //{
        //    throw new NotImplementedException();

        //    //Assert.AreEqual<T>();
        //}

    }


    //TODO will expand on these when I can actually do tests and work out that I am writing them correctly. 


    //building an attempt at a constructor, however, couldn't get it to work with enums... will clarify tomorrow
        //public class SimpleLinkedList<T>
        //        where T : notnull



        //    //Head = new Node<T>(value);
        //    //public Node<T> Current => Head;// throw new NotImplementedException();


        //    //Console.Write(this.toString());
        //   public List<(GenericsHomework.Node<T> Node, GenericsHomework.Node<T> Next)> List { get; } = new ();
        //    SimpleLinkedList<T>


    }


