using System;
using System.Text;

namespace GenericsHomework;


//instruction: Create a node class that can contain a value of any type and points to the next node and traversing the next node points back to the first item.

/*
 * 
 * Define the Node class
 * 
 */



public class Node<T>// : ICollection<T> //EXTRA CREDIT: 2.Implement Systm.Collections.Generic.ICollection<T> on the Node class ❌✔     
{

    private LinkedList<TNode> _List = new LinkedList<TNode>();
    //TODO since start is empty? If only 1 node, will point to itself and be the first and last item.  
    private Node<T> _FirstNode = GetFirstNode(); //ends linkedList, points back to self. 
    private Node<T> _LastNode = GetLastNode(); //ends linkedList, points back to self. 
    private Node<T> _CurrentNode = GetCurrentNode(); //ends linkedList, points back to self. 

    public Node<T> CurrentNode { get; private set; }

    private static Node<T> GetCurrentNode()
    {
        int index = currentNode.GetIndex();

        Node<T> nextNode = cui.Next();

    }

    private static int GetCurrentIndex() => currentNode.index;


    private static Node<T> GetFirstNode()
    {

        return firstNode;
    }


    private static Node<T> GetLastNode()
    {
        return lastNode;
    }





    //private Node<T> firstNode ;
    //private Node<T> lastNode = _LastNode;
    //public Node<T> GetFirstNode => firstNode;
    //public Node<T> GetLastNode => lastNode;
    //public int index; //Tracks where in the linkedlist we are 
    //private Node<T> nextNode;


    //Linked list will hold a node that has a reference to the node before it, itself (to track which node is highlighted in linkedlist), and to the next. 






    //TODO 
    //need to handle: 
    //special cases: 
    //first -> start link list
    //last -> point currentNode to itself 
    //

    /* 
Include a constuctor that takes a value. S(No validation is necessary on the value). ❌✔
*/

    //TODO genericize Node? 



    public Node()
    {
        public object NodeData;

        public Node CurrentNode;
        public Node NextNode;
        private static Node<T> firstNode;
        private static Node<T> lastNode;
    }

public Node<T> CurrentNode
{
    get => firstNode;

    set
    {

        while (nextNode != lastNode)
        {
            currentNode = currentNode.Next();
            index++;
        }


    }

}

private Node<T> Next()
{
    get { return CurrentNode.Next(); }
    set { CurrentNode.index++; }
}

//  Node node = new Node(previous, current, next);


public bool IsEmpty { get { this { return firstNode == null; } } }




//TODO may just need an append for adding a  node to the end of the list
//public void Append()
//{
//    //    if(current.equals(node.next))   //TODO implement getter for node position
//    //         LinkedList.Append(node);
//    //     TODO else throw error can't append  if null (should be non-nullable I think? 


//}


//Add a Next property that references the next node or else refers back to itself if there are no other nodes in the list. ❌✔
//The Next property should be non-nullable (careful to follow the non-nullable property guidelines) ❌✔
//The Next property setter should be private. ❌✔

//TODO needs work


//Auto generated overwrite, need to potentially  
//Add a ToString() override that writes out the value's ToString() result. ❌✔

//I think this is to establish arrow relationship between nodes. 
public override string ToString()
{
    if (list.IsEmpty)
    {
        return string.Empty;
    }

    StringBuilder outputListAsString = new StringBuilder();
    foreach (T currentNode in list)
    {
        if (outputListAsString.Length > 0)
        {
            outputListAsString.Append("->");
            ;
        }
        outputListAsString.Append(item);
    }

    return lastNode.ToString();
}



//TODO may want to move class to own file or may not even need at all if we are not likely we build the linkedlist from within the tests file. 
internal class LinkedList<TNode>
 where TNode : notnull

{
    //TODO Throw an error on an attempt to Append a duplicate value. (Make sure you test for this case) ❌✔
    internal void Append<TNode>(TNode node) where TNode : notnull
    {

        //TODO psuedocode
        //if(valu of node.NotEqual(any other node in linkedlist))
        //if (node.next.Equals(current))    //reached end of the list
//{
        //    LinkedList.Add(node.Next());
        //}





    }
}







//Add an Append method that takes a value and appends a new Node instance after the current node (by invoking the Next property). ❌✔




//Add a Clear method that effectively removes all items from a list except the current node. Pay attention as to whether you should be concerned with the following:
//Whether it is sufficient to only set Next to itself ❌✔



//Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔



//Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage collection because all the items point to each other and therefore may never be garbage collected. ❌✔



//Create an Exists method to test to see if a value exists in the list. ❌✔





//You should not rely on any BCL generic classes for your implementation. ❌✔











/*
 * Extra Credit
Do one of the following two options (or both if you want extra extra credit) :)

Implement a VennDiagram structure that contains n Circles that only contains homogenous reference types of any type. ❌✔
Each circle contains n items and each item can belong to one more more Circle instances.
You are not required to use a Node from earlier in the homework for your venn diagram implementation.
You are welcome to use exising BCL generic classes for the extra credit.
Implement Systm.Collections.Generic.ICollection<T> on the Node class ❌✔
 * 
 * 
 */
