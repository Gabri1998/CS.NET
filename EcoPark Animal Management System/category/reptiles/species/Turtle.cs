using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    internal class Turtle : Reptile
    {
        public int ShellWidth {  get => width; set => width = value < 0 ? 0 : (value > 3 ? 3 : value); }
        private int width;

        public bool IsAquatic { get; set; }

        public override string ToString()
        {
            return base.ToString() +
                "\r\nTurtle Info:\r\n" +
                $"  Shell Width: {ShellWidth}{Environment.NewLine}\n" +
                $"  Is Aquatic: {IsAquatic}{Environment.NewLine}\n";
        }


    }
}
