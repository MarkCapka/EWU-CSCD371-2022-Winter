
using System.Collections;
using System.Text;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("GenericsHomework.Tests")]


namespace GenericsHomework;
internal class CircularLinkedList<T> : ICollection<T> where T : notnull
{
    private Node<T> Head { get; set; }

    public int Count { get; set; } = 1;
    

    public bool IsReadOnly => true;

    public CircularLinkedList(T value)
    {
        Head = new Node<T>(value);
    }
    public CircularLinkedList(Node<T> head)
    {
        Head = head;
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
       
        Head.Next = Head;
    }

    //To establish arrow relationship between nodes. 
    public override string ToString()
    {
        StringBuilder outputListAsString = new();
        Node<T> current = Head!;
        while (!current.Next.Equals(current))
        {
            if (outputListAsString.Length > 0)
            {
                outputListAsString.Append("->");
                ;
            }
            outputListAsString.Append(current.ToString());
            current = current.Next;
        }

        return outputListAsString.ToString();
    }

    public void Add(T item)
    {
        Node<T> current = Head;
        while (!current.Next.Equals(current))
        {
            current = current.Next;
            if (current.NodeData.Equals(item))
            {
                throw new ArgumentException($"NodeData with value {item} is a duplicate to another Node's data");
            }
        }
        Count++;
        current.Next = new Node<T>(item);
    }

    public bool Contains(T item)
    {
        Node<T> current = Head;
        int searched = 0;
        while (!current.Next.Equals(current) && searched++ < Count)
        {
            current = current.Next;
        }
        if (searched < Count)
        {
            return current.NodeData.Equals(item);
        }
        return false;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if(array.Length < Count + arrayIndex)
        {
            throw new ArgumentException($"The array was not large enough to hold {Count} items starting at index {arrayIndex}");
        }
        Node<T> current = Head;
        for(int i = 0; i < Count; i++)
        {
            array[arrayIndex++] = current.NodeData;
            current = current.Next;
        }
    }

    public bool Remove(T item)
    {
        Node<T> current = Head;
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
        //Yield return
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        //Yield return
        throw new NotImplementedException();
    }
}
