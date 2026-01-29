using EcoPark_Animal_Management_System.enums;
using System;

namespace EcoPark_Animal_Management_System.animal_gen
{
    public abstract class Animal
    {
        private static int idCounter = 1;

        public string Id { get; }
        public string ImagePath { get; set; }

        public string Name { get; set; }

        private int age;
        public int Age
        {
            get => age;
            set => age = value < 0 ? 0 : value;
        }

        private double weight;
        public double Weight
        {
            get => weight;
            set => weight = value <= 0 ? 0.1 : value;
        }

        public GenderType Gender { get; set; }

        protected Animal()
        {
            Id = "AN-" + idCounter.ToString("D3");
            idCounter++;
        }

        public string DisplayName => GetType().Name;

        public override string ToString()
        {
            return
                "Animal Info:\r\n" +
                $"  ID: {Id}{Environment.NewLine}" +
                $"Name: {Name}{Environment.NewLine}" +
                $"Age: {Age}{Environment.NewLine}" +
                $"Weight: {Weight}{Environment.NewLine}" +
                $"Gender: {Gender}{Environment.NewLine}";
        }

    }
}
