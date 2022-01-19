using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lecture.Tests;

[TestClass]
public class PersonTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_ConstructorNameIsNull_ThrowException()
    {
        Person person = new Person(null!);
        // person.Name = null!;
        // Assert.AreEqual("Inigo", person.Name);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_GivenNameIsNull_ThrowException()
    {
        Person person = new Person("Inigo Motoya");
        person.Name = null!;
    }
}

