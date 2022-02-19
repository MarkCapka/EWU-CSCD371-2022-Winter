using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsState_Success()
        {
            SampleData sampleData = new();
            IEnumerable<string> statesUniqueSorted = sampleData.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(statesUniqueSorted.Count() > 0);
           foreach (string item in statesUniqueSorted)
            {
                Assert.IsTrue(item.Length == 2);
            }
         
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedList_ReturnsOneState()
        {
            //var mockSD = new Mock<ISampleData>();
            //mockSD.SetupGet(x => x.CsvRows).Returns(
            //    new string[]{
            //    "1,schuyler,asplin,sasplin@ewu.edu,1228 s. division st.,spokane,WA,99202",
            //      "7,ray,tanner,atanner5@ewu.edu,1012 s. maple st.,spokane,WA,99204"
            //          }
            //    );
                
            //    IEnumerable<string>statesUniqueSorted = mockSD.Object.GetUniqueSortedListOfStatesGivenCsvRows();
            //Console.WriteLine(statesUniqueSorted.First());
            //Assert.AreEqual<int>(1, statesUniqueSorted.Count());
        }
        [TestMethod]
        public void People_NumberOfPeopleEqualToRows_Success()
        {
            SampleData sampleDataSD = new();
            Assert.AreEqual<int>(sampleDataSD.CsvRows.Count(), sampleDataSD.People.Count());

            // peeople not null/ are valid ()
            // sorted correctly

        }
    }
}

//List<string> a = GetUniqueSortedListoFStatesGivenCsvRows()
//List<string> b = GetUniqueSortedListoFStatesGivenCsvRows().Sort()
//Assert.IsTrue()