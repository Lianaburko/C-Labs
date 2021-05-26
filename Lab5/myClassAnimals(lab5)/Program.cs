using System;

namespace myClassAnimals_lab5_
{
    class Program
    {
        static void Main(string[] args)
        {   
            Anaconda snake1 = new Anaconda();
            snake1.Name = "Kostya";
            snake1.Age = 15;
            snake1.Gender = Animal.Genders.Male;
            snake1.MovingType = Snake.WayOfMoving.Serpentine;
            snake1.Length = 2;
            Console.WriteLine(snake1.Swimming(true));

            Animal animal2 = new Snake();
            animal2.Name = "Gi";
            
            Python snake2 = new Python("Ars");
            Console.WriteLine(snake2.DefineHunger(true));
            snake2.Eating(true, 9);

            Console.Write("Snake's name is ");
            Console.WriteLine(snake1.Name);

            Animal animal1 = new Animal("Vasya");
            animal1.AmountOfExtremities = 4;
            Console.WriteLine("Amount of Vasya's extemities is ");
            Console.WriteLine(animal1.AmountOfExtremities);

            Console.WriteLine("Amount of snake's extemities is ");
            Console.WriteLine(snake1.AmountOfExtremities);
        }
    }
}
