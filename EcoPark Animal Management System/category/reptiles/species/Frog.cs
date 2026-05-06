using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.reptiles.species
{
    // Represents a Frog reptile
    internal class Frog : Reptile
    {
        // Backing field for jump height
        private double hight;

        // Jump height (0–10)
        public double JumpHeight
        {
            get => hight;
            set => hight = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Indicates whether the frog can live on land
        public bool CanLiveOnLand { get; set; }

        // Sets sleep time for frog
        public override void SetSleepTime()
        {
            sleepTime = 12;
        }

        // Returns average lifespan for frog
        public override int GetAverageLifeSpan()
        {
            return 8;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Frog    " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Every 2-3 days", "6-8 live crickets");
            food.Add("Supplement", "Calcium powder");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("08:00 - Misting");
            events.Enqueue("12:00 - Temperature check");
            events.Enqueue("16:00 - Feeding time");
            events.Enqueue("20:00 - Evening misting");
            events.Enqueue("22:00 - UV light off");
            return events;
        }

        // Returns full string including frog-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nFrog Info:\r\n" +
                $"  Jump Height: {JumpHeight}{Environment.NewLine}" +
                $"  Can Live On Land: {CanLiveOnLand}{Environment.NewLine}";
        }
    }
}