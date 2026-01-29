using EcoPark_Animal_Management_System.animal_gen;
using System;

namespace EcoPark_Animal_Management_System.category.mammal
{
    // Base class for all mammal animals
    abstract class Mammal : Animal
    {
        // Backing field for number of teeth
        private int num;

        // Number of teeth (0–100)
        public int NumberOfTeeth
        {
            get => num;
            set => num = value < 0 ? 0 : (value > 100 ? 100 : value);
        }

        // Tail length in centimeters
        public double TailLength { get; set; }

        // Indicates whether the mammal has fur
        public bool HasFur { get; set; }

        // Returns base animal info plus mammal-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nMammal Info:\r\n" +
                $"  Teeth: {NumberOfTeeth}{Environment.NewLine}" +
                $"  Tail Length: {TailLength}{Environment.NewLine}" +
                $"  Has Fur: {HasFur}{Environment.NewLine}";
        }
    }
}
