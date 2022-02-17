using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



/*
 * 
 * 
 * From part 1 of assignment5+6


Using LINQ, skip the first row in the People.csv. ❌✔
Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). ❌✔
 * 
 */


namespace Assignment;
public class SampleData : ISampleData
{

    // TODO 1.Implement the ISampleData.CsvRows property, loading the data from the People.csv file and returning each line as a single string. ❌✔
    // TODO Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ✔
    // TODO Using LINQ, skip the first row in the People.csv. ❌✔
    // TODO Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). ❌✔










    //data in row: Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
    //data format: 1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577

    public IEnumerable<string> CsvRows
    {
        get
        {
            string[] csvRows = System.IO.File.ReadAllLines(".\\People.csv");
            IEnumerable<string> rows = new List<string>();
            rows = csvRows.Skip(1);
            return rows;
        }
    }

    //name of file we are reading in 
    //string?[] _Row = File.ReadLines(@"People.csv"); //@ indicates that it is 
    // using (var reader = new StringReader(lineCount)



    //TODO divide up the file using the following format: 

    // public IEnumerable<IPerson> People = new Person(firstName, lastName, StreetAddress, emailAddress);
    //foreach row in Csv: 
    //new string from csv to row: 
    //  split on comma
    //add split value to list containing: Id,FirstName,LastName,Email,StreetAddress,City,State,Zip

    //this.Id = read in first column of ith row
    // Row.ToList(Id = 1, FirstName = "Priscilla", LastName = "Jenyns", Email = "pjenyns0@state.gov", StreetAddress = "7884 Corry Way", City = "Helena", Zip ="70577"));









    // TODO 2.Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states. ❌✔
    //  TODO: Use ISampleData.CsvRows for your data source. ❌✔
    //  TODO: Don't forget the list should be unique. ❌✔
    //  TODO: Sort the list alphabetically. ❌✔
    //  TODO: Include a test that leverages a hardcoded list of Spokane-based addresses. 




    // API link for Ordering: https://docs.microsoft.com/en-us/dotnet/standard/linq/

    //data in row: Id,FirstName,LastName,Email,           StreetAddress,City,State,Zip
    //data format: 1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {
        IEnumerable<string> data = People.DistinctBy(person => person.Address.State).Select(person => person.Address.State).ToList().OrderBy(state => state.ToString());
        return data;
    }

    //Psuedocode, just thinking out
    //CsvRows[] csvRows = new list of strings <--- until end of line : readInCsv
    //foreach(row in csvRows)
    //csvRows[row].split(",").Distinct(Ema;
    //Table of elements: id,FirstName,LastName,Email,StreetAddress,City,State,Zip
    //var uniqueSortedStates = rows.GetRows(start, end).DistinctBy(










    // 3.Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states. ❌✔
    //TODO: Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows() for your data source. ❌✔
    //TODO: Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names. ❌✔
    //TODO: Given the array, consider using string.Join to combine the list into a single string. ❌✔
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {
        string states = string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows());
        return states;
    }









    // 4.Implement the ISampleData.People property to return all the items in People.csv as Person objects ❌✔
    //TODO: Use ISampleData.CsvRows as the source of the data. ❌✔
    //TODO: Sort the list by State, City, Zip. (Sort the addresses first then select). ❌✔
    //TODO: Be sure that Person.Address is also populated. ❌✔
    //TODO: Adding null validation to all the Person and Address properties is optional.
    //TODO: Consider using ISampleData.CsvRows in your test to verify your results. ❌✔



    public IEnumerable<IPerson> People
    {
        get
        {
            IEnumerable<IPerson> data = new List<IPerson>();
            foreach (string personData in CsvRows)
            {
                string[] individualPersonData = personData.Split(',');
                Person person = new Person(individualPersonData[1], individualPersonData[2],
                    new Address(individualPersonData[4], individualPersonData[5], individualPersonData[6], individualPersonData[7]),
                    individualPersonData[3]);
                data.Append(person);
            }
            return data;
        }
    }






    // 5.Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to return a list of names where the email address matches the filter. ❌✔
    //TODO: Use ISampleData.People for your data source. ❌✔
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        if (filter == null)
        {
            throw new ArgumentNullException(paramName: $"Provided argument {nameof(filter)} was null.");
        }
        return People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));
    }

    //Not sure where this function was required, but step 6 says to use it so I created it. Essentially does the same as step 2 but uses the given collection instead of getting csv rows.
    //Might be fine to leave private.
    private IEnumerable<string> GetUniqueListOfStates(IEnumerable<IPerson> personList)
    {
        IEnumerable<string> data = personList.DistinctBy(person => person.Address.State).Select(person => person.Address.State).ToList().OrderBy(state => state.ToString());
        return data;
    }

    // 6.Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to return a string that contains a unique, comma separated list of states. ❌✔
    //TODO: Use the people parameter from ISampleData.GetUniqueListOfStates for your data source. ❌✔
    //TODO: At a minimum, use System.Linq.Enumerable.Aggregate LINQ method to create your result. ❌✔
    //TODO: Don't forget the list should be unique. ❌✔
    //TODO: It is recommended that, at a minimum, you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to validate your result.
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) 
    {
        string states = string.Join(',', GetUniqueListOfStates(people));
        return states;
    }







}
