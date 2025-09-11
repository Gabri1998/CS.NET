using System;

namespace CustomerRegistryABC.Models
{
    public class Customer
    {
        public string Id { get; private set; }
        public Contact Contact { get; set; }

        public Customer(Contact contact)
        {
            Id = Guid.NewGuid().ToString();
            Contact = contact ?? new Contact();
        }

        public string ToSafeString()
        {
            string shortId = Id.Length > 8 ? Id.Substring(0, 8) : Id;
            return shortId + " - " + Contact.ToSafeString();
        }
    }
}
