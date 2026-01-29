using EcoPark_Animal_Management_System.animal_gen;
using System;

namespace EcoPark_Animal_Management_System.category.reptiles
{
    // Base class for all reptile animals
    abstract class Reptile : Animal
    {
        // Length of the reptile's body
        public double BodyLength { get; set; }

        // Indicates whether the reptile lives in water
        public bool LivesInWater { get; set; }

        // Backing field for aggressiveness level
        private int level;

        // Aggressiveness level (0–10)
        public int AggressivenessLevel
        {
            get => level;
            set => level = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns base animal info plus reptile-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nReptile Info:\r\n" +
                $"  Body Length: {BodyLength}{Environment.NewLine}" +
                $"  Lives In Water: {LivesInWater}{Environment.NewLine}" +
                $"  Aggressiveness Level: {AggressivenessLevel}{Environment.NewLine}";
        }
    }
}
