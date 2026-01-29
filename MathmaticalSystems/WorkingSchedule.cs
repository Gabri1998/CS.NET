using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class WorkingSchedule
    {

        public WorkingSchedule() {
            Console.WriteLine("*** Your Work Schedule   ****");
        }
        private void showMenue()
        {
            string strNum;
            int choice;
            bool check;





            do
            {
                Console.WriteLine("--  Main Menu ---- \n" +
                "A list of the weekends to work: 1 \n" +
                "A list of the nights to work: 2 \n" +
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


                } while (strNum.Equals(null) || strNum.Length <= 0 || check == false);


                switch (choice)
                {

                    case 0:
                        Console.WriteLine(" Your choice is Exit,Bye!");
                        break;
                    case 1:
                        Console.WriteLine(" Your choice is 1");
                      showWeekends();
                        break;
                    case 2:
                        Console.WriteLine(" Your choice is 2");
                     showNights();
                        break;
                    default:
                        Console.WriteLine("Invalid number \n");
                        break;
                }

            } while (choice != 0);


        }
        private void showWeekends() { 

            String[] array =  retrieveWeekends();
        
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString() + "\n");
            }
        }

        private String[] retrieveWeekends()
        {
            String[] weekends= { "week 3 ((Tuseday)). ", "week 5 ((Friday)). ", "week 8 ((Monday)). ", " week 10 ((Wednesday)). ", "week 12((Thursday)). " };


            return weekends;
        }


        private void showNights()
        {
            String[] array = retrieveNights();
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i].ToString() + "\n");
            }

        }
        private String[] retrieveNights()
        {
            String[] nights = { "week 2. ", "week 4. ","week 7. ","week 9. ","week 11. "};

            return nights;
        }
        public void start()
        {
           

            bool done = false;
            //more code

            if (done)
                showNights();  //(1)
            
            else
                showWeekends();  //(2)
            showMenue(); //(3)


        }

    }
}
