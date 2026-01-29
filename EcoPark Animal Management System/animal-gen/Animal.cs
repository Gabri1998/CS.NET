using EcoPark_Animal_Management_System.enums;
using System;

namespace EcoPark_Animal_Management_System.animal_gen
{
    // Base abstract class for all animals in the system
    public abstract class Animal
    {
        // Static counter used to generate unique IDs
        private static int idCounter = 1;

        // Unique animal identifier
        public string Id { get; }

        // Optional image path for the animal
        public string ImagePath { get; set; }

        // Animal name
        public string Name { get; set; }

        // Backing field for age
        private int age;

        // Animal age (cannot be negative)
        public int Age
        {
            get => age;
            set => age = value < 0 ? 0 : value;
        }

        // Backing field for weight
        private double weight;

        // Animal weight (must be greater than zero)
        public double Weight
        {
            get => weight;
            set => weight = value <= 0 ? 0.1 : value;
        }

        // Animal gender
        public GenderType Gender { get; set; }

        // Constructor assigns a unique ID automatically
        protected Animal()
        {
            Id = "AN-" + idCounter.ToString("D3");
            idCounter++;
        }

        // Used for displaying animal type in lists
        public string DisplayName => GetType().Name;

        // Returns formatted animal information
        public override string ToString()
        {
            return
                "Animal Info:\r\n" +
                $"  ID: {Id}{Environment.NewLine}" +
                $"Name: {Name}{Environment.NewLine}" +
                $"Age: {Age}{Environment.NewLine}" +
                $"Weight: {Weight}{Environment.NewLine}" +
                $"Gender: {Gender}{Environment.NewLine}";
        }
    }
}
