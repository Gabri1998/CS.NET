using System;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Chicken bird
    internal class Chicken : Bird
    {
        // Indicates whether the chicken is domestic
        public bool IsDomestic { get; set; }

        // Backing field for egg production
        private int quantity;

        // Number of eggs produced per week (0–20)
        public int EggsPerWeek
        {
            get => quantity;
            set => quantity = value < 0 ? 0 : (value > 20 ? 20 : value);
        }

        // Returns full string representation including chicken-specific data
        public override string ToString()
        {
            return base.ToString() +
                "\r\nChicken Info:\r\n" +
                $"  Is Domestic: {IsDomestic}{Environment.NewLine}" +
                $"  Eggs Per Week: {EggsPerWeek}{Environment.NewLine}";
        }
    }
}
