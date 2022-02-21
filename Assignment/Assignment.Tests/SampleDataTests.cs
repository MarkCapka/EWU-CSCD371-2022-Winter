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


        [TestMethod]
        public void AssignmentSampleData_1stRowSkipped_Success()
        {
            ISampleData sampleData = new SampleData();
            IEnumerable<string> csvRows = sampleData.CsvRows; //holds each of our individual values in the row           

            Assert.IsFalse(csvRows.First().Contains("Id"));
            Assert.IsFalse(csvRows.First().Contains("FirstName"));
            Assert.IsFalse(csvRows.First().Contains("LastName"));
            Assert.IsFalse(csvRows.First().Contains("Email"));
            Assert.IsFalse(csvRows.First().Contains("StreetAddress"));
            Assert.IsFalse(csvRows.First().Contains("City"));
            Assert.IsFalse(csvRows.First().Contains("State"));
            Assert.IsFalse(csvRows.First().Contains("Zip"));

        }



            
        [TestMethod]
        public void AssignmentSampleData_DataPutInRowAsString_Success()
        {

            IEnumerable<string> csvRows = sampleData.CsvRows; //holds each of our individual values in the row     

            // List<IPerson> persons = csvRows;

            // IEnumerable<Person> persons = cvsRows.Where(item => item.FirstName, item => item.LasttName);
            //IEnumerable<string> Name = cvsRows.Select(item => (item.FirstName, item.LastName));

            //foreach(IEnumerable<Person> item in csvRows)
            //{

            //    object p = csvRows.Add(item.FirstName, item.LastName, item.EmailAddress);
            //}



            //DataCsv format: Id,FirstName,LastName,Email,StreetAddress,City,State,Zip

            //  Assert.AreEqual("1, Priscilla, Jenyns, pjenyns0@state.gov, 7884 Corry Way, Helena, MT, 70577", cvsRow[1].ToString());

            //data format:

        }

        //TODO from part 2 
        //TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. ❌✔           //TODO drop question if can't figure out from recording, what his intention is. ALl addresses will be Washington. 
        //TODO: Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ❌✔
        //  TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. 

        [TestMethod]        //TODO come back to once we figure out the hardcoded, washington state stuff
        public void GetUniqueSortedListOfStatesGivenCsvRowsTest_HardCodedInput_Success()
        {
            ISampleData sampleData = new SampleData();
            IEnumerable<string> csvRows = sampleData.CsvRows; //holds each of our individual values in the row           
                                                              //create mock type SampleData -> mock method to fetch the unique sorted list, 
                                                              //in the mock method
                                                              //instead of passing people with unique sorted states from People.csv, we pull from a hardcoded list

            
            Assert.IsTrue(true);
            //  Assert.Fail();
        }



        [TestMethod]
        public void GetAggregateSortedListOfStatesUsingCsvRows_DatasetOutputsAllUniqueStates_Success()
        {

            ISampleData sampleData = new SampleData();
            string csvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows(); //holds each of our individual values in the row                       
         
            

            
            
        //TODO    csvRows.OrderBy(state => state).ThenBy(x => x); 
            //count = 50 


            //}).ToList());    

            // string list = sampleData.GetAggregateSortedListOfStatesUsingCsvRows();
            //   list.

           //Assert.AreEqual();
            Assert.AreEqual("", csvRows);
        }


        [TestMethod]
        public void FilterByEmailAddressTest()
        {

            ISampleData sapmleData = new SampleData();

            Assert.Fail();
        }

        [TestMethod]
        public void GetAggregateListOfStatesGivenPeopleCollectionTest()
        {


           // IPerson Person = new Person(firstName, lastName, address, emailAddress);

            Assert.Fail();
        }






    }
}