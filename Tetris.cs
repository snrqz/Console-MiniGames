using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Tetris
    {
        private int speed;
        private int x;
        private int y;
        private string str;
        private ConsoleColor color;

        // The method is a building method, which gets 5 parameters
        // The method will create the object Tetris by setting these values to the attributes (values mean parameters)
        public Tetris(int speed, int x, int y, string str, ConsoleColor color)
        {
            this.speed = speed;
            this.x = x;
            this.y = y;
            this.str = str;
            this.color = color;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer speed which is the speed of the object
        public int GetSpeed()
        {
            return this.speed;
        }

        // The method doesn't get any parameters
        // The method will return the value of the position x aka integer
        public int GetX()
        {
            return this.x;
        }

        // The method doesn't get any parameters
        // The method will return the value of the position y aka integer
        public int GetY()
        {
            return this.y;
        }

        // The method doesn't get any parameters
        // The method will return the value of the string str 
        public string GetStr()
        {
            return this.str;
        }

        // The method doesn't get any parameters
        // The method will return the value of the ConsoleColor color
        public ConsoleColor GetColor()
        {
            return this.color;
        }

        // The method gets one parameter which is the integer speed
        // The method will set the attribute speed to the parameter speed
        public void SetSpeed(int speed)
        {
            this.speed = speed;
        }

        // The method gets one parameter which is the integer x [position]
        // The method will set the attribute x to the parameter x
        public void SetX(int x)
        {
            this.x = x;
        }

        // The method gets one parameter which is the integer y [position]
        // The method will set the attribute y to the parameter y
        public void SetY(int y)
        {
            this.y = y;
        }

        // The method gets one parameter which is the string str
        // The method will set the attribute str to the parameter str
        public void SetStr(string str)
        {
            this.str = str;
        }

        // The method gets one parameter which is the consolecolor color
        // The method will set the attribute color to the parameter color
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        // The method doesn't get any parameters
        // The method will move to left the particular object by changing and checking it's position if required
        public void MoveLeft()
        {
            if (this.x - speed > 0)
                this.x -= speed;
        }

        // The method doesn't get any parameters
        // The method will return true or false, false if one of the values out of the place that their are suppose be
        // True if it is valid
        public bool MoveRightBool()
        {
            for (int i = 0; i < this.str.Length; i++)
                if (this.x + speed + i > 80)
                    return false;
            return true;
        }

        // The method doesn't get any parameters
        // The method will call the method which was mentioned above (MoveLeft) by checking it's boolean condition
        // If the condition is indeed true then it'll increase the value of the x, speed
        public void MoveRight()
        {
            if (MoveRightBool())
                this.x += speed;
        }

        // The method gets one parameter which is the consolecolor color
        // The method will display it by the required consolecolor parameter which was submitted
        public void Display(ConsoleColor color)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = color;
            Console.WriteLine(this.str);
        }

        // The method doesn't get any parameters
        // The method will call the other method which is mentioned above this ones by giving it the parameter
        // Of the color itself (attribute color) so that it'll draw
        public void Draw()
        {
            Display(this.color);
        }

        // The method doesn't get any parameters
        // The method will erase and call the method which is the draw method is used by ('Display')
        // By giving it the value of the console.background color in order to make it invisible
        public void UnDraw()
        {
            Display(Console.BackgroundColor);
        }
    }
}
