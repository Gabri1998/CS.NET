using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Raven bird
    internal class Raven : Bird
    {
        // Color of the raven's beak
        public string BeakColor { get; set; }

        // Backing field for intelligence level
        private int level;

        // Intelligence level (0–10)
        public int IntelligenceLevel
        {
            get => level;
            set => level = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Sets sleep time for raven
        public override void SetSleepTime()
        {
            sleepTime = 10;
        }

        // Returns average lifespan for raven
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Raven   " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "Fruits and insects");
            food.Add("Afternoon", "Nuts and seeds");
            food.Add("Evening", "Omnivorous mix");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("08:00 - Puzzle toy time");
            events.Enqueue("10:00 - Social interaction");
            events.Enqueue("12:00 - Foraging enrichment");
            events.Enqueue("15:00 - Training session");
            events.Enqueue("17:00 - Free flight");
            return events;
        }

        // Returns full string including raven-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nRaven Info:\r\n" +
                $"  Beak Color: {BeakColor}{Environment.NewLine}" +
                $"  Intelligence Level: {IntelligenceLevel}{Environment.NewLine}";
        }
    }
}