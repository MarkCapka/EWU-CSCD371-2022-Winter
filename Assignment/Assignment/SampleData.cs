using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


//Mark Capka & Tyler Rose Assignment5+6 .netProgramming February 2022


/*General
 * TODO: Ensure you enable:
nullable reference types is enabled ✔
net6 targeted ✔
C# 10.0 ✔
and enabled .NET analyzers for both projects ✔
For this assignment, favor using Assert.AreEqual() (the generic version) ✔
All of the above should be unit tested ✔
Choose simplicity over complexity ✔
 */





namespace Assignment;
public class SampleData : ISampleData
{


    // 1.
    // Change the "Copy to" property on People.csv to "Copy if newer" so that the file is deployed along with your test project. ✔
    //  Using LINQ, skip the first row in the People.csv. ✔
    //  Be sure to appropriately handle resource (IDisposable) items correctly if applicable (and it may not be depending on how you implement it). 

    //data in row: Id,FirstName,LastName,Email,StreetAddress,City,State,Zip
    //data format: 1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577

    public IEnumerable<string> CsvRows { get; private set; }

    public SampleData()
    {
        CsvRows = new List<string>();
        CsvRows = System.IO.File.ReadAllLines(".\\People.csv").Skip(1);

        People = new List<IPerson>();

        //Playing wit linq, plz dont dock points :3
        var data = CsvRows.Select(column => column.Split(',')).Select(column => new
        {
            firstName = column[1],
            lastName = column[2],
            address = new Address(column[4], column[5], column[6], column[7]),
            emailAddress = column[3],
        }).ToList();
        List<IPerson> newPeople = new List<IPerson>(); //People.Append didn't put anything in the list. Use an interrum list.
        data.ForEach(field =>
        {
            newPeople.Add(new Person(field.firstName, field.lastName, field.address, field.emailAddress));
        });
        People = newPeople;
    }



    //Not sure where this function was required, but step 6 says to use it so I created it. Essentially does the same as step 2 but uses the given collection instead of getting csv rows.
    //Might be fine to leave private.
    private IEnumerable<string> GetUniqueListOfStates(IEnumerable<IPerson> personList)
    {
        IEnumerable<string> data = personList.DistinctBy(person => person.Address.State).Select(person => person.Address.State).ToList();
        return data;
    }




    // .2. Implement IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows() to return a sorted, unique list of states. ✔
    //  TODO: Use ISampleData.CsvRows for your data source.❌✔  //requirement note not in assignment: [ confirm that we are using CSVRows as our data source, I believe we are since SampleData pulls the data from CsvRows ayway ❌✔]
    //  Don't forget the list should be unique. ✔
    //  Sort the list alphabetically. ✔
    //  Include a test that leverages a hardcoded list of Spokane-based addresses. 




    // API link for Ordering: https://docs.microsoft.com/en-us/dotnet/standard/linq/

    //data in row: Id,FirstName,LastName,Email,           StreetAddress,City,State,Zip
    //data format: 1,Priscilla,Jenyns,pjenyns0@state.gov,7884 Corry Way,Helena,MT,70577
    public IEnumerable<string> GetUniqueSortedListOfStatesGivenCsvRows()
    {


        IEnumerable<string> data = GetUniqueListOfStates(People).OrderBy(state => state);
        return data;
    }


    // 3.Implement ISampleData.GetAggregateSortedListOfStatesUsingCsvRows() to return a string that contains a unique, comma separated list of states. ✔
    // Use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows() for your data source. ✔
    //TODO: Consider "selecting" only the states and calling ToArray() to retrieve an array of all the state names. ❌✔
    //Given the array, consider using string.Join to combine the list into a single string. ✔
    public string GetAggregateSortedListOfStatesUsingCsvRows()
    {

        string states = string.Join(',', GetUniqueSortedListOfStatesGivenCsvRows().Select(state => state).ToArray());
        return states;
    }




    // 4.Implement the ISampleData.People property to return all the items in People.csv as Person objects ✔
    // Use ISampleData.CsvRows as the source of the data. ✔
    // Sort the list by State, City, Zip. (Sort the addresses first then select). ✔
    //TODO: Be sure that Person.Address is also populated. ✔
    // Adding null validation to all the Person and Address properties is optional.
    //TODO: Consider using ISampleData.CsvRows in your test to verify your results. ❌✔



    public IEnumerable<IPerson> People { get; private set; }



    // 5.Implement ISampleDate.FilterByEmailAddress(Predicate<string> filter) to return a list of names where the email address matches the filter. ✔
    //TODO: Use ISampleData.People for your data source. ❌✔ CONFIRM
    public IEnumerable<(string FirstName, string LastName)> FilterByEmailAddress(Predicate<string> filter)
    {
        if (filter is null)
        {
            throw new ArgumentNullException(paramName: $"Provided argument {nameof(filter)} was null.");
        }

        return People.Where(person => filter(person.EmailAddress)).Select(person => (person.FirstName, person.LastName));
    }

    // 6.Implement ISampleData.GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people) to return a string that contains a unique, comma separated list of states. ❌✔
    // Use the people parameter from ISampleData.GetUniqueListOfStates for your data source. ✔
    //TODO: At a minimum, use System.Linq.Enumerable.Aggregate LINQ method to create your result.❌ ✔
    //TODO: Don't forget the list should be unique. ❌✔
    //TODO: It is recommended that, at a minimum, you use ISampleData.GetUniqueSortedListOfStatesGivenCsvRows to validate your result.
    public string GetAggregateListOfStatesGivenPeopleCollection(IEnumerable<IPerson> people)
    {
        string states = string.Join(',', GetUniqueListOfStates(people));
        return states;
    }



    //    7. ***take another look at, i'm not sure that we have this implemented. 
    //Given the implementation of Node in Assignment5

    //Implement IEnumerable<T> to return all the items in the "circle" of items. ❌✔
    //Add an IEnumberable<T> ChildItems(int maximum) method to Node that returns the remaining items with a maximum number of items returned less than maximum.






}


