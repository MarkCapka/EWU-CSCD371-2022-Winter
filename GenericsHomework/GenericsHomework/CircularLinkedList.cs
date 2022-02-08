
using System.Collections;
using System.Text;
[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("GenericsHomework.Tests")]

//TODO make circular

namespace GenericsHomework;
internal class CircularLinkedList<T> : IEnumerable, IEnumerator<Node<T>> where T : notnull
{
    private Node<T> Head { get; set; }

    public int Count { get; set; }

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

    internal void Append(Node<string> node2)
    {
        throw new NotImplementedException();
    }


    //TODO consider: Whether it is sufficient to only set Next to itself ❌✔
    //Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔
    //Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage collection because all the items point to each other and therefore may never be garbage collected. ❌✔
    public void Clear()
    {
        //Head = Current;
        Head.Next = Head;

        //if we set the End to the head (not circularly but assign it as the head) it will have nothing after it. 
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
        current.Next = new Node<T>(item);
    }

    public bool Contains(T item)
    {
        Node<T> current = Head;
        while (!current.Next.Equals(current) && !current.NodeData.Equals(item))
        {
            current = current.Next;
        }
        return current.NodeData.Equals(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}