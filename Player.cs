using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Player
    {
        private int speed;
        private int x;
        private int y;
        private char c;
        private ConsoleColor color;

        // This method is a building method that is going to build the object by calling it
        // The method gets 5 parameters and it'll set the values of the qualities to the parameters that it has
        public Player(int speed, int x, int y, char c, ConsoleColor color)
        {
            this.speed = speed;
            this.x = x;
            this.y = y;
            this.c = c;
            this.color = color;
        }

        // The method doesn't get any parameters
        // The method will return the value of the speed
        public int GetSpeed()
        {
            return this.speed;
        }

        // The method doesn't get any parameters
        // The method will return the value of x (aka position)
        public int GetX()
        {
            return this.x;
        }

        // The method doesn't get any parameters
        // The method will return the value of y (aka position)
        public int GetY()
        {
            return this.y;
        }

        // The method doesn't get any parameters
        // The method will return the value of the char ch
        public char GetC()
        {
            return this.c;
        }

        // The method doesn't get any parameters
        // The method will return the value of the ConsoleColor color
        public ConsoleColor GetColor()
        {
            return this.color;
        }

        // The method gets one parameter which is the speed
        // The method will set the value of the speed to the parameter (aka - speed)
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        // The method gets one parameter which is the value of x (position)
        // The method will set the value of the x (position) to the parameter (aka - positon [x])
        public void SetX(int x)
        {
            this.x = x;
        }

        // The method gets one parameter which is the value of y (position)
        // The method will set the value of the y (position) to the parameter (aka - position [y])
        public void SetY(int y)
        {
            this.y = y;
        }

        // The method gets one parameter which is a char (c)
        // The method will set the value of the c (char) to the parameter (aka - c)
        public void SetC(char c)
        {
            this.c = c;
        }

        // The method gets one parameter which is the ConsoleColor color
        // The method will set the value of the color (ConsoleColor) to the parameter (aka - color)
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        // The method will get one parameter which is the color of the specific player
        // The method will decide if to show it by displaying / or not by getting the parameter was requested in the first place
        // The method's main point is to aid by using two main methods (Draw, Erase)
        // Additionally, the method won't return anything due to the fact that's it's data type is void
        public void Display(ConsoleColor color)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = color;
            Console.WriteLine(this.c);
        }

        // The method doesn't get any parameters
        // The method calls another method which is the previous by the way by giving the specifically method the color that was set in the first place
        public void Draw()
        {
            Display(this.color);
        }

        // The method doesn't get any parameters
        // The method calls another method which is the "display" method by setting the value of the color to console.background color in order to make 
        // It's transparency into 1 (aka - invisible) so that it'll get the effect of "Undraw / Erase" 
        // We don't use the ConsoleColor.Black because we can't assume that automatically the color of the background in the console is black, it might be changeable
        // So that we avoid ruining it
        public void Erase()
        {
            Display(Console.BackgroundColor);
        }

        // The method gets two parameters which are the position of the objects
        // The method will firstly erase the particular object then set the position of the object by the x to the x was requested and so on y
        // The method will then draw it
        // Important to mention that all these methods and a few of them above and under aren't returning anything but they are void
        // It's important to note that the method won't return anything
        public void GoTo(int x, int y)
        {
            Erase();
            this.x = x;
            this.y = y;
            Draw();
        }

        // The method doesn't get any parameters
        // The method will change / set the value of y (position) by decreasing it using the attribute speed if possible, otherwise, won't change anything
        public void MoveUp()
        {
            if (this.y - speed > 0)
                this.y -= speed;
        }

        // The method doesn't get any parameters
        // The method will change / set the value of y (position) by increasing it using the attribute speed if possible, otherwise, won't change anything
        public void MoveDown()
        {
            if (this.y + speed < 25)
                this.y += speed;
        }

        // The method doesn't get any parameters
        // The method will change / set the value of x (position) by increasing it using the attribute speed if possible, otherwise, won't change anything
        public void MoveRight()
        {
            if (this.x + speed < 80)
                this.x += speed;
        }

        // The method doesn't get any parameters
        // The method will change / set the value of x (position) by decreasing it using the attribute speed if possible, otherwise, won't change anything
        public void MoveLeft()
        {
            if (this.x - speed > 0)
                this.x -= speed;
        }

    }
}


