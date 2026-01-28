using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class MathWork
    {

        // private int num1;
       // private int num2;
        public MathWork() {
            Console.WriteLine("***   Welcome to MathWork    *****");
           
        }


        private void printTalbe()
        {
            /** another way
             * int[,] table ={
                {1,2,3,4,5,6,7,8,9,10,11,12},
                {2,4,6,8,10,12,14,16,18,20,22,24},
                {3,6,9,12,15,18,21,25,28,31,34,37},
                {4,8,12,16,20,24,28,32,36,40,44,48},
                {5,10,15,20,25,30,35,40,45,50,55,60},
                {6,12,18,24,30,36,42,48,54,60,66,72},
                {7,14,21,28,35,42,49,56,63,70,77,84},
                {8,16,24,32,40,48,56,64,72,80,88,96},
                {9,18,27,36,45,54,63,72,81,90,99,108},
                {10,20,30,40,50,60,70,80,90,100,110,120},
                {11,22,33,44,55,66,77,88,99,110,121,132},
                {12,24,36,48,60,72, 84,96,108,120,132,144},
            };**/ 


            var table = new int[13, 13];
             Console.WriteLine("******  Multiplication Table   ******");

            for (int i = 1; i < table.GetLength(0); i++)
            {

                for (int j = 1; j < table.GetLength(1); j++)
                {

                    table[i,j] = i * j;

                    Console.Write(table[i, j].ToString() + " ");
                }
                Console.WriteLine();
            }
        }
       
        private void printSum(int num1,int num2)
        {
            int sum=num1+num2;
            Console.WriteLine("Thw sum number between " + num1 + " and " + num2 + " is: " + sum);
        }
        private void printOdd(int num1, int num2) {
            
            Console.WriteLine("Odd numbers between " + num1 + " and " + num2 + " is: ");
           for(int i = num1; i <= num2; i++)
            {
                if (i % 2 != 0)
                {
                      Console.Write( i+" ");
                }
               
            }
            Console.WriteLine();

        }


        private void printEven(int num1, int num2) {

            Console.WriteLine("Even numbers between " + num1 + " and " + num2 + " is: ");
            for (int i = num1; i <= num2; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }

            }
            Console.WriteLine() ;
        }

       private void printSquareRoots(int num1,int num2)
        {
            

             Console.WriteLine(" -----  Square Roots  ----- ");
            for(int j=num1;j<=num2;j++)
            {

                for (int i = j; i <= num2; i++)
                {
                     Console.Write(" ( "+ String.Format("{0:0.##}",Math.Sqrt(i))+" ) ");
                }
                
             Console.WriteLine();      
            }
        }

        private void calculate()
        {
            do
            {
                Console.WriteLine(" Sum numbers between any two numbers \n" +
                   "Give num1 number: ");


                string strNum1 = Console.ReadLine();
                if (strNum1 == null || strNum1.Length <= 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                int num1 = int.Parse(strNum1);

                Console.WriteLine("Give num2 number: ");
                string strNum2 = Console.ReadLine();
                if (strNum2 == null || strNum2.Length <= 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
                int num2 = int.Parse(strNum2);


                printSum(num1, num2);
                printOdd(num1, num2);
                printEven(num1, num2);
                printSquareRoots(num1, num2);

                break;
            }while(true);
        }

        public void start()
        {
            bool repeat;
           
           
            do
            {
               
                printTalbe();
                calculate(); 

                repeat = exitCalculation();
            } while (repeat);
        }

        private bool exitCalculation()
        {

            Console.WriteLine("Exit Math Work? (y/n): ");
            string repeat = Console.ReadLine();

            return repeat.Equals("n") || repeat.Equals("N") || repeat.Equals("no") || repeat.Equals("NO") ? true : false;
        }
    }
}
