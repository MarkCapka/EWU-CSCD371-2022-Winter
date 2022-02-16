using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void CsvRows_ReturnsIEnumerable()
        {
            SampleData sd = new();
            var CsvRowsRet = sd.CsvRows;
            Assert.IsTrue(CsvRowsRet.GetType().GetInterface(nameof(IEnumerable<string>)) is not null);
        }

        [TestMethod]
        public void CsvRows_SkipsFirstRow()
        {
            SampleData sd = new();
            var CsvRowsRet = sd.CsvRows;
            Assert.IsFalse(CsvRowsRet.ElementAt<string>(0).Equals("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip" + Environment.NewLine));
        }
    }
}