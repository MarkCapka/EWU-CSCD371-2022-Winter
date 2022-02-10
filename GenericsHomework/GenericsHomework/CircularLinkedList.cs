
using System.Collections;
using System.Text;


namespace GenericsHomework;
public class CircularLinkedList<T> : ICollection<T> where T : notnull  
{




//instruction: Create a node class that can contain a value of any type and points to the next node and traversing the next node points back to the first item.

/*
 * 
 * Define the Node class
 * 
 */



     private class Node<T1>// : ICollection<T> //EXTRA CREDIT: 2.Implement Systm.Collections.Generic.ICollection<T> on the Node class ❌✔     
        where T1 : notnull
    {
        public T1 NodeData { get; set; } //these should be private through nested class
        public Node<T1> Next { get; set; }//these should be private through nested class

        public Node(T1 data)
        {
            NodeData = data;
            Next = this;
        }
    }


    private Node<T> Cursor { get; set; }

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    

    public CircularLinkedList(T value)
    {

        if (value == null)
            throw new ArgumentNullException();

        Cursor = new Node<T>(value);
        Count = 1;
    }


    
   
    public void Next()
    {
        Cursor = Cursor.Next;
    }
    public T GetData()
    {
        return Cursor.NodeData;
    }
    public void Append(T value)
    {
        Add(value);
    }
    public bool Exists(T value)
    {
        return Contains(value);
    }

    //TODO consider: Whether it is sufficient to only set Next to itself ❌✔
        //yes, it is sufficient to just reference Head as the Head.Next value since the rest of the linkedList that was cleared will be garbage collected since it has a null reference to the old Head //TODO read this again. 
    //Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔
    //Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage collection because all the items point to each other and therefore may never be garbage collected. ❌✔
    public void Clear()
    {
       //Setting the cursor's Next property to itself is sufficient because the garbage collector will not have a path from the program root to the other nodes and will therefore clean up their memory.
        Cursor.Next = Cursor;
        Count = 1;
    }

    //To establish arrow relationship between nodes. 
    public override string ToString()
    {
        StringBuilder outputListAsString = new();
        //Cursor is not nullable and this isn't a static method, cannot be null
        Node<T> current = Cursor!;
        for(int i = 0; i < Count; i++)
        {
            if (outputListAsString.Length > 0 && i != Count)
            {
                outputListAsString.Append("->");
            }
            outputListAsString.Append(current.NodeData.ToString());
            current = current.Next;
        }

        return outputListAsString.ToString();
    }

    public void Add(T item)
    { 
        Node<T> current = Cursor;
        for (int i = 0; i < Count; i++)
        {
            if (current.NodeData.Equals(item))
            {
                throw new ArgumentException($"NodeData with value {item} is a duplicate to another Node's data");
            }
            current = current.Next;
        }
        Count++;
        Node<T> temp = current.Next;
        current.Next = new Node<T>(item);
        current.Next.Next = temp;
        Cursor = current.Next;
    }

    public bool Contains(T item)
    {
        Node<T> current = Cursor;
        for(int i = 0; i < Count; i++)
        {
            if (current.NodeData.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if(array is null)
        {
            throw new ArgumentNullException($"Parameter {nameof(array)} was null");
        }
        if(array.Length < Count + arrayIndex)
        {
            throw new ArgumentException($"The array was not large enough to hold {Count} items starting at index {arrayIndex}");
        }
        Node<T> current = Cursor;
        for(int i = 0; i < Count; i++)
        {
            array[arrayIndex++] = current.NodeData;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        Node<T> current = Cursor;
        int searched = 0;
        while (!current.Next.Equals(current) && searched++ < Count)
        {
            current = current.Next;
        }
        if (searched < Count)
        {
            current.Next = current.Next.Next;
            Count--;
            return true;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Count; i++)
        {
            yield return Cursor.NodeData;
            Cursor = Cursor.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        yield return GetEnumerator();
    }
}
