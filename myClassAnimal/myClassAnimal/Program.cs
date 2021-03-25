using System;

namespace myClassAnimal
{
    class Program
    {
        static void Main(string[] args)
        {
            Animals animals = new Animals();
            Animal animal1 = new Animal();
            animals.AddAnimal(animal1);

            animals[0].Name = "Vasya";
            animals[0].Species = "Cat";
            animal1.Age = 7;
            animal1.OwnerName = "Liana";
            animals[0].Weight = 5.1;
            animal1.Gender = Animal.Genders.Male;
            animal1.AmountOfExtremities = 4;
            animal1.Speed = 10;

            Food foodForVasya = new Food();
            foodForVasya.AddElement("Mice");
            foodForVasya.AddElement("Sour-Cream");
            foodForVasya.AddElement("Sosiges");
            foodForVasya.AddElement("Water");
            foodForVasya[3] = "Milk";

            Console.Write("First animal name is: ");
            Console.WriteLine(animals[0].Name);
            Console.Write("animal's owner name is: ");
            Console.WriteLine(animals[0].OwnerName);
            Console.Write("animal's species is: ");
            Console.WriteLine(animals[0].Species);
            Console.Write("animal's amount of extremities is: ");
            Console.WriteLine(animals[0].AmountOfExtremities);
            Console.Write("animal's gender is: ");
            Console.WriteLine(animals[0].Gender);
            Console.Write("animal's age is: ");
            Console.Write(animals[0].Age);
            Console.Write(" years\nanimal's weight is: ");
            Console.Write(animals[0].Weight);
            Console.Write(" kg\nanimal's speed is: ");
            Console.Write(animals[0].Speed);
            Console.WriteLine(" km/hour\nComparing mass of the animal with 5 kg: ");
            Console.WriteLine(animals[0].CompareWeight(5));
            Console.WriteLine("Favourite food of the animal is: ");
            for (int i = 0; i < foodForVasya.Counter(); i++)
            {
                Console.Write(i+1);
                Console.Write(". ");
                Console.WriteLine(foodForVasya[i]);
            }

            Animal animal2 = new Animal("Snaky", "Vadim", "snake", 10, 30, 3, 0);
            animals.AddAnimal(animal2);

            animal2.Gender = Animal.Genders.Female;
            Console.Write("\nSecond animal name is: ");
            Console.WriteLine(animals[1].Name);
            Console.Write("animal's owner name is: ");
            Console.WriteLine(animals[1].OwnerName);
            Console.Write("animal's species is: ");
            Console.WriteLine(animals[1].Species);
            Console.Write("animal's amount of extremities is: ");
            Console.WriteLine(animals[1].AmountOfExtremities);
            Console.Write("animal's gender is: ");
            Console.WriteLine(animals[1].Gender);
            Console.Write("animal's age is: ");
            Console.Write(animals[1].Age);
            Console.Write(" years\nanimal's weight is: ");
            Console.Write(animals[1].Weight);
            Console.Write(" kg\nanimal's speed is: ");
            Console.Write(animals[1].Speed);
            Console.WriteLine(" km/hour\nComparing mass of the animal with 20 kg: ");
            Console.WriteLine(animals[1].CompareWeight(20));
            Console.WriteLine("Comparing mass of the first animal and the second: ");
            Console.WriteLine(animals[0].CompareWeight(animal2));
            Console.ReadKey();
        }
    }
}
