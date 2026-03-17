using EcoPark_Animal_Management_System.category.birds.species;
using EcoPark_Animal_Management_System.category.mammal.species;
using EcoPark_Animal_Management_System.category.reptiles.species;
using EcoPark_Animal_Management_System.enums;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace EcoPark_Animal_Management_System.animal_gen
{

    [JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
    [JsonDerivedType(typeof(Dog), "dog")]
    [JsonDerivedType(typeof(Cat), "cat")]
    [JsonDerivedType(typeof(Cow), "cow")]
    [JsonDerivedType(typeof(Falcon), "falcon")]
    [JsonDerivedType(typeof(Chicken), "chicken")]
    [JsonDerivedType(typeof(Raven), "raven")]
    [JsonDerivedType(typeof(Frog), "frog")]
    [JsonDerivedType(typeof(Snake), "snake")]
    [JsonDerivedType(typeof(Turtle), "turtle")]
    // Base abstract class for all animals in the system
    public  class Animal : IAnimal
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

        // Animal age cannot be negative
        public int Age
        {
            get => age;
            set => age = value < 0 ? 0 : value;
        }

        // Backing field for weight
        private double weight;

        // Animal weight must be greater than zero
        public double Weight
        {
            get => weight;
            set => weight = value <= 0 ? 0.1 : value;
        }

        // Animal gender
        public GenderType Gender { get; set; }

        // Backing field for sleep time 
        protected double sleepTime;

        // Sleep time property 
        public double SleepTime
        {
            get => sleepTime;
        }

        // Constructor just in case assigns a unique ID automatically
        public Animal()
        {
            if (string.IsNullOrEmpty(Id))
            {
                Id = "AN-" + idCounter.ToString("D3");
                idCounter++;
            }
        }

        // Used for displaying animal type in lists
        public string DisplayName => ToStringSummary();

        // Returns summary for list display 
        public virtual string ToStringSummary()
        {
            string type = GetType().Name;

            string shortName = string.IsNullOrEmpty(Name)
                ? ""
                : (Name.Length > 12 ? Name.Substring(0, 12) : Name);

            return $"{type,-10} {Id,-6} {shortName,-12} {Age,4} {Gender}";
        }

        // Sets sleep time 
        public virtual void SetSleepTime()
        {
            sleepTime = 0;
        }

        // Returns average lifespan 
        public virtual int GetAverageLifeSpan()
        {
            return 0;
        }

        // Returns daily food requirements 
        public virtual Dictionary<string, string> DailyFoodRequirement()
        {
           return new Dictionary<string, string>();
        }

        // Returns upcoming events 
        public virtual Queue<string> GetUpcomingEvents() {  return new Queue<string>(); }

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
            var food = DailyFoodRequirement() ?? new Dictionary<string, string>();
            foreach (KeyValuePair<string, string> meal in food)
            {
                result += $"  {meal.Key}: {meal.Value}{Environment.NewLine}";
            }

            result += "\r\nUpcoming Events:\r\n";
            var events = GetUpcomingEvents() ?? new Queue<string>();
            string[] eventArray = events.ToArray();
            foreach (string e in eventArray)
            {
                result += $"  • {e}{Environment.NewLine}";
            }

            return result;
        }
    }
}