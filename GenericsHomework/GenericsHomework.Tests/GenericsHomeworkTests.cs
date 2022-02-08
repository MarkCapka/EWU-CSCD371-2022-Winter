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
            Node<string> Head = new(value);
            SimpleLinkedList<string> list = new(Head);          // Head = new Node<T>(value);
           // SimpleLinkedList<Node<string>> Current = new(Head);


            // Node<string> node2 = new(value2);


            //Node<T> SimpleLinkedList<Node<T>>.Current => Head;

            // SimpleLinkedList<Node<string>>.Node<string>.Head = head; 
            // list.Append((string)value);
            //list.Append(head);
            //list.Append(value);

           
            list.Append(value2);
           

            //Node<string> node1 = new();
            //Node<string> node2 = new();
            //   Node<int> node3 = new(); //TODO consider if we can just use the generic to swap with the int mid-class. 
            // Head.Append(node1);

            //            node1.Append(node2);
            //Head = new Node<T>(value);
            //node.Next = Head; //since only thing it will point to itself
            //  Console.WriteLine(list.ToString());
            //Assert.AreEqual<string>(Current.ToString(), "hello->howdy");
            Assert.AreEqual<string>(list.ToString(), "hello->howdy");
            //  Assert.AreEqual<Node<string>>(Head.Next, Head);
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


