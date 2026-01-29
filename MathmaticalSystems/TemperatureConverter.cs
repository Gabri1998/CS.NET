using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment2
{
    internal class TemperatureConverter
    {

        public TemperatureConverter() {
            Console.WriteLine("*** Temperature Converter   ****");
        
        }


        private void showMenue()
        {
            string strNum;
            int choice;
            bool check;
            


           

            do
            {
                Console.WriteLine("--  Main Menu ---- \n" +
                "Celsius to Fahrenheit: 1 \n" +
                "Fahrenheit to Celsius: 2 \n" +
                "Exist :0 \n");

                do
                {
                    Console.WriteLine("type your choice;");
                    strNum = Console.ReadLine();
                    check = int.TryParse(strNum, out choice);
                    if (strNum == null || strNum.Length <= 0 || check == false)
                    {
                        Console.WriteLine("Invalid input");
                        Console.WriteLine("String is a numeric representation: " + check);
                        continue;
                    }
                   
                   
                } while (strNum.Equals(null) || strNum.Length <= 0||check==false);
               

                switch (choice)
                {

                    case 0:
                        Console.WriteLine(" Your choice is Exit,Bye!");
                        break;
                    case 1:
                        Console.WriteLine(" Your choice is 1");
                        showFahrenheit();
                        break; 
                    case 2:
                        Console.WriteLine(" Your choice is 2");
                        showCelsius();
                        break;
                    default: Console.WriteLine("Invalid number \n");
                        break;
                }
                
            }while (choice!=0);


        }
        
        private void showFahrenheit() {
           Console.WriteLine("Please type the tempreture you want to convert: ");
            bool check ;
            double temp ;
            string strTemp;

            do
            {
                 strTemp = Console.ReadLine();
                check = double.TryParse(strTemp, out temp);
                if (strTemp == null || strTemp.Length <= 0 || check == false)
               {
                Console.WriteLine("Invalid input");
                    Console.WriteLine("String is a numeric representation: " + check);
                    continue;
                   
                }

                
               
            } while (strTemp == null || strTemp.Length <= 0|| check ==false);

            Console.WriteLine("The temperture in Fahrenheit is: " + convertToFahrenheit(temp)+"\n");

        }

        private double convertToFahrenheit(double Celsius) {
            double fahrenheit = ((Celsius * 9) / 5) + 32;


            return fahrenheit;
        }


        private void showCelsius() {
            Console.WriteLine("Please type the tempreture you want to convert: ");
            bool check;
            double temp;
            string strTemp;

            do
            {
                strTemp = Console.ReadLine();
                check = double.TryParse(strTemp, out temp);
                if (strTemp == null || strTemp.Length <= 0 || check == false)
                {
                    Console.WriteLine("Invalid input");
                    Console.WriteLine("String is a numeric representation: " + check);
                    continue;

                }



            } while (strTemp == null || strTemp.Length <= 0 || check == false);

            Console.WriteLine("The temperture in Celsius is: " + convertToCelsius(temp)+"\n");
        }
        private double convertToCelsius(double fahrenheit) {
            double celsius =(fahrenheit-32)*5/9 ;
        
        return celsius;
        }
        public void start()
        {
           showMenue();

        }

    }
}
