using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    internal class BMICalculator
    {
        private string name;
        private double hight;
        private double weight;
        


        public BMICalculator() { }

        public double Metric(out bool pass) { 
           pass = false;
            double bmi=0.0;

            if (this.weight > 0 && this.hight > 0)
            {
                 bmi = this.weight / (this.hight * this.hight);
             pass = true;
            }
          
            return bmi; }

       public  double Imperial( out bool pass) {
            pass=false;
            double bmi = 0.0;
            if (this.weight > 0 && this.hight > 0)
            {
                this.hight *= 12; 
                bmi = (703.0 * this.weight) / (this.hight * this.hight);
                pass=true;

          

            }
            
            return bmi; }

        public String Category(double bmi) {

            string category="";

            if (bmi<18.5) {
                category = "UnderWeight";
               } else if (bmi>=18.5 && bmi<=25) {
                category = "NormalWeight";
            }
            else if (bmi>25 && bmi<30) {
                category = "OverWeight  (Pre-obesity)";
            }
            else if(bmi>30 && bmi< 35) {
                category = "OverWeight  (Obesity-Class 1)";
            } else if(bmi>=35 && bmi<=40) {
                category = "OverWeight  (Obesity-Class 2)";
            }else if (bmi>40) {
                category = "OverWeight  (Obesity-Class 3)";
            }

            return category; }
        public double RecomendedWeightInKg( )
        {
            double recomended = 25.0 * (this.hight*this.hight);
            return recomended;
        }

        public double RecomendedWeightInLbs()
        {
           
            double recomended = 5*25+25/5*(this.hight-60);
            return recomended;
        }

  
       


        public string getName(){ return this.name;}
        public double getWeight() { return this.weight; }
        public double getHight() { return this.hight; }

        public void setName(string name) {  this.name = name; }
        public void setWeight(double weight) {  this.weight = weight; }
        public void setHight(double hight) {  this.hight = hight; }
    }

  
   
}
