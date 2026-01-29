using EcoPark_Animal_Management_System.category.mammal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    internal class Cow : Mammal
    {

        private double valume;
        public double MilkProductionPerDay { get=>valume; set=> valume  = value < 0 ? 0 : (value > 10 ? 10 : value);  }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nCow Info:\r\n" +
                $"  Milk Production Per Day: {MilkProductionPerDay}{Environment.NewLine}";
        }


    }
}
