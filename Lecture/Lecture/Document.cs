using System.Runtime.Serialization;

namespace Lecture;
public class Document : Thing, ISavable, ISerializable
{
    public string? Content { get; private set; }

    public Document(string name)
        :base(name)=> Name = name;

    string ISavable.ToText() => $"{nameof(Name)}: {Name}";

    public override string? ToText() => Content;

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
        throw new NotImplementedException();
    }
}