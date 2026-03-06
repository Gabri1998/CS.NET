using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Cow mammal
    internal class Cow : Mammal
    {
        // Backing field for milk production
        private double valume;

        // Milk production per day (0–10 liters)
        public double MilkProductionPerDay
        {
            get => valume;
            set => valume = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Sets sleep time for cow
        public override void SetSleepTime()
        {
            sleepTime = 4;
        }

        // Returns average lifespan for cow
        public override int GetAverageLifeSpan()
        {
            return 20;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Cow     " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "5kg hay");
            food.Add("Afternoon", "3kg grain");
            food.Add("Evening", "5kg hay");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("06:00 - Morning milking");
            events.Enqueue("08:00 - Pasture grazing");
            events.Enqueue("12:00 - Rest in shade");
            events.Enqueue("16:00 - Evening milking");
            events.Enqueue("18:00 - Second grazing");
            return events;
        }

        // Returns full string including cow-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nCow Info:\r\n" +
                $"  Milk Production Per Day: {MilkProductionPerDay}{Environment.NewLine}";
        }
    }
}