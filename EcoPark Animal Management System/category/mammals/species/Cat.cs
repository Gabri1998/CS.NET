using EcoPark_Animal_Management_System.category.mammal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    internal class Cat : Mammal
    {

        public string FurColor { get; set; }
        public bool IsIndoor { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nCat Info:\r\n" +
                $"  Fur Color: {FurColor}{Environment.NewLine}" +
                $"  Is Indoor: {IsIndoor}{Environment.NewLine}";
        }


    }
}
