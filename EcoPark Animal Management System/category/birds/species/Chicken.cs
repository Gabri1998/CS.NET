using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    internal class Chicken : Bird
    {

        public bool IsDomestic { get; set; }
        private int quantity;
        public int EggsPerWeek { get => quantity; set => quantity = value < 0 ? 0 : (value > 20 ? 20 : value); }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nChicken Info:\r\n" +
                $"  Is Domestic: {IsDomestic}{Environment.NewLine}" +
                $"  Eggs Per Week: {EggsPerWeek}{Environment.NewLine}";
        }


    }
}
