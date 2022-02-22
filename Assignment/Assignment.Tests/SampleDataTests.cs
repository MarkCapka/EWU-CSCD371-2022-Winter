using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Assignment;
using Moq;

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




    //TODO from part 2 
    //TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. ✔           //TODO drop question if can't figure out from recording, what his intention is. ALl addresses will be Washington. (so should probably sort on the other values like state, city, zip etc?
    //Include a test that uses LINQ to verify the data is sorted correctly (do not use a hardcoded list). ✔
    // Include a test that leverages a hardcoded list of Spokane-based addresses. 

    [TestMethod]        //TODO come back to once we figure out the hardcoded, washington state stuff
    public void GetUniqueSortedListOfStatesGivenCsvRowsTest_HardCodedInput_Success()
    {
        ISampleData sampleData = new SampleData();
        IEnumerable<string> csvRows = sampleData.CsvRows; //holds each of our individual values in the row           
                                                          //create mock type SampleData -> mock method to fetch the unique sorted list, 
                                                          //in the mock method
                                                          //instead of passing people with unique sorted states from People.csv, we pull from a hardcoded list


        var mockTest = new Mock<ISampleData>();


        IEnumerable<string> hardcodedData = csvRows.Select(item => item).Where((item => item.Contains("Spokane")));
        mockTest.SetupSequence(data => data.CsvRows).Returns(hardcodedData);

        Assert.AreEqual<IEnumerable<string>>(hardcodedData, mockTest.Object.CsvRows);

        mockTest.Verify<IEnumerable<string>>(hardcodedData => hardcodedData.CsvRows, Times.Exactly(1));

    }
   


    [TestMethod]
    public void GetAggregateSortedListOfStatesUsingCsvRows_DatasetOutputsAllUniqueStates_Success()
    {

        ISampleData sampleData = new SampleData();
        string csvRows = sampleData.GetAggregateSortedListOfStatesUsingCsvRows(); //holds each of our individual values in the row                       

        Assert.AreEqual<string>("AL,AZ,CA,DC,FL,GA,IN,KS,LA,MD,MN,MO,MT,NC,NE,NH,NV,NY,OR,PA,SC,TN,TX,UT,VA,WA,WV", csvRows);
    }

    
      //TODO 5. - Use `ISampleData.People` for your data source.  ✔

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
        List<IPerson> peopleList = new();
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

