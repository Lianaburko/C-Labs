using System;
using System.Text.RegularExpressions;

namespace StringTask
{
    class Program
    {
        static bool Vowel(char letter)
        {
            if (letter == 'a' || letter == 'e' || letter == 'i' || letter == 'u' || letter == 'o' || letter == 'y')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyza";
            Console.WriteLine("Enter a row consist of [a-z] please, write exit to leave the program");
            bool checking = true;
            while (checking)
            {
                string row = Console.ReadLine();
                char[] mass = new char[row.Length];
                Regex regex = new Regex(@"[a-z]+");
                MatchCollection matches = regex.Matches(row);
                bool exception = true;
                if (matches.Count > 0)
                {
                    foreach (Match match in matches)
                    {
                        if (match.Value == row)
                        {
                            if (row.Equals("exit"))
                            {
                                checking = false;
                            }
                            else
                            {
                                for (int i = row.Length - 1; i > 0; i--)
                                {
                                    if (Vowel(row[i - 1]))
                                    {
                                        int index = alphabet.IndexOf(row[i]);
                                        mass[i] = alphabet[index + 1];
                                    }
                                    else
                                    {
                                        mass[i] = row[i];
                                    }
                                }
                                mass[0] = row[0];
                            }        
                        }
                        else
                        {
                            exception = false;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("use only a-z");
                }
                if (exception)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        Console.Write(mass[i]);
                    }
                }
                else
                {
                    Console.WriteLine("use only a-z");
                }
                Console.WriteLine();
            }
        }
    }
}

