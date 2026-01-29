using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assinment1_Part2
{
    internal class Item
    {
        private String name;
        private String model;
        private int amount;
        private double price;
        private double total;
        public Item()
        {
            Console.WriteLine("Welcome to my home!");
        }

        public void start()
        {
            readName();
            readModel();
            readAmount();
            readPrice();
            printMessage();

        }
        private void readName()
        {
            Console.WriteLine("What is the name of your favorit Item?.");
            do
            {
                this.name = Console.ReadLine();
                if (name == null || name.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letters.");
                }
            } while (name.Equals(null) || name.Length <= 1);
        }

        private void readModel()
        {
            Console.WriteLine("What model is your "+ this.name+" ?");
            do
            {
                this.model = Console.ReadLine();
                if (name == null || name.Length <= 1)
                {
                    Console.WriteLine("Model can't be empty or one letters.");
                }
            } while (name.Equals(null) || name.Length <= 1);
        }


        private void readAmount()
        {
            do
            {
                Console.WriteLine("How many " + this.name + " you have ?");
                string strAmount = Console.ReadLine();
                this.amount = int.Parse(strAmount); //converting from "9" to 9

                if (this.amount <= 0)
                { Console.WriteLine("Amount must be greater than Zero."); }

            } while (this.amount <= 0);
        }

        private void readPrice()
        {
            do
            {
                Console.WriteLine("What is the price per unit for " + this.name + " ?");
                string strPrice = Console.ReadLine();
                this.price = double.Parse(strPrice); //converting from "9" to 9

                if (this.price <= 0)
                { Console.WriteLine("Price must be greater than Zero."); }

            } while (this.price <= 0);
        }
        public double getTotal() 
        {
            this.total = getAmount() * getPrice();
           
            return this.total;
        }
        private void printMessage()
        {
            Console.WriteLine("\n** Your favorite Item " + getName() + " model " + getModel() + " **\n " +
                "**  the total cost of " + getAmount() + " such an item is " + getTotal() + " ** \n");
        }

        public String getName(){ return this.name;}
        private String getModel(){ return this.model;}    
        public double getPrice(){ return this.price;}
        public int getAmount(){ return this.amount;}

    }
}