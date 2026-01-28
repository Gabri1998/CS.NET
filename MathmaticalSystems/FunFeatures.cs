using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment2
{
    internal class FunFeatures
    {
        private String Fname;
        private String Lname;
        private String email;
        private int day;

        public FunFeatures() {
         Console.WriteLine("My name is Ahmed, I am a student of the 4th semester! \n" +
                "Let me know about yourself!");
        }
        private void readName()
        {
            
            do
            {
             Console.WriteLine("Your first name please: ");
             this.Fname = Console.ReadLine();
                if (Fname == null || Fname.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letter.");
                }
            } while (Fname.Equals(null) || Fname.Length <= 1);

            do
            {
             Console.WriteLine("Your last name please: ");
             this.Lname = Console.ReadLine();
                if (Lname == null || Lname.Length <= 1)
                {
                    Console.WriteLine("name can't be empty or one letter.");
                }
            } while (Lname.Equals(null) || Lname.Length <= 1);

            

        }
        private void readEmail()
        {
            do
            {
                Console.WriteLine("Your email please: ");
                email = Console.ReadLine();
                IsValid(email);
                if (!IsValid(email))
                {
                    Console.WriteLine("Email wrong format.");
                }


            } while (!IsValid(email));

        }

        private void readDay()
        {
            string repeat = "";
            Console.WriteLine("****  Fortune Teller **** ");
            do
            {
                Console.WriteLine("Select a number between 1 and 7: ");
                string strDay = Console.ReadLine();
               if (strDay==null || strDay.Length <= 0)
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }
               this.day = int.Parse(strDay); //converting from "9" to 9

               switch (this.day)
                {

                    case 1:
                        Console.WriteLine("The day is monday: work day");
                        break;
                    case 2:
                        Console.WriteLine("The day is tuseday: football day");
                        break;
                    case 3:
                        Console.WriteLine("The day is wednesdy: baskitball day");
                        break;
                    case 4:
                        Console.WriteLine("The day is thursday: baseball day");
                        break;
                    case 5:
                        Console.WriteLine("The day is friday: night out day");
                        break;
                    case 6:
                        Console.WriteLine("The day is saturday:family day");
                        break;
                    case 7:
                        Console.WriteLine("The day is sunday: laundry day");
                        break;
                    default:
                        Console.WriteLine("Invalid number please choose between 1 and 7");
                        continue;
                }
             Console.WriteLine("Continue with another round at Fortune Teller? (y/n): ");
                repeat = Console.ReadLine();

            } while (this.day <1||this.day>7 || repeat.Equals("y") || repeat.Equals("Y"));
        }
          

        private void stringLinth() {
         string text;
         string repeat="";

            Console.WriteLine("---  String Length --- \n" +
                "Write a text with any number of charecters and press Enter. \n" +
                "you can copy a text from a file and paste it here as well!");
       
            do
            {
             Console.WriteLine("Type the text: ");
             text = Console.ReadLine();
                if (text.Length != 0)
                {
                   
                    Console.WriteLine(text + "\n" +
                        "Number of chars = " + text.Length);
                }
                else
                {
                    Console.WriteLine("text can't be empty!");
                    continue;
                }
             Console.WriteLine("Continue with another round at String Lenght? (y/n): ");
             repeat = Console.ReadLine();

            } while (text.Length == 0|| repeat.Equals("y")|| repeat.Equals("Y"));
            
        }

        private bool IsValid(string email)
        {
            const string regex = @"^[^@\s]+@[^@\s]+\.(com|net|org|gov|se)$";

            return Regex.IsMatch(email, regex, RegexOptions.IgnoreCase) && email != null;
        }

        private void interduce() {
            readName();
            readEmail();
            Console.WriteLine("Nice to meet you " + this.Lname + ", " + this.Fname + "\n" +
                   "Your email´is " + this.email);
        }
        

        private bool runAgain()
        {
            
            Console.WriteLine("Start over with Fun Features? (y/n): ");
            string repeat = Console.ReadLine();

            return repeat.Equals("y") || repeat.Equals("Y") || repeat.Equals("yes") || repeat.Equals("YES")?true : false;
        }

        public void start()
        {
            bool repeat;
            interduce();
            do
            {
                readDay();
                stringLinth();
               repeat = runAgain();
            } while (repeat);
        }


        //--------------------- Utilities------------------------------------

       
        

        public String getFname() { return this.Fname; }
        private String getLnam() { return this.Lname; }
        public String getEmail() { return this.email; }
        public int getDay() { return this.day; }
    }
}
