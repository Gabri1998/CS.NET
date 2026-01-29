namespace CustomerRegistryABC.Models
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public Email Email { get; set; }

        public Contact()
        {
            FirstName = "";
            LastName = "";
            Address = new Address();
            Phone = new Phone();
            Email = new Email();
        }

        public bool CheckData(out string errorMessage)
        {
            errorMessage = "";

            if ((FirstName == null || FirstName == "") && (LastName == null || LastName == ""))
                errorMessage += "Provide at least a first name or last name.\r\n";

            if (Address == null) Address = new Address();

            if (Address.City == null || Address.City == "")
                errorMessage += "City is required.\r\n";

            if (Address.Country == null || Address.Country == "")
                errorMessage += "Country is required.\r\n";

            return errorMessage == "";
        }

        public string ToSafeString()
        {
            string name = (FirstName + " " + LastName).Trim();
            return name == "" ? "(no name)" : name;
        }

        public string ToDetailsSafe()
        {
            string name = (FirstName + " " + LastName).Trim();
            if (name == "") name = "(no name)";

            string details = "Name: " + name + "\r\n\r\n";
            details += "Address:\r\n" + Address.ToSafeString() + "\r\n\r\n";
            details += "Phones:\r\n" + Phone.ToSafeString() + "\r\n\r\n";
            details += "Emails:\r\n" + Email.ToSafeString() + "\r\n";

            return details;
        }
    }
}
