using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    internal class Snake : Reptile
    {

        public bool IsVenomous { get; set; }
        private double range;
        public double BiteRange { get => range; set => range = value < 0 ? 0 : (value > 10 ? 10 : value); }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nSnake Info:\r\n" +
                $"  Is Venomous: {IsVenomous}{Environment.NewLine}" +
                $"  Bite Range: {BiteRange}{Environment.NewLine}";
        }


    }
}
