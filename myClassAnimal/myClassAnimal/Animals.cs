using System;
using System.Collections.Generic;

namespace myClassAnimal
{
    class Animals
    {
        List<Animal> arr = new List<Animal>();
        public Animals()
        {
        }

        public Animal this[int index]
        {
            set
            {
                if (index > arr.Count - 1 || index < 0)
                {
                    Console.WriteLine("Error, index is out of list");
                }
                else
                {
                    arr[index] = value;
                }
            }
            get
            {
                if (index > arr.Count - 1 || index < 0)
                {
                    Console.WriteLine("Error, index is out of list");
                    return null;
                }
                else
                {
                    return arr[index];
                }
            }
        }

        public void AddAnimal(Animal animal)
        {
            arr.Add(animal);
        }

        public int Amount()
        {
            return arr.Count;
        }
    }
}
