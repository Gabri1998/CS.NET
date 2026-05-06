using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System
{
    // Generic class for managing a collection of objects
    internal class ListManager<T> : IListManager<T>
    {
        private List<T> items;                  // Internal list storage

        public ListManager()
        {
            items = new List<T>();               // Initializes empty list
        }

        public int Count => items.Count;         // Returns number of items

        public bool Add(T item)                  // Adds item to list
        {
            if (item == null) return false;
            items.Add(item);
            return true;
        }

        public virtual bool AddWithUniqueId(T item)  // Base version - no ID
        {
            return Add(item);                     // Just adds normally
        }

        public bool Remove(int index)             // Removes item at index
        {
            if (!CheckIndex(index)) return false;
            items.RemoveAt(index);
            return true;
        }

        public bool ReplaceAt(int index, T item)   // Replaces item at index
        {
            if (item == null) return false;
            if (!CheckIndex(index)) return false;
            items[index] = item;
            return true;
        }

        public bool CheckIndex(int index)          // Validates index
        {
            return index >= 0 && index < items.Count;
        }

        public T GetAt(int index)                  // Gets item at index
        {
            if (CheckIndex(index))
                return items[index];
            return default(T);
        }

        public string[] ToStringArray()            // Converts all to strings
        {
            string[] result = new string[items.Count];
            for (int i = 0; i < items.Count; i++)
            {
                result[i] = items[i].ToString();
            }
            return result;
        }
    }
}