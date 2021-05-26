using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Drawing
{
    class Program
    {
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        static void DrawRectangle(Rectangle rect, Brush br, IntPtr hwnd)
        {
            using (Graphics g = Graphics.FromHdc(hwnd))
            {
                g.FillRectangle(br, rect);
            }
        }

        static void DrawCircle(Brush br, int x, int y, int height, int width, IntPtr hwnd)
        {
            using (Graphics g = Graphics.FromHdc(hwnd))
            {
                g.FillEllipse(br, x, y, width, height);
            }
        }

        static void Main(string[] args)
        {
            bool drawing = true;
            while (drawing)
            {
                Console.WriteLine("Enter what do you want to draw\n1-Rectangle,\n2-Ellipse\nTo leave enter 0");
                string choosing = Console.ReadLine();
                int choice = Convert.ToInt32(choosing);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter coordinarts in the format draw x:y:z:h");
                        break;
                    case 2:
                        Console.WriteLine("Enter the centure (x,y), the width(w) and height(h) in the format draw x:y:w:h");
                        break;
                    case 0:
                        drawing = false;
                        break;
                    default:
                        Console.WriteLine("Use only 1 or 2");
                        drawing = false;
                        break;
                }
                if (drawing == false)
                {
                    break;
                }
                string cmd = Console.ReadLine();
                int x = 0, y = 0, w = 0, h = 0;
                if (cmd.ToLower().Substring(0, 4) == "draw")
                {
                    string[] rec = cmd.Substring(5).Split(':');

                    x = Convert.ToInt32(rec[0]);
                    y = Convert.ToInt32(rec[1]);
                    w = Convert.ToInt32(rec[2]);
                    h = Convert.ToInt32(rec[3]);

                    if (x > 1920 || y > 1080 || w > 1920 - x || h > 1800 - y)
                    {
                        Console.WriteLine("Incorrect input");
                        drawing = false;
                        break;
                    }
                }

                Console.WriteLine("Choose a color\n1-Red,\n2-Yellow\n3-Black\n4-Blue\n5-Green\n6-White");
                string choosingColor = Console.ReadLine();
                int choiceColor = Convert.ToInt32(choosingColor);

                Brush br = Brushes.DarkOrange;
                switch (choiceColor)
                {
                    case 1:
                        br = Brushes.Red;
                        break;
                    case 2:
                        br = Brushes.Yellow;
                        break;
                    case 3:
                        br = Brushes.Black;
                        break;
                    case 4:
                        br = Brushes.LightSkyBlue;
                        break;
                    case 5:
                        br = Brushes.Green;
                        break;
                    case 6:
                        br = Brushes.White;
                        break;
                    default:
                        drawing = false;
                        break;
                }

                if (drawing == false)
                {
                    break;
                }

                switch (choice)
                {
                    case 1:
                        DrawRectangle(new Rectangle(x, y, w, h), br, GetDC(IntPtr.Zero));
                        break;
                    case 2:
                        DrawCircle(br, x, y, w, h, GetDC(IntPtr.Zero));
                        break;
                    default:
                        drawing = false;
                        break;
                }
            }
        }
    }
}
