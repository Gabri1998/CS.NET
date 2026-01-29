using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    internal class Falcon : Bird
    {
        public float FlyingSpeed { get; set; }
        private int accuracy;
        public int HuntingAccuracy { get => accuracy; set=> accuracy= value< 0 ? 0 : (value > 10 ? 10 : value); }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nFalcon Info:\r\n" +
                $"  Flying Speed: {FlyingSpeed}{Environment.NewLine}" +
                $"  Hunting Accuracy: {HuntingAccuracy}{Environment.NewLine}";
        }


    }
}
