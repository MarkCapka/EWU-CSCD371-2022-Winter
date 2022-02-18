using System.Linq;
using System.Collections.Generic;
using System.Collections;

namespace Assignment
{
    public class Person : IPerson, IEnumerable<IPerson>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IAddress Address { get; set; }
        public string EmailAddress { get; set; }

        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            EmailAddress = emailAddress;
            Address = address;
            
            Person person = new Person(firstName, lastName, address, emailAddress);
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            yield return this;
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
