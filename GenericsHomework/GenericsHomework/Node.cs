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
    where T : notnull
{
    public T NodeData { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data){
        NodeData = data;
        Next = this;
    }
}