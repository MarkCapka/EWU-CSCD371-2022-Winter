
using System.Text;

namespace GenericsHomework;
internal class SimpleLinkedList<T> where T : notnull
{
    private Node<T>? Head { get; set; }

    public void Append(T value)
    {
        if (Head is null)
        {
            Head = new Node<T>(value);
        }
        Node<T> current = Head;
        while (!current.Next.Equals(current))
        {
            current = current.Next;
        }
        current.Next = new Node<T>(value);
    }

    //I think this is to establish arrow relationship between nodes. 
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

}
