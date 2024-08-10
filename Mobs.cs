using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Mobs
    {
        private int x;
        private int y;
        private char c;
        private ConsoleColor color;

        // The method is building the object itself using 4 parameters : a char, two integers (x, y - for the location, [position of the individual object]) and one color of ConsoleColor Type
        // The method will create the object whenever is being called
        public Mobs(int x, int y, char c, ConsoleColor color)
        {
            this.x = x;
            this.y = y;
            this.c = c;
            this.color = color;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer x which is the position of the individual mob (x) not y though
        public int GetX()
        {
            return this.x;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer y which is position of the mob (y) not x though
        public int GetY()
        {
            return this.y;
        }

        // The method doesn't get any parameters
        // The method will return th value of the char c which is the char of the mob, the way that it is being designed
        public char GetC()
        {
            return this.c;
        }

        // The method doesn't get any parameters
        // The method will return the value of the color which is from the dtype of "ConsoleColor" aka the foreGroundColor
        public ConsoleColor GetColor()
        {
            return this.color;
        }

        // The method gets one parameter which is the integer x
        // The method will set the value of the quality of x to the x parameter (this.x = x)
        public void SetX(int x)
        {
            this.x = x;
        }

        // The method gets one parameter which is the integer y
        // The method will set the value of the quality of y to the y parameter (this.y = y)
        public void SetY(int y)
        {
            this.y = y;
        }

        // The method gets one parameter which is the char c 
        // The method will set the value of the quantity of c aka char to the char parameter (this.c = c)
        public void SetC(char c)
        {
            this.c = c;
        }

        // The method gets one parameter which is the ConsoleColor color
        // The method will set the value of the quantity of color to the color parameter (this.color = color)
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        // The method gets one parameter which is the ConsoleColor color
        // The main point of the method is to display or undisplay is using two other methods that we will see them soon
        public void Display(ConsoleColor color)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = color;
            Console.WriteLine(this.c);
        }

        // The method doesn't get any parameters
        // The method doesn't return anything but calls the method before which was mentioned in order to draw the mob
        public void Draw()
        {
            Display(this.color);
        }

        // The method doesn't get any parameters
        // The method doesn't return anything but calls the method before which was mentioned in order to undraw the mob
        public void UnDraw()
        {
            Display(ConsoleColor.Black);
        }

        // The method doesn't get any parameters
        // The method doesn't return anything but calls the method UnDraw() in order to undraw it, additionally reseting the position
        // Of the mob in order to ensure that no thing will encount it
        public void Reset()
        {
            UnDraw();
            this.x = -1;
            this.y = -1;
        }

        // The method doesn't get any parameters
        // The method doesn't return anythiing but changing the position of y in order to move up only in case it'll be greater than 0
        public void MoveUp()
        {
            if (this.y - 1 > 0)
                this.y -= 1;
            else
                this.y += 1;
        }

        // The method doesn't get any parameters
        // The method doesn't return anything but chaning the position of y in order to move down only in case it'll be lower than 25
        public void MoveDown()
        {
            if (this.y + 1 < 25)
                this.y += 1;
            else
                this.y -= 1;
        }

        // The method doesn't get any parameters
        // The method doesn't return anything but changing the position of x in order to move right only it case that it'll be lower than 80
        public void MoveRight()
        {
            if (this.x + 1 < 80)
                this.x += 1;
            else
                this.x -= 1;
        }

        // The method doesn't get any parameters
        // The method doesn't reutrn anything but changing the position of x in order to move left only in case that it'll be greater than 0`
        public void MoveLeft()
        {
            if (this.x - 1 > 0)
                this.x -= 1;
            else
                this.x += 1;
        }

        // The method gets a number, believe that it is a random number
        // The method will see if the number is smaller than 15, if so, then it'll create a new DT of Random
        // Number and then move it from the range 0 - 3 (include 3)
        // For a few cases it'll (MoveUp / MoveDown / MoveLeft / MoveRight) Very depends
        // The method gets another rand number as well which was created already before in the previous method that is connected with it
        public void Precents(int number, Random rand)
        {
            if (number > 65)
            {
                if (number > 65 && number < 95)
                {
                    switch (rand.Next(2, 4))
                    {
                        case 2: MoveLeft(); break;
                        case 3: MoveRight(); break;
                    }
                }
                else
                {
                    switch (rand.Next(0, 2))
                    {
                        case 0: MoveUp(); break;
                        case 1: MoveDown(); break;
                    }
                }
            }
        }
    }
}

