using EcoPark_Animal_Management_System.category.mammal;
using System;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Cat mammal
    internal class Cat : Mammal
    {
        // Color of the cat's fur
        public string FurColor { get; set; }

        // Indicates whether the cat lives indoors
        public bool IsIndoor { get; set; }

        // Returns full string including cat-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nCat Info:\r\n" +
                $"  Fur Color: {FurColor}{Environment.NewLine}" +
                $"  Is Indoor: {IsIndoor}{Environment.NewLine}";
        }
    }
}
