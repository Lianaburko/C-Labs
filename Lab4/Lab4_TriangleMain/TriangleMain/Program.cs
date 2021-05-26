using System;
using System.Runtime.InteropServices;

namespace TriangleMain
{
    class Program
    {
        [DllImport("TriangleLib.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern double GetPerimetr(double a, double b, double c);

        [DllImport("TriangleLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetSquareBySides(double a, double b, double c);

        [DllImport("TriangleLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double GetSquareBySideAndHeight(double a, double h);

        [DllImport("TriangleLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double RadiusOfInscribedCircle(double a, double b, double c);

        [DllImport("TriangleLib.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double RadiusOfDescribedCircle(double a, double b, double c);

        static void Main(string[] args)
        {
            Console.WriteLine("Perimetr is:");
            Console.WriteLine(GetPerimetr(3, 4, 5));

            Console.WriteLine("Square is:");
            Console.WriteLine(GetSquareBySides(3, 4, 5));

            Console.WriteLine("Radius of inscribed circle is:");
            Console.WriteLine(RadiusOfInscribedCircle(3, 4, 5));

            Console.WriteLine("Radius of described circle is:");
            Console.WriteLine(RadiusOfDescribedCircle(3, 4, 5));

            Console.WriteLine("Square of triangle with a = 40, h = 20,2:");
            Console.WriteLine(GetSquareBySideAndHeight(40, 20.2));

            Console.ReadKey();
        }
    }
}
