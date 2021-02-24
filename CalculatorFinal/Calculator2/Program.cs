using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Calkulator
{
    class Program
    {
        static int Priority(char sign) // gives priority to the sign
        {
            int numb = 0;
            if (sign == '+' || sign == '-')
            {
                numb = 1;
            }
            if (sign == '*' || sign == '/')
            {
                numb = 2;
            }
            if (sign == '^')
            {
                numb = 3;
            }

            return numb;
        }

        static void Main(string[] args)
        {
            string row;
            row = "exp";
            Console.WriteLine("1.SIGNS.You can use + - / *^( )");
            Console.WriteLine("1.1. + - / * has left-right priority");
            Console.WriteLine("1.2 ^ has right-left priority");
            Console.WriteLine("1.3 minus(-) before the digite is unar");
            Console.WriteLine("1.4 don't write just number, its calculator, it should calculate :D");
            Console.WriteLine(" ");
            Console.WriteLine("2. NUMBERS. You can use digits [0-9]");
            Console.WriteLine("2.1 If you want to write fractional number use ',' (comma-sign)");
            Console.WriteLine("2.2 You can write 0 before a number, it isn't a mistake");
            Console.WriteLine(" ");
            Console.WriteLine("3. To leave the program write Exit/exit");

            while (row!="Exit" || row !="exit")
            {
                row = Console.ReadLine();
                if(row== "Exit" || row == "exit")
                {
                    break;
                }
                Regex regex = new Regex(@"\-?(\({1,})?((\(\-){1,})?\-?[0-9]{1,}(\,?[0-9]{1,})?(\))?([\^\-\+\/\*](\()?(\(\-)?[0-9]{1,}(\,?[0-9]{1,})?(\){1,})?){1,}(\)?){1,}");
                // expression: 1.unar '-' or '(' ( 2.number with ',' or integer 3.')' 4.sign 5.number 6. ')' ) 2-6 repeated many times
                bool correctExp = false;
                MatchCollection matches = regex.Matches(row);
                if (matches.Count > 0)
                {    
                    foreach (Match match in matches)
                        if (match.Value == row)
                        {
                            correctExp = true;
                        }
                }

                if (correctExp == false)
                {
                    int varForDots = 0;
                    int varForSpaces = 0;
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i].Equals('.'))
                        {
                            varForDots++;
                        }
                        if (row[i].Equals(' '))
                        {
                            varForSpaces++;
                        }
                    }
                    if (varForSpaces > 0) // checking for spaces
                    {
                        Console.WriteLine("Don't use any spaces");
                    }
                    if (varForDots > 0) // checking for dots
                    {
                        Console.WriteLine("Use ',' instead of '.'");
                    }
                    Console.WriteLine("Try again please, you made a mistake in input");
                    continue;
                }
                else
                {
                    int balance = 0;
                    bool balanceOfBrackets = true;
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row[i].Equals('('))
                        {
                            balance++;
                        }
                        if (row[i].Equals(')'))
                        {
                            balance--;
                        }
                        if (balance < 0)
                        {
                            balanceOfBrackets = false;
                            continue;
                        }
                    }
                    if (balanceOfBrackets == false || balance > 0) // to write messange about bracks
                    {
                        Console.WriteLine("it seems you made a mistake in the brackets");
                        continue;
                    }
                    else
                    {
                        Stack<float> numbers = new Stack<float>(); 
                        Stack<char> operations = new Stack<char>();
                        string result = ""; 
                        int brackets = 0;

                        for (int i = 0; i < row.Length; i++)
                        {
                            // work with numbers
                            if (char.IsDigit(row[i]))
                            {
                                int minus;
                                if (i >= 2)
                                {
                                    if (row[i - 1].Equals('-') && row[i - 2].Equals('('))
                                    {
                                        operations.Pop();
                                        minus = -1;
                                    }
                                    else
                                    {
                                        minus = 1;
                                    }
                                }
                                else
                                {
                                    if (row[0].Equals('-') && i == 1)
                                    {
                                        operations.Pop();
                                        minus = -1;
                                    }
                                    else
                                    {
                                        minus = 1;
                                    }
                                }
                                while (char.IsDigit(row[i]) || row[i].Equals(','))
                                {
                                    string newSign = row[i].ToString();
                                    result = result + newSign;
                                    if (i == row.Length - 1)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        i++;
                                    }
                                }
                                float number = Convert.ToSingle(result); // convert number into float
                                number *= minus;
                                numbers.Push(number);
                                result = "";
                            }
                            //work with signs
                            if (row[i].Equals('+') || row[i].Equals('-') || row[i].Equals('/') || row[i].Equals('*') || row[i].Equals('^'))
                            {
                                int prior1;
                                int prior2;
                                if (operations.Count == 0 || operations.Peek() == '(')
                                {
                                    operations.Push(row[i]);
                                }
                                else
                                {
                                    char secondLastSign = operations.Peek();
                                    prior1 = Priority(secondLastSign);
                                    char lastSign = row[i];
                                    prior2 = Priority(lastSign);
                                    bool divisionForZero = false;

                                    if (prior1 < prior2 || prior1 == prior2)
                                    {
                                        operations.Push(row[i]);
                                    }

                                    if (prior2 < prior1 && numbers.Count() > 1)
                                    {
                                        float firstNumber = numbers.Peek();
                                        numbers.Pop();
                                        float secondNumber = numbers.Peek();
                                        numbers.Pop();
                                        switch (secondLastSign)
                                        {
                                            case '+':
                                                {
                                                    numbers.Push(firstNumber + secondNumber);
                                                    break;
                                                }
                                            case '-':
                                                {
                                                    numbers.Push(secondNumber - firstNumber);
                                                    break;
                                                }
                                            case '/':
                                                {
                                                    if (firstNumber == 0)
                                                    {
                                                        Console.WriteLine("Division for 0 is forbidden by Math :(");
                                                        divisionForZero = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        numbers.Push(secondNumber / firstNumber);
                                                        break;
                                                    }
                                                }
                                            case '*':
                                                {
                                                    numbers.Push(firstNumber * secondNumber);
                                                    break;
                                                }
                                            case '^':
                                                {
                                                    double firstNumber1;
                                                    firstNumber1 = Convert.ToDouble(firstNumber);
                                                    double secondNumber1;
                                                    secondNumber1 = Convert.ToDouble(secondNumber);
                                                    double Expr;
                                                    if (prior1 == prior2)
                                                    {
                                                        Expr = Math.Pow(firstNumber1, secondNumber1);
                                                    }
                                                    else
                                                    {
                                                        Expr = Math.Pow(secondNumber1, firstNumber1);
                                                    }
                                                    float Expr2 = Convert.ToSingle(Expr);
                                                    numbers.Push(Expr2);
                                                    break;
                                                }
                                        }
                                        operations.Pop();
                                        operations.Push(lastSign);
                                    }

                                    if (divisionForZero == true)
                                    {
                                        continue;
                                    }
                                }


                            }
                            //work with left bracket
                            if (row[i] == '(')
                            {
                                brackets++;
                                operations.Push('(');
                            }
                            //work with right bracket
                            if (row[i] == ')')
                            {
                                if (numbers.Count() == 1)
                                {
                                    while (brackets != 0)
                                    {
                                        if (operations.Peek() == '(')
                                        {
                                            operations.Pop();
                                        }
                                        brackets--;
                                    }
                                }
                                else
                                {
                                    while (operations.Peek() != '(')
                                    {
                                        float firstNumber = numbers.Peek();
                                        numbers.Pop();
                                        float secondNumber = numbers.Peek();
                                        numbers.Pop();
                                        bool divisionForZero = false;

                                        switch (operations.Peek())
                                        {
                                            case '+':
                                                {
                                                    numbers.Push(firstNumber + secondNumber);
                                                    break;
                                                }
                                            case '-':
                                                {
                                                    numbers.Push(secondNumber - firstNumber);
                                                    break;
                                                }
                                            case '/':
                                                {
                                                    if (firstNumber == 0)
                                                    {
                                                        Console.WriteLine("Division for 0 is forbidden by Math :(");
                                                        divisionForZero = true;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        numbers.Push(secondNumber / firstNumber);
                                                        break;
                                                    }
                                                }
                                            case '*':
                                                {
                                                    numbers.Push(firstNumber * secondNumber);
                                                    break;
                                                }
                                            case '^':
                                                {
                                                    double firstNumber1;
                                                    firstNumber1 = Convert.ToDouble(firstNumber);
                                                    double secondNumber1;
                                                    secondNumber1 = Convert.ToDouble(secondNumber);
                                                    double Expr;
                                                    if (numbers.Count() == 2)
                                                    {
                                                        Expr = Math.Pow(firstNumber1, secondNumber1);
                                                    }
                                                    else
                                                    {
                                                         Expr = Math.Pow(secondNumber1, firstNumber1);
                                                    }
                                                    float Expr2 = Convert.ToSingle(Expr);
                                                    numbers.Push(Expr2);
                                                    break;
                                                }
                                        }
                                        operations.Pop();
                                        if (divisionForZero == true)
                                        {
                                            continue;
                                        }
                                    }
                                    operations.Pop();
                                    if (operations.Count() != 0 && operations.Peek() == '-' && numbers.Count() == 1)
                                    {
                                        float numberTop = numbers.Peek();
                                        numbers.Pop();
                                        numbers.Push(numberTop * (-1));
                                        operations.Pop();
                                    }
                                }

                            }
                        }
                        //the rest of operations
                        if (numbers.Count() > 1)
                        {
                            while (operations.Count() != 0 && numbers.Count() > 1)
                            {
                                float firstNumber = numbers.Peek();
                                numbers.Pop();
                                float secondNumber = numbers.Peek();
                                numbers.Pop();
                                bool divisionForZero = false;

                                switch (operations.Peek())
                                {
                                    case '+':
                                        {
                                            numbers.Push(firstNumber + secondNumber);
                                            break;
                                        }
                                    case '-':
                                        {
                                            numbers.Push(secondNumber - firstNumber);
                                            break;
                                        }
                                    case '/':
                                        {
                                            if (firstNumber == 0)
                                            {
                                                Console.WriteLine("Division for 0 is forbidden by Math :(");
                                                divisionForZero = true;
                                                break;
                                            }
                                            else
                                            {
                                                numbers.Push(secondNumber / firstNumber);
                                                break;
                                            }
                                        }
                                    case '*':
                                        {
                                            numbers.Push(firstNumber * secondNumber);
                                            break;
                                        }
                                    case '^':
                                        {
                                            double firstNumber1;
                                            firstNumber1 = Convert.ToDouble(firstNumber);
                                            double secondNumber1;
                                            secondNumber1 = Convert.ToDouble(secondNumber);
                                            double Expr;
                                            if (numbers.Count() == 2)
                                            {
                                                Expr = Math.Pow(firstNumber1, secondNumber1);
                                            }
                                            else
                                            {
                                                Expr = Math.Pow(secondNumber1, firstNumber1);
                                            }
                                            float Expr2 = Convert.ToSingle(Expr);
                                            numbers.Push(Expr2);
                                            break;
                                        }
                                }
                                operations.Pop();
                                if (divisionForZero == true)
                                {
                                    continue;
                                }
                            }

                            if (operations.Count() != 0 && operations.Peek() == '-' && numbers.Count() == 1)
                            {
                                float numberTop = numbers.Peek();
                                numbers.Pop();
                                numbers.Push(numberTop * (-1));
                                operations.Pop();
                            }
                        }
                        //1 number and unar minus is left
                        if (operations.Count() != 0 && operations.Peek() == '-' && numbers.Count() == 1)
                        {
                            float numberTop = numbers.Peek();
                            numbers.Pop();
                            numbers.Push(numberTop * (-1));
                            operations.Pop();
                        }
                        //the answer;
                        Console.WriteLine(numbers.Peek());
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}




