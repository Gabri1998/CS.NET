using System.Linq;

namespace CustomerRegistryABC.Models
{
    public class Address
    {
        private string _street;
        private string _zipCode;
        private string _city;
        private string _country;

        public string Street
        {
            get { return _street; }
            set { _street = value ?? ""; }
        }

        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit))
                    throw new System.ArgumentException("ZIP code must contain only numbers.");
                _zipCode = value ?? "";
            }
        }

        public string City
        {
            get { return _city; }
            set { _city = value ?? ""; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value ?? ""; }
        }

        public Address()
        {
            Street = "";
            ZipCode = "";
            City = "";
            Country = "";
        }

        public Address(string street, string zip, string city, string country)
        {
            Street = street ?? "";
            ZipCode = zip ?? "";
            City = city ?? "";
            Country = country ?? "";
        }

        public string ToSafeString()
        {
            return Street + "\r\n" + ZipCode + " " + City + "\r\n" + Country;
        }
    }
}
