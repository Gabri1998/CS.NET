using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.category.mammal.species
{
    // Represents a Cat mammal
    internal class Cat : Mammal
    {
        // Color of the cat's fur
        public string FurColor { get; set; }

        // Indicates whether the cat lives indoors
        public bool IsIndoor { get; set; }

        // Sets sleep time for cat
        public override void SetSleepTime()
        {
            sleepTime = 16;
        }

        // Returns average lifespan for cat
        public override int GetAverageLifeSpan()
        {
            return 15;
        }

        // Returns summary for list display
        public override string ToStringSummary()
        {
            return "Cat     " + base.ToStringSummary();
        }

        // Returns daily food requirements
        public override Dictionary<string, string> DailyFoodRequirement()
        {
            Dictionary<string, string> food = new Dictionary<string, string>();
            food.Add("Morning", "85g wet food");
            food.Add("Afternoon", "50g dry kibble");
            food.Add("Evening", "85g wet food");
            return food;
        }

        // Returns upcoming events
        public override Queue<string> GetUpcomingEvents()
        {
            Queue<string> events = new Queue<string>();
            events.Enqueue("06:00 - Morning feeding");
            events.Enqueue("10:00 - Window watching");
            events.Enqueue("14:00 - Nap time");
            events.Enqueue("18:00 - Play with laser");
            events.Enqueue("22:00 - Night zoomies");
            return events;
        }

        // Returns full string including cat-specific info
        public override string ToString()
        {
            return base.ToString() +
                "\r\nCat Info:\r\n" +
                $"  Fur Color: {FurColor}{Environment.NewLine}" +
                $"  Is Indoor: {IsIndoor}{Environment.NewLine}";
        }
    }
}