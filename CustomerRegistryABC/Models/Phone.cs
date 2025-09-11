using System.Linq;

namespace CustomerRegistryABC.Models
{
    public class Phone
    {
        private string _privatePhone;
        private string _officePhone;

        public string PrivatePhone
        {
            get { return _privatePhone; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit))
                    throw new System.ArgumentException("Private phone must contain only numbers.");
                _privatePhone = value ?? "";
            }
        }

        public string OfficePhone
        {
            get { return _officePhone; }
            set
            {
                if (!string.IsNullOrEmpty(value) && !value.All(char.IsDigit))
                    throw new System.ArgumentException("Office phone must contain only numbers.");
                _officePhone = value ?? "";
            }
        }

        public Phone()
        {
            PrivatePhone = "";
            OfficePhone = "";
        }

        public string ToSafeString()
        {
            return "Private: " + PrivatePhone + "\r\nOffice: " + OfficePhone;
        }
    }
}
