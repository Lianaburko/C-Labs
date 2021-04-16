using System;
using System.Collections.Generic;

namespace myClassAnimals_lab5_
{
    class Food
    {
        List<string> arr = new List<string>();
        public Food()
        {
        }

        public string this[int index]
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

        public void AddElement(string row)
        {
            arr.Add(row);
        }

        public int Counter()
        {
            return arr.Count;
        }
    }
}
