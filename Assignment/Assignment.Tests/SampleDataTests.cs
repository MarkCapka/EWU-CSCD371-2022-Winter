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
        string path = "DELETEME.csv";

        [TestInitialize]
        public void testInit()
        {
         SampleData sd = new();
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
            string[] hottestGuysInSpokane = {
                "", // csvRows getter deletes first row
                "1,Schuyler,Asplin,sasplin@ewu.edu,1228 S. Division St., Spokane,WA,99202",
                "1,Ray,Tanner,atanner5@ewu.edu,1012 S. Maple St.,Spokane,WA,99204"
            };


            File.WriteAllLines(path, hottestGuysInSpokane);

            sd = new(path);

            IEnumerable<string> spokaneAddresses = sd.GetUniqueSortedListOfStatesGivenCsvRows();
            Assert.AreEqual<int>(1, spokaneAddresses.Count());

            File.Delete(path);
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

        //person tests: fields populated correctly, same num of rows
        [TestMethod]
        public void People_FieldsPopulatedCorrectly_Success()
        {
            string[] hottestGuysInSpokane = {
                "", // csvRows getter deletes first row
                "1,Schuyler,Asplin,sasplin@ewu.edu,some big mansion, Spokane,WA,99420",
                "1,Ray,Tanner,atanner5@ewu.edu,a flippin yacht,Spokane,WA,77777" };
                

            File.WriteAllLines(path, hottestGuysInSpokane);

            sd = new(path);

            IEnumerable<IPerson> peopleE = sd.People;
            IPerson[] people = peopleE.ToArray();

            string[] schuyler = hottestGuysInSpokane[1].Split(',');
            string[] ray = hottestGuysInSpokane[2].Split(',');

            Assert.AreEqual<string>(schuyler[1], people[0].FirstName);
            Assert.AreEqual<string>(schuyler[2], people[0].LastName);
            Assert.AreEqual<string>(schuyler[3], people[0].EmailAddress);
            Assert.AreEqual<string>(schuyler[4], people[0].Address.StreetAddress);
            Assert.AreEqual<string>(schuyler[5], people[0].Address.City);
            Assert.AreEqual<string>(schuyler[6], people[0].Address.State);
            Assert.AreEqual<string>(schuyler[7], people[0].Address.Zip);

            Assert.AreEqual<string>(ray[1], people[1].FirstName);
            Assert.AreEqual<string>(ray[2], people[1].LastName);
            Assert.AreEqual<string>(ray[3], people[1].EmailAddress);
            Assert.AreEqual<string>(ray[4], people[1].Address.StreetAddress);
            Assert.AreEqual<string>(ray[5], people[1].Address.City);
            Assert.AreEqual<string>(ray[6], people[1].Address.State);
            Assert.AreEqual<string>(ray[7], people[1].Address.Zip);
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
            string[] emails = {
                "", //CsvRows skips first row
                "0,Amelia,Toal,atoall@fema.gov,4667 Jay Plaza,Huntington,WV,44302",
                "1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577",
                "2,Karin,Joder,kjoder1@quantcast.com,03594 Florence Park,Tampa,FL,71961",
                "3,Chadd,Stennine,cstennine2@wired.com,94148 Kings Terrace,Long Beach,CA,59721",
                "4,Fremont,Pallaske,fpallaske3@umich.edu,16958 Forster Crossing,Atlanta,GA,10687",
                "5,Melisa,Kerslake,mkerslake4@dion.ne.jp,283 Pawling Parkway,Dallas,TX,88632",
                "6,Darline,Brauner,dbrauner5@biglobe.ne.jp,33 Menomonie Trail,Atlanta,GA,10687"
            };
            File.WriteAllLines(path, emails);
            sd = new(path);

            
            (string, string)[] chosenPeople = sd.FilterByEmailAddress(item => item.Contains(".gov")).ToArray();

            Assert.AreEqual<int>(2, chosenPeople.Count());

            File.Delete(path);
        }

        
    }
}

//List<string> a = GetUniqueSortedListoFStatesGivenCsvRows()
//List<string> b = GetUniqueSortedListoFStatesGivenCsvRows().Sort()
//Assert.IsTrue()