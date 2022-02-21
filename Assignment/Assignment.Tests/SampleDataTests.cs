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
        SampleData sd = new();

        [TestInitialize]
        public void testInit()
        {
         sd = new();
        }

        [TestMethod]
        public void CsvRows_ReturnsIEnumerable()
        {

            var CsvRowsRet = sd.CsvRows;
            Assert.IsTrue(CsvRowsRet.GetType().GetInterface(nameof(IEnumerable<string>)) is not null);
        }

        [TestMethod]
        public void CsvRows_SkipsFirstRow()
        {
            var CsvRowsRet = sd.CsvRows;
            Assert.IsFalse(CsvRowsRet.ElementAt<string>(0).Equals("Id,FirstName,LastName,Email,StreetAddress,City,State,Zip" + Environment.NewLine));
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_ReturnsState_Success()
        {
            IEnumerable<string> statesUniqueSorted = sd.GetUniqueSortedListOfStatesGivenCsvRows();

            Assert.IsTrue(statesUniqueSorted.Count() > 0);
           foreach (string item in statesUniqueSorted)
            {
                Assert.IsTrue(item.Length == 2);
            }
         
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_HardCodedList_ReturnsOneState()
        {
            string path = "DELETEME.csv";

            string[] hottestGuysInSpokane = {
                "1,Schuyler,Asplin,sasplin@ewu.edu,1228 S. Division St., Spokane,WA,99202",
                "1,Ray,Tanner,atanner5@ewu.edu,1012 S. Maple St.,Spokane,WA,99204"
            };


            File.WriteAllLines(path, hottestGuysInSpokane);

            sd = new(path);

            IEnumerable<string> spokaneAddresses = sd.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.AreEqual<int>(1, spokaneAddresses.Count());
        }

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRows_StatesAreOrdered()
        {
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();
            IEnumerable<string> statesSortedByLinq = sd.GetUniqueSortedListOfStatesGivenCsvRows().OrderBy(item => item);

            bool allMatch = states.SequenceEqual<string>(statesSortedByLinq);
      
            Assert.IsTrue(allMatch);
            
        }

        [TestMethod]
        public void People_NumberOfPeopleEqualToRows_Success()
        {
            Assert.AreEqual<int>(sd.CsvRows.Count(), sd.People.Count());
        }
        
        
        [TestMethod]
        public void GetAggregateSortedListOfStatesGivenPeople_StatesAreOrdered()
        {
            string[] statesFromPeople = sd.GetAggregateSortedListOfStatesUsingCsvRows().Split(',');
            IEnumerable<string> states = sd.GetUniqueSortedListOfStatesGivenCsvRows();

            bool allMatch = statesFromPeople.SequenceEqual<string>(states);

            Assert.IsTrue(allMatch);
        }

        [TestMethod]
        public void FilterByEmailAddress_ReturnsGovEmails()
        {
            (string, string)[] chosenPeople = sd.FilterByEmailAddress(item => item.Contains(".gov")).ToArray();

            foreach(var p in chosenPeople)
            {
                Console.WriteLine(p);
            }
        }
    }
}

//List<string> a = GetUniqueSortedListoFStatesGivenCsvRows()
//List<string> b = GetUniqueSortedListoFStatesGivenCsvRows().Sort()
//Assert.IsTrue()