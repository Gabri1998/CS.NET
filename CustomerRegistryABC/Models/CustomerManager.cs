using System.Collections.Generic;

namespace CustomerRegistryABC.Models
{
    public class CustomerManager
    {
        public List<Customer> Customers { get; private set; }

        public CustomerManager()
        {
            Customers = new List<Customer>();
        }

        public int Count()
        {
            return Customers.Count;
        }

        public void Add(Customer c)
        {
            if (c != null) Customers.Add(c);
        }

        public bool Change(int index, Customer c)
        {
            if (index < 0 || index >= Customers.Count || c == null) return false;
            Customers[index] = c;
            return true;
        }

        public bool RemoveAt(int index)
        {
            if (index < 0 || index >= Customers.Count) return false;
            Customers.RemoveAt(index);
            return true;
        }

        public Customer GetAt(int index)
        {
            if (index < 0 || index >= Customers.Count) return null;
            return Customers[index];
        }

        public List<string> ToDisplayStrings()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Customers.Count; i++)
            {
                list.Add(Customers[i].ToSafeString());
            }
            return list;
        }
    }
}
