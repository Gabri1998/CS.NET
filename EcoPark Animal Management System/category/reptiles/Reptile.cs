using EcoPark_Animal_Management_System.animal_gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.reptiles
{
    abstract class Reptile : Animal
    {
        public double BodyLength { get; set; }
        public bool LivesInWater { get; set; }
        public int AggressivenessLevel { get => level; set => level = value < 0 ? 0 : (value > 10 ? 10 : value); }
        private int level;

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
