
using System.Collections;
using System.Text;

namespace GenericsHomework;
internal class SimpleLinkedList<T> : IEnumerable, IEnumerator<Node<T>> where T : notnull
{
    private Node<T> Head { get; set; }

    object IEnumerator.Current => Head;//throw new NotImplementedException();

    public Node<T> Current => Head;// throw new NotImplementedException();

    public SimpleLinkedList(T value)
    {
        Head = new Node<T>(value);
    }
    public SimpleLinkedList(Node<T> head)
    {
        Head = head;
    }
    public void Append(T value)
    {
        Node<T> current = Head;
        while (!current.Next.Equals(current))
        {
            current = current.Next;
            if (current.NodeData.Equals(value))
            {
                throw new ArgumentException($"NodeData with value {value} is a duplicate to another Node's data");
            }
        }
        current.Next = new Node<T>(value);
    }
    public bool Exists(T value)
    {
        Node<T> current = Head;
        while (!current.Next.Equals(current) && !current.NodeData.Equals(value))
        {
            current = current.Next;
        }
        return current.NodeData.Equals(value);
    }


    //TODO consider: Whether it is sufficient to only set Next to itself ❌✔
    //Whether to set the removed items to circle back on themselves. In other words, whether to close the loop of the removed items. (Provide a test to show why this is required if it is required). ❌✔
    //Given there is a circular list of items, provide a comment to indicate whether you need to worry about garbage collection because all the items point to each other and therefore may never be garbage collected. ❌✔
    public void Clear()
    {
        Head = Current;
        Head.Next = Head;

        //if we set the End to the head (not circularly but assign it as the head) it will have nothing after it. 
    }

    //To establish arrow relationship between nodes. 
    public override string ToString()
    {
        StringBuilder outputListAsString = new StringBuilder();
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

    public IEnumerator GetEnumerator()
    {
        return this;
    }

    public bool MoveNext()
    {
        if (Current.Next.Equals(Current))
        {
            return false;
        }
        else
        {
            //Current = Current.Next;
            return true;
        }
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }
}