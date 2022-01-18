using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lecture1.Tests
{
    [TestClass]
    public class PersonTests
    {
        Person Person = new();
        string UserName = "";
        string Password = "";

        [TestInitialize]
        public void Initialize()
        {
            Password = "YouKilledMyF@ther!";
            UserName = "Inigo.Montoya";
        }


        [TestMethod]
        public void Login_GivenInvalidPassword_Failure()
        {
            Password = "InvalidPwd";
            bool result = Person.Login(UserName, Password);
            Assert.IsFalse(result);

        }


        [TestMethod]
        public void Login_GivenValidUserNameAndPassword_Success()
        {
            bool success = Person.Login(UserName, Password);
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Login_GivenInvalidUsername_Failure()
        {
            UserName = "MarkMichaelis";
            bool result = Person.Login(UserName, Password);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void NullDeclarationConcepts()
        {
            string? text = "Inigo Montoya";
            text = text.Length > 0 ? text : SomeMethod();
            int? number1 = null;

            System.Nullable<int> number2 = null;

            //if (text is not null)
            {
                Assert.AreEqual(42, text.Length);
            }

            //if (text == null) <-- not prefered since "==" can be overridden
            //if(text is null) <-- Prefered method use "is"
            //if(text is not null) <-- C# 9
            //if(text.Equals(null)) <-- throws null pointer exception before it can check if it was null
            //if(string.ReferenceEquals(text, null))

            Assert.IsNotNull(text);
            Assert.IsNotNull(number1);
        }

        private string SomeMethod() => "Princess Buttercup"; //Expression bodied member
    }
}