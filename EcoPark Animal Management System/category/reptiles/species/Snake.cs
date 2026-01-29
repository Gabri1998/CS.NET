using System;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Snake reptile
    internal class Snake : Reptile
    {
        // Indicates whether the snake is venomous
        public bool IsVenomous { get; set; }

        // Backing field for bite range
        private double range;

        // Bite range (0–10 meters)
        public double BiteRange
        {
            get => range;
            set => range = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns full string including snake-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nSnake Info:\r\n" +
                $"  Is Venomous: {IsVenomous}{Environment.NewLine}" +
                $"  Bite Range: {BiteRange}{Environment.NewLine}";
        }
    }
}
