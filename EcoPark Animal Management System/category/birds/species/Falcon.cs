using System;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Falcon bird
    internal class Falcon : Bird
    {
        // Flying speed of the falcon
        public float FlyingSpeed { get; set; }

        // Backing field for hunting accuracy
        private int accuracy;

        // Hunting accuracy (0–10)
        public int HuntingAccuracy
        {
            get => accuracy;
            set => accuracy = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Returns full string representation including falcon-specific data
        public override string ToString()
        {
            return base.ToString() +
                "\r\nFalcon Info:\r\n" +
                $"  Flying Speed: {FlyingSpeed}{Environment.NewLine}" +
                $"  Hunting Accuracy: {HuntingAccuracy}{Environment.NewLine}";
        }
    }
}
