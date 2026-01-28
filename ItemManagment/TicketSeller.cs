using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1

{
    internal class TicketSeller
    {
        private string name;
        private double price = 99;
        private int numOfAdults;
        private int numOfChildren;
        private double totalToPay;
        public TicketSeller()
        {
            Console.WriteLine("Welcome to Kid's fair! \n " +
                "Children always get 76% discount!");
        }

        public void start()
        {
            readName();
            readNumOfPeaple();
            culcolateToltal();
            printReceipt();
        }

        private void readName()
        {
            Console.WriteLine("What is your name please?.");
            do
            {
                this.name = Console.ReadLine();
                if (name == null || name.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letters.");
                }
            } while (name.Equals(null) || name.Length <= 1);
        }

        private void readNumOfPeaple()
        {


            do
            {
                Console.WriteLine("Number of adults?");
                string strAdult = Console.ReadLine();
                numOfAdults = int.Parse(strAdult); //converting from "9" to 9

                if (numOfAdults <= 0)
                { Console.WriteLine("Adults should be at least none."); }

            } while (numOfAdults <= 0);


            do
            {
                Console.WriteLine("Number of children?");
                string strChild = Console.ReadLine();
                numOfChildren = int.Parse(strChild); //converting from "9" to 9

                if (numOfChildren < 0)
                { Console.WriteLine("Invaled input, can not accept negative digits."); }

            } while (numOfChildren < 0);
        }


        public double culcolateToltal()
        {
            this.totalToPay = (getNumOfAdult() * price);
            this.totalToPay += this.getNumOfChildren() * (price - (price * 0.75));
            return getTotalToPay();
        }


        private void printReceipt()
        {

            Console.WriteLine("\n ***  Your receipt  *** \n" +
               "***  Amount to pay = " + culcolateToltal() + "  ****  \n" +
               "***  Thank you " + this.name + " please come back again! *** \n " +
               "Press Enter to Exit\n");
            String exit = Console.ReadLine();
        }
        public void setName(string newName)
        {
            //check if new name is not empty
            if (newName != "")
                this.name = newName;

            printReceipt();
        }


        public String getName() { return this.name; }
        public int getNumOfAdult() { return this.numOfAdults; }
        public int getNumOfChildren() { return this.numOfAdults; }
        public double getTotalToPay() { return this.totalToPay; }
    }
}
