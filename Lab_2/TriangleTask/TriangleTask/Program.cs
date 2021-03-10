using System;
using System.Text.RegularExpressions;

class Program
{
    static bool Triangle(double a, double b, double c)
    {
        bool ident = false;
        if ((a + b > c) && (a + c > b) && (c + b > a))
        {
            ident = true;
        }
        return ident;
    }

    static double SquareByThreeSides(double a, double b, double c)
    {
        double p = (a + b + c) / 2;
        double S = p * (p - a) * (p - b) * (p - c);
        S = Math.Round(Math.Sqrt(S), 2);
        return S;
    }

    static void RadiusOfInscribedCircle(double a, double b, double c, double Sq)
    {
        double rad;
        rad = Math.Round(2 * Sq / (a + b + c), 2);
        Console.WriteLine(rad);
    }

    static void RadiusOfDescribedCircle(double a, double b, double c, double Sq)
    {
        double rad;
        rad = Math.Round(a * b * c / 4 / Sq, 2);
        Console.WriteLine(rad);
    }

    static void Angles(double a, double b, double c)
    {
        double cosA = Math.Round(((Math.Pow(b, 2) + Math.Pow(c, 2) - Math.Pow(a, 2)) / (2 * b * c)), 10);
        double cosB = Math.Round(((Math.Pow(c, 2) + Math.Pow(a, 2) - Math.Pow(b, 2)) / (2 * a * c)), 10);

        double cornerA = Math.Round((Math.Acos(cosA) / 3.14 * 180), 2);
        double cornerB = Math.Round((Math.Acos(cosB) / 3.14 * 180), 2);
        double cornerC = 180 - cornerB - cornerA;

        Console.Write(cornerA);
        Console.Write(", ");
        Console.Write(cornerB);
        Console.Write(", ");
        Console.WriteLine(cornerC);
    }

    static void Perimetr(double a, double b, double c)
    {
        Console.WriteLine(a + b + c);
    }

    static void Output(double side1, double side2, double side3)
    {
        Console.Write("The sides are: ");
        Console.Write(side1);
        Console.Write(" ");
        Console.Write(side2);
        Console.Write(" ");
        Console.WriteLine(side3);
        Console.Write("The Square is S = ");
        double Sq = SquareByThreeSides(side1, side2, side3);
        Console.WriteLine(Sq);
        Console.Write("Angles are ");
        Angles(side1, side2, side3);
        Console.Write("Perimetr is P = ");
        Perimetr(side1, side2, side3);
        Console.Write("Radius of inscribed circle is r= ");
        RadiusOfInscribedCircle(side1, side2, side3, Sq);
        Console.Write("Radius of described circle is R= ");
        RadiusOfDescribedCircle(side1, side2, side3, Sq);
    }

    static double CheckingDouble(string a)
    {
        Regex regex = new Regex(@"\d+(,\d+)?");
        MatchCollection matches = regex.Matches(a);
        double b = 0;
        if (matches.Count > 0)
        {
            foreach (Match match in matches)
            {
                if (match.Value == a)
                {
                    b = Convert.ToDouble(a);
                }
            }
        }
        return b;
    }

    static void Main()
    {
        bool end = true;
        while (end)
        {
            Console.WriteLine("\nchoose the data, you want to enter:\n");
            Console.WriteLine("1 - three sides");
            Console.WriteLine("2 - 1 side, 2 angles");
            Console.WriteLine("3 - 2 sides, 1 angle between them");
            Console.WriteLine("0 - leave the programm");
            string a = Console.ReadLine();
            Regex regex = new Regex(@"\d");
            MatchCollection matches = regex.Matches(a);
            int b = 5;
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Value == a)
                    {
                        b = Convert.ToInt32(a);
                    }
                }
            }

            switch (b)
            {
                case 1:
                    {
                        Console.WriteLine("Enter 3 sides");
                        Console.WriteLine("The first is: ");
                        var sideFirst = Console.ReadLine();
                        double side1;
                        if (CheckingDouble(sideFirst) > 0)
                        {
                            side1 = CheckingDouble(sideFirst);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        Console.WriteLine("The second is: ");
                        var sideSecond = Console.ReadLine();
                        double side2;
                        if (CheckingDouble(sideSecond) > 0)
                        {
                            side2 = CheckingDouble(sideSecond);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        Console.WriteLine("The third is: ");
                        var sideThird = Console.ReadLine();
                        double side3;
                        if (CheckingDouble(sideThird) > 0)
                        {
                            side3 = CheckingDouble(sideThird);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        if (Triangle(side1, side2, side3))
                        {
                            Output(side1, side2, side3);
                        }
                        else
                        {
                            Console.WriteLine("We can't make a triangle with such sides");
                        }
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Enter 1 side, 2 angles");
                        Console.WriteLine("The side is: ");
                        var side = Console.ReadLine();
                        double side1;
                        if (CheckingDouble(side) > 0)
                        {
                            side1 = CheckingDouble(side);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }
                        Console.WriteLine("The first angle is: ");
                        var angleFirst = Console.ReadLine();
                        double angle1;
                        if (CheckingDouble(angleFirst) > 0)
                        {
                            angle1 = CheckingDouble(angleFirst);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        Console.WriteLine("The second angle is: ");
                        var angleSecond = Console.ReadLine();
                        double angle2;
                        if (CheckingDouble(angleSecond) > 0)
                        {
                            angle2 = CheckingDouble(angleSecond);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        if (angle1 + angle2 >= 180)
                        {
                            Console.WriteLine("Something wrong with your angles");
                        }
                        else
                        {
                            double angle3 = 180 - angle1 - angle2;
                            angle3 = angle3 * 3.14 / 180;
                            double koef = Math.Round(side1 / Math.Sin(angle3), 2);
                            double side2, side3;
                            angle1 = angle1 * 3.14 / 180;
                            angle2 = angle2 * 3.14 / 180;
                            side2 = koef * Math.Round(Math.Sin(angle2), 2);
                            side3 = koef * Math.Round(Math.Sin(angle1), 2);
                            Output(side1, side2, side3);
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Enter 2 sides and 1 angle between them");
                        Console.WriteLine("The first side is: ");
                        var sideFirst = Console.ReadLine();
                        double side1;
                        if (CheckingDouble(sideFirst) > 0)
                        {
                            side1 = CheckingDouble(sideFirst);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }


                        Console.WriteLine("The second side is: ");
                        var sideSecond = Console.ReadLine();
                        double side2;
                        if (CheckingDouble(sideSecond) > 0)
                        {
                            side2 = CheckingDouble(sideSecond);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        Console.WriteLine("The angle between them: ");
                        var angleFirst = Console.ReadLine();
                        double angle1;
                        if (CheckingDouble(angleFirst) > 0)
                        {
                            angle1 = CheckingDouble(angleFirst);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input, use digits");
                            break;
                        }

                        if (angle1 >= 180)
                        {
                            Console.WriteLine("You have wrong input, choose another angle");
                        }
                        else
                        {
                            double cosAngle1 = angle1 * 3.14 / 180;
                            double side3 = Math.Sqrt(Math.Pow(side1, 2) + Math.Pow(side2, 2) - 2 * side1 * side2 * Math.Cos(cosAngle1));
                            side3 = Math.Round(side3, 2);

                            Output(side1, side2, side3);
                        }

                        break;
                    }
                case 0:
                    {
                        end = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Incorrect input, choose the number 1-3 or 0 to leave");
                        break;
                    }
            }
        }
    }
}
