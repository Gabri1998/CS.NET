using EcoPark_Animal_Management_System.category.mammal;
using System;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Dog mammal
    internal class Dog : Mammal
    {
        // Indicates whether the dog is trained
        public bool IsTrained { get; set; }

        // Dog breed
        public string Breed { get; set; }

        // Backing field for loyalty level
        private int level;

        // Loyalty level (0–10)
        public int LoyaltyLevel
        {
            get => level;
            set => level = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns full string including dog-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nDog Info:\r\n" +
                $"  Breed: {Breed}{Environment.NewLine}" +
                $"  Is Trained: {IsTrained}{Environment.NewLine}" +
                $"  Loyalty Level: {LoyaltyLevel}{Environment.NewLine}";
        }
    }
}
