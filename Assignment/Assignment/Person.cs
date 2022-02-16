using System.Linq;
using System.Collections.Generic;

namespace Assignment
{
    public class Person : IPerson
    {

        private string _FirstName;
        private string _LastName;
        private string _Email;
        private IAddress _Address;
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        public string LastName { get { return _LastName;} set { _LastName = value; } }  
        private string EmailAddress { get { return _Email; } set { _Email = value; }}
        public IAddress Address { get { return _Address; } set { _Address = value;  } }

        public Person(string firstName, string lastName, IAddress address, string emailAddress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;   
            this.EmailAddress = emailAddress;
            this.Address = address;

            Person person = new Person(firstName, lastName, address, emailAddress);
        }

        

      
    }
}
