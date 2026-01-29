using EcoPark_Animal_Management_System.category.mammal;
using System;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Cow mammal
    internal class Cow : Mammal
    {
        // Backing field for milk production
        private double valume;

        // Milk production per day (0–10 liters)
        public double MilkProductionPerDay
        {
            get => valume;
            set => valume = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns full string including cow-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nCow Info:\r\n" +
                $"  Milk Production Per Day: {MilkProductionPerDay}{Environment.NewLine}";
        }
    }
}
