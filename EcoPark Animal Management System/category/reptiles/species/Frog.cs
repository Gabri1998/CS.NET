using System;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Frog reptile
    internal class Frog : Reptile
    {
        // Backing field for jump height
        private double hight;

        // Jump height (0–10)
        public double JumpHeight
        {
            get => hight;
            set => hight = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Indicates whether the frog can live on land
        public bool CanLiveOnLand { get; set; }

        // Returns full string including frog-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nFrog Info:\r\n" +
                $"  Jump Height: {JumpHeight}{Environment.NewLine}" +
                $"  Can Live On Land: {CanLiveOnLand}{Environment.NewLine}";
        }
    }
}
