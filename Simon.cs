using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project
{
    internal class Simon
    {
        private ConsoleColor[] colors;
        private int x;
        private int y;
        private int size;

        // A building method that will create the object
        // The method will get 3 parameters, x [position], y [position], size [integer - size]
        // The method won't return anything but create the object
        public Simon(int x, int y, int size)
        {
            colors = new ConsoleColor[150];
            this.x = x;
            this.y = y;
            this.size = size;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer x (position)
        public int GetX()
        {
            return this.x;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer y (position)
        public int GetY()
        {
            return this.y;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer size (size)
        public int GetSize()
        {
            return this.size;
        }

        // The method doesn't get any parameters
        // The method will return the value of the array ConsoleColors in order to get the colors
        public ConsoleColor[] GetColors()
        {
            return this.colors;
        }

        // The method gets one parameter which is the value of the integer x (position)
        // The method will set the value of the attribute x to the parameter x
        public void SetX(int x)
        {
            this.x = x;
        }

        // The method gets one parameter which is the value of the integer y (position)
        // The method will set the value of the attribute y to the parameter y
        public void SetY(int y)
        {
            this.y = y;
        }
        
        // The method gets one parameter which is the value of the integer size (size)
        // The method will set the value of the attribute size to the parameter size
        public void SetSize(int size)
        {
            this.size = size;
        }

        // The method gets one parameter which is the integer x
        public void Display(int x)
        {
            int i = 0;
            while (i <= x)
            {
                Console.ForegroundColor = colors[i];
                Console.SetCursorPosition(this.x, this.y);
                for (int n = 0; n < size; n++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write("███");
                    }
                    Console.WriteLine();
                }
                Console.SetCursorPosition(0, 0);
                switch (colors[i])
                {
                    case ConsoleColor.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Red");
                        break;
                    case ConsoleColor.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Blue");
                        break;
                    case ConsoleColor.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Green");
                        break;
                    case ConsoleColor.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("Yellow");
                        break;
                }
                Console.Write(new string(' ', Console.WindowWidth)); 
                Thread.Sleep(1500);
                i++;
            }
        }

        // The method doesn't get any parameters
        // The method will print (console.writeline) the value of the colors for each ones inside the array in order to check that they are valid
        // The method additionally, isn't really used
        public void PrintValidation() // Not really using this command, only in order to check the validation of the array
        {
            for (int i = 0; i < this.colors.Length; i++)
            {
                Console.WriteLine(this.colors[i]);
            }
        }

        // The method doesn't get any parameters
        // The method will create a consolecolor array which contains 4 colors (red, green, blue and yellow)
        // The method will return the array that was made / created in the first place
        public ConsoleColor[] ColorArray()
        {
            ConsoleColor[] Array = new ConsoleColor[4];
            Array[0] = ConsoleColor.Red;
            Array[1] = ConsoleColor.Blue;
            Array[2] = ConsoleColor.Green;
            Array[3] = ConsoleColor.Yellow;
            return Array;
        }

        // The method doesn't get any parameters
        // The method will make sure that the same color won't return twice
        // The method called setit becaues we want to set the console color to now have any duplicates
        public void SetIt()
        {
            ConsoleColor PrevColor = ConsoleColor.Black;
            ConsoleColor[] PColor = ColorArray();
            Random rand = new Random();
            for (int i = 0; i < this.colors.Length; i++)
            {
                ConsoleColor currentColor = PColor[rand.Next(0, PColor.Length)];
                while (PrevColor == currentColor)
                {
                    currentColor = PColor[rand.Next(0, PColor.Length)];
                }
                this.colors[i] = currentColor;
                PrevColor = currentColor;
            }
        }

    }
}
