using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/*
 *
4.  Implement the ISampleData.People property to return all the items in People.csv as Person objects ❌✔

Use ISampleData.CsvRows as the source of the data. ❌✔
Sort the list by State, City, Zip. (Sort the addresses first then select). ❌✔
Be sure that Person.Address is also populated. ❌✔
Adding null validation to all the Person and Address properties is optional.
Consider using ISampleData.CsvRows in your test to verify your results. ❌✔
 * 
 */




namespace Assignment
{
    public class Person : IPerson //TODO change privacy? Also is this implementing intraface correctly?
    {

        //person interface below
        public string? FirstName { get; set;  }   
        public string? LastName { get; set; }
        public string? Name { get; set; }    //for aggregating name? not sure if needed yet. 
        public string? EmailAddress { get; set; }

        public IAddress? Address { get; set; }








        protected Person(string firstName, string lastName, string emailAddress, IAddress address)
        {
           
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Address = address;
        }
  
        //end IPerson
    }
}
