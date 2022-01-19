namespace Lecture3;
public class Person
{
    private string? _Name;

    public Person(string firstName, string lastName) : this($"{firstName} {lastName}") { }
    public Person(string name)
    {
        Name = name;
    }
    
    public string Name
    {
        get { return _Name!; }
        set
        {
            if (value is null) { throw new ArgumentNullException(nameof(value)); }
            if(string.IsNullOrWhiteSpace(value)) { throw new ArgumentException($"{nameof(Name)} cannot be empty or whitespace.",nameof(value)); }
            _Name = value;
        }
    }

    public string? MiddleName { get; set; }

    (string, string)[] Passwords = new[] {
            ("Inigo Montoya", "YouKilledMyF@ther!")
        };

    public bool Login(string userName, string password)
    {
        return password == "YouKilledMyF@ther!";
    }
}
