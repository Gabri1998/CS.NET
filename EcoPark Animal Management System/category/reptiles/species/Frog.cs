using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    internal class Frog : Reptile
    {
        private double hight;
        public double JumpHeight { get => hight; set => hight = value < 0 ? 0 : (value > 10 ? 10 : value); }
        public bool CanLiveOnLand { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nFrog Info:\r\n" +
                $"  Jump Height: {JumpHeight}{Environment.NewLine}" +
                $"  Can Live On Land: {CanLiveOnLand}{Environment.NewLine}";
        }


    }
}
