using EcoPark_Animal_Management_System.enums;
using System;
using System.Collections.Generic;

namespace EcoPark_Animal_Management_System.animal_gen
{
    // Base abstract class for all animals in the system
    public abstract class Animal : IAnimal
    {
        // Static counter used to generate unique IDs
        private static int idCounter = 1;

        // Unique animal identifier
        public string Id { get; set; } // Changed to allow setting

        // Optional image path for the animal
        public string ImagePath { get; set; }

        // Animal name
        public string Name { get; set; }

        // Backing field for age
        private int age;

        // Animal age (cannot be negative)
        public int Age
        {
            get => age;
            set => age = value < 0 ? 0 : value;
        }

        // Backing field for weight
        private double weight;

        // Animal weight (must be greater than zero)
        public double Weight
        {
            get => weight;
            set => weight = value <= 0 ? 0.1 : value;
        }

        // Animal gender
        public GenderType Gender { get; set; }

        // Backing field for sleep time (Grade C)
        protected double sleepTime;

        // Sleep time property (Grade C)
        public double SleepTime
        {
            get => sleepTime;
        }

        // Constructor assigns a unique ID automatically
        protected Animal()
        {
            Id = "AN-" + idCounter.ToString("D3");
            idCounter++;
        }

        // Used for displaying animal type in lists
        public string DisplayName => GetType().Name;

        // Returns summary for list display (Grade D)
        public virtual string ToStringSummary()
        {
            string shortName = Name.Length > 12 ? Name.Substring(0, 12) : Name;
            return $"{Id,-8} {shortName,-12} {Age,6} {Weight,6:F1} {Gender}";
        }

        // Sets sleep time (Grade C)
        public virtual void SetSleepTime()
        {
            sleepTime = 0;
        }

        // Returns average lifespan (Grade C)
        public abstract int GetAverageLifeSpan();

        // Returns daily food requirements (Grade B)
        public abstract Dictionary<string, string> DailyFoodRequirement();

        // Returns upcoming events (Grade A)
        public abstract Queue<string> GetUpcomingEvents();

        // Returns formatted animal information
        public override string ToString()
        {
            string result = "";

            result += "Animal Info:\r\n";
            result += $"  ID: {Id}{Environment.NewLine}";
            result += $"  Name: {Name}{Environment.NewLine}";
            result += $"  Age: {Age}{Environment.NewLine}";
            result += $"  Weight: {Weight}{Environment.NewLine}";
            result += $"  Gender: {Gender}{Environment.NewLine}";
            result += $"  Sleep Time: {sleepTime} hours{Environment.NewLine}";
            result += $"  Avg Lifespan: {GetAverageLifeSpan()} years{Environment.NewLine}";

            result += "\r\nDaily Food Requirements:\r\n";
            Dictionary<string, string> food = DailyFoodRequirement();
            foreach (KeyValuePair<string, string> meal in food)
            {
                result += $"  {meal.Key}: {meal.Value}{Environment.NewLine}";
            }

            result += "\r\nUpcoming Events:\r\n";
            Queue<string> events = GetUpcomingEvents();
            string[] eventArray = events.ToArray();
            foreach (string e in eventArray)
            {
                result += $"  • {e}{Environment.NewLine}";
            }

            return result;
        }
    }
}