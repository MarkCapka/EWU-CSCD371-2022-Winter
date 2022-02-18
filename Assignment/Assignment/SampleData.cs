using System;
using System.Collections.Generic;


//Mark Capka & Tyler Rose Assignment5+6 .netProgramming February 2022


/*General
 * TODO: Ensure you enable:
nullable reference types is enabled ✔
net6 targeted ✔
C# 10.0 ✔
and enabled .NET analyzers for both projects ✔
For this assignment, favor using Assert.AreEqual() (the generic version) ❌✔
All of the above should be unit tested ❌✔
Choose simplicity over complexity ❌✔
 */




/* From part 1 of assignment5+6


Using LINQ, skip the first row in the People.csv. ❌✔
Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). ❌✔
 * 
 */



namespace Assignment
{
    public class SampleData : ISampleData
    {
        // TODO 1.Implement the ISampleData.CsvRows property, loading the data from the People.csv file and returning each line as a single string. ❌✔
            // TODO Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ❌✔
            // TODO Using LINQ, skip the first row in the People.csv. ❌✔
            // TODO Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). ❌✔
        public IEnumerable<string> CsvRows => throw new NotImplementedException();

      
        
        
        
        
        
        // TODO 2.Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states. ❌✔
            //  TODO: Use ISampleData.CsvRows for your data source. ❌✔
            //  TODO: Don't forget the list should be unique. ❌✔
            //  TODO: Sort the list alphabetically. ❌✔
            //  TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. 
        public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() 
            => throw new NotImplementedException();





        


        // 3.Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states. ❌✔
            //TODO: Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows() for your data source. ❌✔
            //TODO: Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names. ❌✔
            //TODO: Given the array, consider using string.Join to combine the list into a single string. ❌✔
        public string GetAggregateSortedListOfStatesUsingCsvRows()
            => throw new NotImplementedException();









        // 4.Implement the ISampleData.People property to return all the items in People.csv as Person objects ❌✔
            //TODO: Use ISampleData.CsvRows as the source of the data. ❌✔
            //TODO: Sort the list by State, City, Zip. (Sort the addresses first then select). ❌✔
            //TODO: Be sure that Person.Address is also populated. ❌✔
            //TODO: Adding null validation to all the Person and Address properties is optional.
            //TODO: Consider using ISampleData.CsvRows in your test to verify your results. ❌✔
        public IEnumerable<IPerson> People => throw new NotImplementedException();







        // 5.Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to return a list of names where the email address matches the filter. ❌✔
            //TODO: Use ISampleData.People for your data source. ❌✔
        public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(
            Predicate<string> filter) => throw new NotImplementedException();







        // 6.Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to return a string that contains a unique, comma separated list of states. ❌✔
            //TODO: Use the people parameter from ISampleData.GetUniqueListOfStates for your data source. ❌✔
            //TODO: At a minimum, use System.Linq.Enumerable.Aggregate LINQ method to create your result. ❌✔
            //TODO: Don't forget the list should be unique. ❌✔
            //TODO: It is recommended that, at a minimum, you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to validate your result.
        public string GetAggregateListOfStatesGivenPeopleCollection(
            IEnumerable<IPerson> people) => throw new NotImplementedException();
    }
}
