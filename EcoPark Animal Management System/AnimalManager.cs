using EcoPark_Animal_Management_System.animal_gen;
using EcoPark_Animal_Management_System.category.birds;
using EcoPark_Animal_Management_System.category.mammal;
using EcoPark_Animal_Management_System.category.reptiles;
using System.Collections.Generic;
using System.Linq;

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
            return Add(animal);
        }

        public void UpdateNextId()                  // Updates counter after loading
        {
            if (Count == 0)
                return;

            int max = GetAll()
                .Select(a => int.TryParse(a.Id.Substring(1), out int n) ? n : 0)
                .Max();

            nextId = max + 1;
        }

        public List<Animal> GetAnimalsSortedByName()  // Returns animals sorted by name
        {
            return GetAll()
                .OrderBy(a => a.Name)
                .ToList();
        }

        public List<Animal> GetAnimalsSortedByAge()   // Returns animals sorted by age
        {
            return GetAll()
                .OrderBy(a => a.Age)
                .ToList();
        }

        public List<Animal> GetMammalsOnly()          // Returns only mammals
        {
            return GetAll()
                .Where(a => a is Mammal)
                .ToList();
        }

        public double GetAverageAge()                  // Returns average age of all animals
        {
            var animals = GetAll();

            if (!animals.Any())
                return 0;

            return animals.Average(a => a.Age);
        }

        public void ValidateDuplicates()               // Checks for duplicate animals
        {
            var duplicates =
                from animal in GetAll()
                group animal by new { animal.Name, Type = animal.GetType().Name } into g
                where g.Count() > 1
                select g.Key;

            if (duplicates.Any())
            {
                var d = duplicates.First();

                throw new DuplicateAnimalException(d.Name, d.Type);
            }
        }

        public string[] ToStringSummaryAllAnimals()    // Gets all summaries
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