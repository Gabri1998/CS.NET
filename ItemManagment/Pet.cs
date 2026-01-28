using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    internal class Pet
    {
        private String name;
        private int age;
        private Boolean isfemale;
        public Pet()
        {
            Console.WriteLine("Greetings from MyPet class!");
        }

        public void start()
        {
            readName();
            readAge();
            readGender();
            printMessage();
        }

        private void readName()
        {
            Console.WriteLine("What is the name of your pet?.");
            do
            {
                this.name = Console.ReadLine();
                if (name == null || name.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letters.");
                }
            } while (name.Equals(null) || name.Length <= 1);
        }


        private void readAge()
        {
            do
            {
                Console.WriteLine("How old is " + this.name + " ?");
                string strAge = Console.ReadLine();
                age = int.Parse(strAge); //converting from "9" to 9

                if (age <= 0)
                { Console.WriteLine("Age must be greater than Zero."); }

            } while (age <= 0);
        }

        private void readGender()
        {
            String option = "";

            do
            {
                Console.WriteLine("Is " + this.name + " a female? (y/n): ");
                option = Console.ReadLine();
                if (option.Equals("y"))
                {
                    this.isfemale = true;
                }
                if (option.Equals("n"))
                {
                    this.isfemale = false;
                }

                if (option.Length != 1 || option.Equals(null))
                {
                    Console.WriteLine("Inavled input answer must be 'y or n'");
                }
            } while (option.Equals(null) || option.Length != 1);


        }


        private void printMessage()
        {
            if (isfemale)
            {

                Console.WriteLine("\n Name: " + this.name + " age: " + this.age + "\n" +
                this.name + " is a good girl \n" +
                "Please press inter to start the next part:\n");
                String next = Console.ReadLine();
            }
            else
            {

                Console.WriteLine("\n Name: " + this.name + " age: " + this.age + "\n" +
                this.name + " is a good boy \n" +
                "Please press inter to start the next part:\n");
                String next = Console.ReadLine();
            }

        }


        public void setName(string newName)
        {
            //check if new name is not empty
            if (newName != "")
                this.name = newName;

            printMessage();
        }
        public void setAge(int newAge)
        {
            //check if new age is not 0
            if (newAge != 0)
                this.age = newAge;

            printMessage();
        }
        public String getName() { return this.name; }
        public int getage() { return this.age; }

    }

}