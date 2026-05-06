using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Snake reptile
    internal class Snake : Reptile
    {
        // Indicates whether the snake is venomous
        public bool IsVenomous { get; set; }

        // Backing field for bite range
        private double range;

        // Bite range (0–10 meters)
        public double BiteRange
        {
            get => range;
            set => range = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Sets sleep time for snake
        public override void SetSleepTime()
        {
            sleepTime = 16;
        }

        // Returns average lifespan for snake
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Snake   " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Weekly", "1-2 mice/rats");
            food.Add("Water", "Fresh always available");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("09:00 - Basking spot check");
            events.Enqueue("13:00 - Humidity check");
            events.Enqueue("Wednesday - Feeding day");
            events.Enqueue("Friday - Tank cleaning");
            events.Enqueue("1st of month - Weight measurement");
            return events;
        }

        // Returns full string including snake-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nSnake Info:\r\n" +
                $"  Is Venomous: {IsVenomous}{Environment.NewLine}" +
                $"  Bite Range: {BiteRange}{Environment.NewLine}";
        }
    }
}