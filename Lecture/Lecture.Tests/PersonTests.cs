namespace Lecture.Tests;

[TestClass]
public class PersonTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_ConstructorNameIsNull_ThrowException()
    {
        new Person(null!);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_GivenNameIsNull_ThrowException()
    {
        Person person = new ("Inigo Montoya");
        person.Name = null!;
    }
}

