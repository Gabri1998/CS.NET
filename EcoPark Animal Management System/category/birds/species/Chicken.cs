using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Chicken bird
    internal class Chicken : Bird
    {
        // Indicates whether the chicken is domestic
        public bool IsDomestic { get; set; }

        // Backing field for egg production
        private int quantity;

        // Number of eggs produced per week (0–20)
        public int EggsPerWeek
        {
            get => quantity;
            set => quantity = value < 0 ? 0 : (value > 20 ? 20 : value);
        }

        // Sets sleep time for chicken
        public override void SetSleepTime()
        {
            sleepTime = 8;
        }

        // Returns average lifespan for chicken
        public override int GetAverageLifeSpan()
        {
            return 8;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Chicken " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "100g chicken feed");
            food.Add("Free feeding", "Vegetable scraps");
            food.Add("Evening", "100g chicken feed");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("06:30 - Coop opens");
            events.Enqueue("07:00 - Morning feeding");
            events.Enqueue("10:00 - Free range time");
            events.Enqueue("14:00 - Egg collection");
            events.Enqueue("19:00 - Evening feeding");
            events.Enqueue("20:00 - Coop closes");
            return events;
        }

        // Returns full string including chicken-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nChicken Info:\r\n" +
                $"  Is Domestic: {IsDomestic}{Environment.NewLine}" +
                $"  Eggs Per Week: {EggsPerWeek}{Environment.NewLine}";
        }
    }
}