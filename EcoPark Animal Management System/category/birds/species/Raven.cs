using System;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Raven bird
    internal class Raven : Bird
    {
        // Color of the raven's beak
        public string BeakColor { get; set; }

        // Backing field for intelligence level
        private int level;

        // Intelligence level (0–10)
        public int IntelligenceLevel
        {
            get => level;
            set => level = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns full string representation including raven-specific data
        public override string ToString()
        {
            return base.ToString() +
                "\r\nRaven Info:\r\n" +
                $"  Beak Color: {BeakColor}{Environment.NewLine}" +
                $"  Intelligence Level: {IntelligenceLevel}{Environment.NewLine}";
        }
    }
}
