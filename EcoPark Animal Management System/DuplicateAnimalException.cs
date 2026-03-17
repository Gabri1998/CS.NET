using System;

namespace EcoPark_Animal_Management_System
{
    // Custom exception used when duplicate animals are detected
    internal class DuplicateAnimalException : Exception
    {
        // Stores the duplicate animal name
        public string AnimalName { get; }

        // Stores the duplicate animal type
        public string AnimalType { get; }

        // Constructor used when a duplicate animal is found
        public DuplicateAnimalException(string name, string type)
            : base($"Duplicate animal detected: {name} ({type})")
        {
            AnimalName = name;
            AnimalType = type;
        }
    }
}