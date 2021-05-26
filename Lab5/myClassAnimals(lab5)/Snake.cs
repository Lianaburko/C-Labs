using System;

namespace myClassAnimals_lab5_
{
    class Snake : Animal
    {
        public Snake()
        {
        }

        public Snake(string name)
            :base (name)
        {     
        }

        private int extremities;
        private int amountOfRabits;
        private int amountOfLaidEggs;
        private double length;

        public new double AmountOfExtremities
        {
            set
            {
                extremities = 0;
            }
            get
            {
                return extremities;
            }
        }

        public int AmountOfRabitsToEat
        {
            set
            {
                if (value > 0)
                {
                    amountOfRabits = value;
                }
                else
                {
                    Console.WriteLine("wrong input, amount of rabits can't be negative");
                }
            }
            get
            {
                return amountOfRabits;
            }
        }

        public int AmountOfLaidEggs
        {
            set
            {
                if (value > 0)
                {
                    amountOfLaidEggs = value;
                }
                else
                {
                    Console.WriteLine("wrong input, amount of eggs to lay can't be negative");
                }
            }
            get
            {
                return amountOfLaidEggs;
            }
        }

        public string SetGenus { set; get; }

        public string SetOfLivingPlace { set; get; }

        public double Length
        {
            set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    Console.WriteLine("wrong input, length can't be negative");
                }
            }
            get
            {
                return length;
            }
        }

        public bool Hunger { set; get; }

        public bool Venomous { set; get; } 

        public string DefineHunger(bool hunger)
        {
            if (hunger == true)
            {
                return "Snake is hungry, define the number of rabbits to eat";
            }
            else
            {    
                return "Snake isn't hungry";
            }
        }

        public void Eating(bool hunger, int amountOfRabbits)
        {
            if (hunger == true && amountOfRabbits > 0)
            {
                Console.Write("I want to eat ");
                Console.Write(amountOfRabbits);
                Console.WriteLine(" rabbits");
            }
            else
            {
                Console.WriteLine("Snake isn't hungry");
            }
        }

        public enum WayOfMoving
        {
            Consertina,
            Serpentine,
            Sidewinding,
            Caterpillar
        }

        public WayOfMoving MovingType { get; set; }
    }
}
     
