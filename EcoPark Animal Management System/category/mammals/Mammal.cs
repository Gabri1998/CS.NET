using EcoPark_Animal_Management_System.animal_gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.mammal
{
     abstract class Mammal : Animal{

        private int num;
        public int NumberOfTeeth { get => num; set => num = value < 0 ? 0 : (value > 100 ? 100 : value); }
        public double TailLength { get; set; }
        public bool HasFur { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nMammal Info:\r\n" +
                $"  Teeth: {NumberOfTeeth}{Environment.NewLine} " +
                $"  Tail Length: {TailLength}{Environment.NewLine}" +
                $"  Has Fur: {HasFur}{Environment.NewLine}";
        }




    }
}
