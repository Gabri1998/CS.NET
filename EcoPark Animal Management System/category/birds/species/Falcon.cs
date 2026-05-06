using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.birds.species
{
    // Represents a Falcon bird
    internal class Falcon : Bird
    {
        // Flying speed of the falcon
        public float FlyingSpeed { get; set; }

        // Backing field for hunting accuracy
        private int accuracy;

        // Hunting accuracy (0–10)
        public int HuntingAccuracy
        {
            get => accuracy;
            set => accuracy = value < 0 ? 0 : (value > 10 ? 10 : value);
        }

        // Sets sleep time for falcon
        public override void SetSleepTime()
        {
            sleepTime = 10;
        }

        // Returns average lifespan for falcon
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Falcon  " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "100g fresh meat");
            food.Add("Evening", "100g fresh meat");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("09:00 - Wing exercise");
            events.Enqueue("11:00 - Training session");
            events.Enqueue("13:00 - Feeding time");
            events.Enqueue("15:00 - Flight practice");
            events.Enqueue("17:00 - Rest period");
            return events;
        }

        // Returns full string including falcon-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nFalcon Info:\r\n" +
                $"  Flying Speed: {FlyingSpeed}{Environment.NewLine}" +
                $"  Hunting Accuracy: {HuntingAccuracy}{Environment.NewLine}";
        }
    }
}