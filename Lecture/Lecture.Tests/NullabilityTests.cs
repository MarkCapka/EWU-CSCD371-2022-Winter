using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Tests
{
    [TestClass]
    public class NullabilityTests
    {
        [TestMethod]
        public void NullDeclarationConcepts()
        {
            string? text = "Inigo Montoya";
            text = text.Length > 0 ? text : SomeMethod();
            int? number = null; // Nullable<int> number2 = null;

            // if(text == null)
            // Use These:
            // if (text is not null)
            {
                Assert.AreEqual(13, text.Length);
            }
            if (text is null) { }
            // if(text.Equals(null)
            // if (string.ReferenceEquals(text, null))

            Assert.IsNotNull(text);
            Assert.IsNull(number);
        }

        private string SomeMethod() =>
            "Princess Buttercup";

    }
}
