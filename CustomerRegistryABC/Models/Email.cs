namespace CustomerRegistryABC.Models
{
    public class Email
    {
        public string PrivateEmail { get; set; }
        public string OfficeEmail { get; set; }

        public Email()
        {
            PrivateEmail = "";
            OfficeEmail = "";
        }

        public string ToSafeString()
        {
            return "Private: " + PrivateEmail + "\r\nOffice: " + OfficeEmail;
        }
    }
}
