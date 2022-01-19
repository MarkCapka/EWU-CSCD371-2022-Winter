using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lecture3.Tests;
[TestClass]
public class PersonTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_ConstructorNameIsNull_ThrowException()
    {
        Person person = new Person(null!);
    }
    
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_GivenNameIsNull_ThrowException()
    {
        Person person = new Person("Inigo Montoya");
        person.Name = null!;

    }
}
