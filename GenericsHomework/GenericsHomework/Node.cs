using System;


namespace GenericsHomework;


//instruction: Create a node class that can contain a value of any type and points to the next node and traversing the next node points back to the first item.

/*
 * 
 * Define the Node class
 * 
 */



public class Node<TPrevious, TCurrent, TNext>
    where TPrevious : notnull
    where TCurrent : notnull
    where TNext : notnull
{
    private Node<TPrevious, TCurrent, TNext> _Node = new();
    //Linked list will hold a node that has a reference to the node before it, itself (to track which node is highlighted in linkedlist), and to the next. 
    private LinkedList<TNode> _LinkedList = new(); //TODO arbitrary potential params currently   //know we need a next, not sure about current or previous

  


    /* 
Include a constuctor that takes a value. S(No validation is necessary on the value). ❌✔
*/
    
    //TODO genericize Node? 
    public Node(TPrevious previous, TCurrent current, TNext next)
    {
        //TODO not positive i set up this constructor right for the generics, double check this. 
        TPrevious Previous= previous;
        TCurrent Current = current;
        TNext Next = next;

      //  Node node = new Node(previous, current, next);


    }

    //TODO may just need an append for adding a  node to the end of the list
    public void Append(TCurrent node)
    {
    //    if(current.equals(node.next))   //TODO implement getter for node position
    //         LinkedList.Append(node);
    //     TODO else throw error can't append  if null (should be non-nullable I think? 

         
    }


    //Add a Next property that references the next node or else refers back to itself if there are no other nodes in the list. ❌✔
    //The Next property should be non-nullable (careful to follow the non-nullable property guidelines) ❌✔
    //The Next property setter should be private. ❌✔

    //TODO needs work
    public void Next(TPrevious previous, TCurrent current, TNext next)
    {

       
    }

    //Auto generated overwrite, need to potentially  
    //Add a ToString() override that writes out the value's ToString() result. ❌✔
      
        public override string? ToString(Node node)
        {
            return node.ToString();
        }
    
}


//TODO may want to move class to own file or may not even need at all if we are not likely we build the linkedlist from within the tests file. 
internal class LinkedList<TNode>
 where TNode : notnull
 
{
    //TODO Throw an error on an attempt to Append a duplicate value. (Make sure you test for this case) ❌✔
    internal void Append<Node>(TNode node) where Node : notnull
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
