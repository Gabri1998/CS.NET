using System;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Turtle reptile
    internal class Turtle : Reptile
    {
        // Backing field for shell width
        private int width;

        // Shell width (0–3)
        public int ShellWidth
        {
            get => width;
            set => width = value < 0 ? 0 : (value > 3 ? 3 : value);
        }

        // Indicates whether the turtle is aquatic
        public bool IsAquatic { get; set; }

        // Returns full string including turtle-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nTurtle Info:\r\n" +
                $"  Shell Width: {ShellWidth}{Environment.NewLine}" +
                $"  Is Aquatic: {IsAquatic}{Environment.NewLine}";
        }
    }
}
