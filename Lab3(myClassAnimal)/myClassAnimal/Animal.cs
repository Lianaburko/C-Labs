using System;

namespace myClassAnimal
{
    class Animal
    {
        private double weight;
        private double speed;
        private int age;
        private int extremities;

        public Animal()
        {
        }

        public Animal(string name)
        {
            Name = name;
        }

        public Animal(string name, string ownerName, string spec, double weight, double speed, double age, double amountOfExtr)
        {
            Name = name;
            OwnerName = ownerName;
            Species = spec;
            Weight = weight;
            Speed = speed;
            Age = age;
            AmountOfExtremities = amountOfExtr;
        }

        public string Name { get; set; }
        public string OwnerName { get; set; }
        public string Species { get; set; }

        public double Weight
        {
            set
            {
                if (value > 0)
                {
                    weight = value;
                }
                else
                {
                    Console.WriteLine("wrong input, weight cant be negative");
                }
            }
            get
            {
                return weight;
            }
        }

        public double Speed
        {
            set
            {
                if (value > 0)
                {
                    speed = value;
                }
                else
                {
                    Console.WriteLine("wrong input, speed can't be negative");
                }
            }
            get
            {
                return speed;
            }
        }

        public double Age
        {
            set
            {
                if (value > 0)
                {
                    age = (int)value;
                }
                else
                {
                    Console.WriteLine("wrong input, age can't be negative");
                }
            }
            get
            {
                return age;
            }
        }

        public double AmountOfExtremities
        {
            set
            {
                if (value >= 0)
                {
                    extremities = (int)value;
                }
                else
                {
                    Console.WriteLine("wrong input, amount of extremities can't be negative");
                }
            }
            get
            {
                return extremities;
            }
        }

        public string CompareWeight(double weight)
        {
            if (this.weight < weight)
            {
                return "This animal has mass less than your input";
            }
            else
            {
                if (this.weight == weight)
                {
                    return "This animal has the same mass as your input";
                }
                else
                {
                    return "This animal has mass more than your input";
                }
            }
        }

        public string CompareWeight(Animal animal)
        {
            if (this.weight < animal.Weight)
            {
                return "This animal has mass less than the second animal";
            }
            else
            {
                if (this.weight == animal.Weight)
                {
                    return "This animal has the same mass as the second animal";
                }
                else
                {
                    return "This animal has mass more than the second animal";
                }
            }
        }

        public enum Genders
        {
            Female,
            Male
        }

        public Genders Gender { get; set; }
    }
}
