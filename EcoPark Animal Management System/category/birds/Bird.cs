using EcoPark_Animal_Management_System.animal_gen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.birds
{
     abstract class Bird : Animal
    {

        private double span;
        public double WingSpan { get => span; set => span = value < 0 ? 0 : (value > 20 ? 20 : value); }
        public bool CanFly { get; set; }
        public string FeatherColor { get; set; }



        public override string ToString()
        {
            return base.ToString() +
                "\r\nBird Info:\r\n" +
                $"  Wing Span: {WingSpan}{Environment.NewLine}" +
                $"  Can Fly: {CanFly}{Environment.NewLine}" +
                $"  Feather Color: {FeatherColor}{Environment.NewLine}";
        }



    }
}
