using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Turtle reptile
    internal class Turtle : Reptile
    {
        // Backing field for shell width
        private int width;

        // Shell width (0–3)
        public int ShellWidth
        {
            get => width;
            set => width = value < 0 ? 0 : (value > 3 ? 3 : value);
        }

        // Indicates whether the turtle is aquatic
        public bool IsAquatic { get; set; }

        // Sets sleep time for turtle
        public override void SetSleepTime()
        {
            sleepTime = 12;
        }

        // Returns average lifespan for turtle
        public override int GetAverageLifeSpan()
        {
            return 50;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Turtle  " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "Turtle pellets");
            food.Add("Afternoon", "Leafy greens");
            food.Add("Supplement", "Calcium block");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("08:00 - UV light on");
            events.Enqueue("10:00 - Basking time");
            events.Enqueue("12:00 - Feeding");
            events.Enqueue("15:00 - Water filter check");
            events.Enqueue("18:00 - Vegetable feeding");
            events.Enqueue("20:00 - UV light off");
            return events;
        }

        // Returns full string including turtle-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nTurtle Info:\r\n" +
                $"  Shell Width: {ShellWidth}{Environment.NewLine}" +
                $"  Is Aquatic: {IsAquatic}{Environment.NewLine}";
        }
    }
}