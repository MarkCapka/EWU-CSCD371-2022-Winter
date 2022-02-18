using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{

    //TODO outline tests below 

    [TestClass]
    public class PersonTests
    {
        
       

        [TestMethod()]
        public void PersonTest()
        {
            Person person = new Person(_FirstName, lastName, address, emailAddress);
            Assert.Fail();
        }
    }
}