using System;

namespace EcoPark_Animal_Management_System
{
    // Generic interface for managing a collection of objects
     interface IListManager<T>
    {
        int Count { get; }                     // Gets number of items
        bool Add(T item);                       // Adds an item to the list
        bool AddWithUniqueId(T item);           // Adds item with unique ID
        bool Remove(int index);                  // Removes item at index
        bool ReplaceAt(int index, T item);       // Replaces item at index
        bool CheckIndex(int index);              // Checks if index is valid
        T GetAt(int index);                      // Returns item at index
        void JsonSerialize(string file);
        void JsonDeserialize(string file);
        void XMLSerialize(string file);
        string[] ToStringArray();                 // Returns all items as strings
    }
}