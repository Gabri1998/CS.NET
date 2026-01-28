using System.Runtime.CompilerServices;

namespace Assignment2
{
    internal class MainProgram
    {
      static void move() {
            string input = null;
            Console.WriteLine("press inter to stert the next part!");
            input = Console.ReadLine();
        }
       
        static void Main(string[] args)
        {
             FunFeatures fun = new FunFeatures();
               fun.start();

              move();
             
              MathWork counter = new MathWork();
             counter.start();

             move();
              TemperatureConverter converter= new TemperatureConverter();
             converter.start();

             WorkingSchedule schedule = new WorkingSchedule();
             schedule.start();
          


        }
    }
}