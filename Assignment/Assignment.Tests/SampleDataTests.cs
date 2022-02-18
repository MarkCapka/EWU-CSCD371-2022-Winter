using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Assignment;


namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        //List<string> _CsvRows = new List<string>(File.ReadLines(@"People.csv"));
/*
        [TestMethod]
        public void AssignmentSampleData_DataPutInRowAsString_Success()
        {

            List<string> row = new List<string>(); 
            List<IEnumerable<string>>[] csvRows = new IEnumerable<string>(); //holds each of our individual values in the row
            List<Person> persons = csvRows;

            IEnumerable<Person> persons = cvsRows.Where(item => item.FirstName, item => item.LasttName);
            IEnumerable<string> Name = cvsRows.Select(item => (item.FirstName, item.LastName));

            foreach(IEnumerable<Person> item in csvRows)
            {

                object p = csvRows.Add(item.FirstName, item.LastName, item.EmailAddress);
            }
            

         
            //DataCsv format: Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
            Assert.IsTrue(csvRows[0] == "Id,FirstName,LastName,Email,StreetAddress,City,State,Zip");
            Assert.AreEqual("1, Priscilla, Jenyns, pjenyns0@state.gov, 7884 Corry Way, Helena, MT, 70577", cvsRow[1].ToString());

            //data format:

        }

        */
        //TODO from part 2 
        //TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. ❌✔
        //TODO: Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ❌✔

        [TestMethod]
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest_HardCodedInput_Success()
        {
            Assert.IsTrue(true);
            Assert.Fail();
        }
        

        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_DatasetOutputsAllUniqueStates_Success()
        {
            
            //IEnumerable<string> rows = _CsvRows.Where(item => item.GroupBy(.Select(item =>

            //{

            //}).ToList());    
            ISampleData sampleData = new SampleData();  
            string list = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            list.
            Assert.IsTrue(true);
        }


        [TestMethod]
        public void FilterByEmailAddressTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {
            Assert.Fail();
        }




    }
}