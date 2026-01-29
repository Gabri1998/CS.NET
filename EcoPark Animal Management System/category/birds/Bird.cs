using EcoPark_Animal_Management_System.animal_gen;
using System;

namespace EcoPark_Animal_Management_System.category.birds
{
    // Abstract base class for all bird animals
    abstract class Bird : Animal
    {
        // Backing field for wing span
        private double span;

        // Wing span in meters (clamped between 0 and 20)
        public double WingSpan
        {
            get => span;
            set => span = value < 0 ? 0 : (value > 20 ? 20 : value);
        }

        // Indicates whether the bird can fly
        public bool CanFly { get; set; }

        // Color of the bird's feathers
        public string FeatherColor { get; set; }

        // Returns full string representation including bird-specific data
        public override string ToString()
        {
            return base.ToString() +
                "\r\nBird Info:\r\n" +
                $"  Wing Span: {WingSpan}{Environment.NewLine}" +
                $"  Can Fly: {CanFly}{Environment.NewLine}" +
                $"  Feather Color: {FeatherColor}{Environment.NewLine}";
        }
    }
}
