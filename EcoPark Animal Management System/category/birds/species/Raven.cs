using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    internal class Raven : Bird
    {
        public string BeakColor{ get; set; }
        private int level;
        public int IntelligenceLevel { get => level; set => level = value < 0 ? 0 : (value > 10 ? 10 : value); }
        public override string ToString()
        {
            return base.ToString() +
                "\r\nRaven Info:\r\n" +
                $"  Beak Color: {BeakColor}{Environment.NewLine}" +
                $"  Intelligence Level: {IntelligenceLevel}{Environment.NewLine}";
        }



    }
}
