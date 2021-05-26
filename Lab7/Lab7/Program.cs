using System;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction fract1 = new Fraction(3, 20);
            Console.WriteLine("The first fraction:");
            Console.WriteLine(fract1.ToString());
            Console.WriteLine(fract1.ToString("D"));
            Console.WriteLine(fract1.ToString("M"));
            Console.WriteLine(fract1.ToString("I"));

            Fraction fract2 = new Fraction(100, 7);
            Console.WriteLine("\nThe second fraction:");
            Console.WriteLine(fract2.ToString());
            Console.WriteLine(fract2.ToString("D"));
            Console.WriteLine(fract2.ToString("M"));
            Console.WriteLine(fract2.ToString("I"));

            Fraction fract3;
            fract3 = fract1 + fract2;
            Console.WriteLine($"\nSum of fractions is: " + fract3.ToString("M"));
            fract3 = fract1 - fract2;
            Console.WriteLine($"Subtraction of fractions is':  " + fract3.ToString("M"));
            fract3 = fract1 * fract2;
            Console.WriteLine($"Multiplication of fractions is:  " + fract3.ToString("M"));
            fract3 = fract1 / fract2;
            Console.WriteLine($"Division of fractions is: " + fract3.ToString("M"));

            Fraction fract4;
            if (Fraction.TryParse("-3(2/15)", out fract4))
            {
                Console.WriteLine($"\nResult of parsing -3(2/15): {fract4.ToString()}");
            }

            double number = fract4;
            int intNumber = (int)fract4;
            Console.WriteLine($"Cast of fr4 to double: {number}");
            Console.WriteLine($"Cast of fr4 to int: {intNumber}");
        }
    }
}
