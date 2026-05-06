using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Dog mammal
    internal class Dog : Mammal
    {
        // Indicates whether the dog is trained
        public bool IsTrained { get; set; }

        // Dog breed
        public string Breed { get; set; }

        // Backing field for loyalty level
        private int level;

        // Loyalty level (0–10)
        public int LoyaltyLevel
        {
            get => level;
            set => level = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Sets sleep time for dog
        public override void SetSleepTime()
        {
            sleepTime = 14;
        }

        // Returns average lifespan for dog
        public override int GetAverageLifeSpan()
        {
            return 13;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Dog     " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "200g dog food");
            food.Add("Evening", "200g dog food");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("07:00 - Morning walk");
            events.Enqueue("08:00 - Breakfast");
            events.Enqueue("12:00 - Playtime");
            events.Enqueue("15:00 - Training");
            events.Enqueue("18:00 - Evening walk");
            events.Enqueue("21:00 - Last bathroom break");
            return events;
        }

        // Returns full string including dog-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nDog Info:\r\n" +
                $"  Breed: {Breed}{Environment.NewLine}" +
                $"  Is Trained: {IsTrained}{Environment.NewLine}" +
                $"  Loyalty Level: {LoyaltyLevel}{Environment.NewLine}";
        }
    }
}