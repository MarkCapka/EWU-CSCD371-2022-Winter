using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Assignment;


namespace Assignment.Tests;
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

        ISampleData sampleData = new SampleData();
        IEnumerable<string> csvRows = sampleData.CsvRows;
        Assert.Fail();


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
    //TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. ❌✔           //TODO drop question if can't figure out from recording, what his intention is. ALl addresses will be Washington. (so should probably sort on the other values like state, city, zip etc?
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


        Assert.Fail();
    }
   


    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_DatasetOutputsAllUniqueStates_Success()
    {

        ISampleData sampleData = new SampleData();
        string csvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows(); //holds each of our individual values in the row                       

        Assert.AreEqual("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", csvRows);
    }

    
      //TODO 5. - Use `ISampleData.People` for your data source. ❌✔

    [TestMethod]
    public void FilterByEmailAddressTest()
    {
        ISampleData sampleData = new SampleData();
        IEnumerable<(string FirstName, string LastName)>? aEmails = sampleData.FilterByEmailAddress(new Predicate<string>(email => email.StartsWith('a')));
        Assert.AreEqual<int>(4, aEmails.Count());
        Assert.AreEqual<(string FirstName, string LastName)>(("Amelia", "Toal"), aEmails.First());
    }



    //6. GetAggregateListOfStatesGivenPeopleCollection: 
    //TODO: It is recommended that, at a minimum, you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to validate your result.

    [TestMethod]
    public void GetAggregateListOfStatesGivenPeopleCollectionTest()
    {
        List<IPerson> peopleList = new List<IPerson>();
        peopleList.Add(new Person("Mark", "Michaelis", new Address("123 Seaseme St", "Spokane", "WA", "99999"), "jobs@intelliTect.com"));
        ISampleData sampleData = new SampleData();

        string data = sampleData.GetAggregateListOfStatesGivenPeopleCollection(peopleList);
        Assert.AreEqual<string>("WA", data);
        Assert.IsTrue(data.Split(',').Length == 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void FilterByEmailAddress_NullFilter_ThrowsException()
    {
        ISampleData sampleData = new SampleData();
        _ = sampleData.FilterByEmailAddress(null!);
    }
}

