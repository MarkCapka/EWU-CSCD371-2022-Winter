using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3
{
    [TestClass]
    public class NullabilityTests
    {

        [TestMethod]
        public void NullDeclarationConcepts()
        {
            string? text = "Inigo Montoya";
            text = text.Length > 0 ? text : SomeMethod();
            int? number1 = null;

            System.Nullable<int> number2 = null;

            //if (text is not null)
            {
                Assert.AreEqual(13, text.Length);
            }

            //if (text == null) <-- not prefered since "==" can be overridden
            //if(text is null) <-- Prefered method use "is"
            //if(text is not null) <-- C# 9
            //if(text.Equals(null)) <-- throws null pointer exception before it can check if it was null
            //if(string.ReferenceEquals(text, null))

            Assert.IsNotNull(text);
            Assert.IsNull(number1);
        }

        private string SomeMethod() => "Princess Buttercup"; //Expression bodied member
    }
}
