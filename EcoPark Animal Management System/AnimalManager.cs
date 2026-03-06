using EcoPark_Animal_Management_System.animal_gen;
using EcoPark_Animal_Management_System.category.mammal;
using EcoPark_Animal_Management_System.category.birds;
using EcoPark_Animal_Management_System.category.reptiles;

namespace EcoPark_Animal_Management_System
{
    // Manages a collection of Animal objects
    internal class AnimalManager : ListManager<Animal>
    {
        private static int nextId = 100;          // Counter for unique IDs

        public string GenerateId(Animal animal)    // Creates category-based ID
        {
            string letter;

            if (animal is Mammal)
                letter = "M";
            else if (animal is Bird)
                letter = "B";
            else if (animal is Reptile)
                letter = "R";
            else
                letter = "X";

            return letter + nextId++;
        }

        public override bool AddWithUniqueId(Animal animal)  // Adds with new ID
        {
            if (animal == null) return false;
            animal.Id = GenerateId(animal);        // Assign unique ID
            return Add(animal);                    // Add to list
        }

        public string[] ToStringSummaryAllAnimals()  // Gets all summaries
        {
            string[] summaries = new string[Count];
            for (int i = 0; i < Count; i++)
            {
                summaries[i] = GetAt(i).ToStringSummary();
            }
            return summaries;
        }
    }
}