using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Address : IAddress
    {
        public string? StreetAddress {get; set;}

        public string? City { get; set; }

        public string? State {get; set;}

    public string? Zip { get; set; }
    }
}
