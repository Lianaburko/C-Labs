using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
    class Program
    {
        static void Main()
        {
            CultureInfo language = new CultureInfo("ru-Ru");
            Console.WriteLine("Choose the language:\n1-Franch\n2-Spanish\n3-Albanian");
            Console.WriteLine("4-Italian\n5-German\n6-Croatian\n7-Russian\n8-Norway\n9-Hungarian");
            Console.WriteLine("To leave programm write 0");
            bool checking = true;
            while (checking)
            {
                DateTime data = new DateTime(2020, 01, 15);
                string number = Console.ReadLine();

                Regex regex = new Regex(@"\d+"); // регвыр
                MatchCollection matches = regex.Matches(number);
                int sign = -1;
                bool exception = true;
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        if (match.Value == number)
                        {
                            sign = Convert.ToInt32(number);
                        }
                    }
                }
                else
                {
                    exception = false;
                    Console.WriteLine("Use only 1-9 numbers, to exit write 0");
                }

                switch (sign) // выбор языка
                {
                    case -1:
                        {
                            break;
                        }
                    case 0:
                        {
                            checking = false;
                            break;
                        }
                    case 1:
                        {
                            language = new CultureInfo("fr-FR");
                            break;
                        }
                    case 2:
                        {
                            language = new CultureInfo("es-ES");
                            break;
                        }
                    case 3:
                        {
                            language = new CultureInfo("sq-AL");
                            break;
                        }
                    case 4:
                        {
                            language = new CultureInfo("it-IT");
                            break;
                        }
                    case 5:
                        {
                            language = new CultureInfo("de-DE");
                            break;
                        }
                    case 6:
                        {
                            language = new CultureInfo("hr-BA");
                            break;
                        }
                    case 7:
                        {
                            language = new CultureInfo("ru-Ru");
                            break;
                        }
                    case 8:
                        {
                            language = new CultureInfo("nn-NO");
                            break;
                        }
                    case 9:
                        {
                            language = new CultureInfo("hu-HU");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Use only 1-9 numbers, to exit write 0");
                            break;
                        }
                }

                if (exception == true)
                {
                    for (int i = 0; i < 12; i++) // вывод месяцев
                    {
                        DateTime newData = data.AddDays(30);
                        Console.WriteLine(data.ToString("MMMM", language));
                        data = newData;
                    }
                }
            }
        }
    }
}
