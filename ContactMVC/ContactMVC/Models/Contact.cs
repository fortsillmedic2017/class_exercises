using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactMVC.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int ContactId { get; set; }      //helps make each object unique
        private static int NextId = 1;

        public Contact()
        {
            ContactId = NextId;
            NextId++;

        }

    }
}
