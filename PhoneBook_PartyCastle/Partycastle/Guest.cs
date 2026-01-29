using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Partycastle
{
    internal class Guest
    {
        private string firstName;
        private string lastName;
        public Guest(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }


        public string getFirstName() { return firstName; }
        public string getLastName() { return lastName; }
        public void setFirstName(string firstName)
        {

            this.firstName = firstName;
        }
        public void setLastName(string lastName)
        {
            this.lastName = lastName;
        }
    }
}

