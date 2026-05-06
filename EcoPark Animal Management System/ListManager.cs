using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

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

        public void JsonSerialize(string file)    // Saves list to JSON file
        {
            var options = new JsonSerializerOptions()
            {
                WriteIndented = true,
                PropertyNameCaseInsensitive = true,
                IncludeFields = false
            };

            string jsonString = JsonSerializer.Serialize(items, options);
            File.WriteAllText(file, jsonString);
        }

        public void JsonDeserialize(string file)  // Loads list from JSON file
        {
            string jsonString = File.ReadAllText(file);

            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            List<T> loadedItems = JsonSerializer.Deserialize<List<T>>(jsonString, options);

            if (loadedItems != null)
                items = new List<T>(loadedItems);
        }

        public void XMLSerialize(string file)     // Saves list to XML file
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (FileStream stream = new FileStream(file, FileMode.Create))
            {
                serializer.Serialize(stream, items);
            }
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

        public List<T> GetAll()                    // Returns copy of all items
        {
            return new List<T>(items);
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