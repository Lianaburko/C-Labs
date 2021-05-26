using System;

namespace myClassAnimals_lab5_
{
    class Snake : Animal, IMovable, IComparable<Snake>
    {
        public Snake()
        {
        }

        public Snake(string name)
            :base (name)
        {     
        }


        public Snake(string name, double length)
        {
            Name = name;
            Length = length;
        }

        public void Move()
        {
             Console.WriteLine("I am walking");
        }

        public void SawAnotherAnimalToEat()
        {
            Speed *= 2;
            Console.WriteLine("Your speed become twice bigger, you can try to catch your prey");
        }

        public int CompareTo(Snake otherSnake)
        {
            if (length > otherSnake.length)
            {
               return -1;
            }
            else 
            {
                 if (length < otherSnake.length)
                 {
                    return 1;
                 }
                else
                {
                    return 0;
                }
            }         
        }


        //events
        public delegate void Relaxing(string message);
        public event Relaxing Notify;

        public void Relax()
        {
            Random rnd = new Random();
            int value = rnd.Next(0, 5);
            switch (value)
            {
                case 1: 
                    Console.WriteLine("Swimmimg");
                    Notify?.Invoke($"Snake swims in Amazonka 20 minutes"); // events
                    break;
                case 2: 
                    Console.WriteLine("Lying on the sun");
                    Notify?.Invoke($"Snake chill in the jungle 3 hours");  // events
                    break;
                case 3: 
                    Console.WriteLine("Climbing the tree");
                    Notify?.Invoke($"Snake climbes the highest tree in the jungle"); // events
                    break;
                default: 
                    Console.WriteLine("Sleeping");
                    Notify?.Invoke($"Snake sleeps on the grass after eating 3 rabbits"); // events
                    break;
            }
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
     
