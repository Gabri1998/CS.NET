using EcoPark_Animal_Management_System.category.mammal;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    internal class Dog : Mammal
    {
        public bool IsTrained { get; set; }
        public string Breed { get; set; }
        private int level;
        public int LoyaltyLevel { get=> level; set => level = value <0?0 : (value > 10 ? 10 : value); }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nDog Info:\r\n" +
                $"  Breed: {Breed}{Environment.NewLine}" +
                $"  Is Trained: {IsTrained}{Environment.NewLine}" +
                $"  Loyalty Level: {LoyaltyLevel}{Environment.NewLine}";
        }



    }
}
