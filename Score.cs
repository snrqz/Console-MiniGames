using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    internal class Score
    {
        private int x;
        private int y;
        private int number;
        private double score;
        private ConsoleColor color;

        // The method is a building method that will get 5 parameters
        // The method will create a new object by calling it's class (new Score) then setting all attributes to the parameters that 
        // Were inserted in the first place
        // The method won't return anything but create a new object dtype [score]
        public Score(int x, int y, int score, ConsoleColor color, int number)
        {
            this.x = x;
            this.y = y;
            this.score = score;
            this.color = color;
            this.number = number;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer x
        public int GetX()
        {
            return this.x;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer y
        public int GetY()
        {
            return this.y;
        }

        // The method doesn't get any parameters
        // The method will return the value of the double dtype score
        public double GetScore()
        {
            return this.score;
        }

        // The method doesn't get any parameters
        // The method will return the value of the ConsoleColor color
        public ConsoleColor GetColor()
        {
            return this.color;
        }

        // The method doesn't get any parameters
        // The method will return the value of the integer number
        public int GetNumber()
        {
            return this.number;
        }

        // The method gets one parameter which is the integer x
        // The method will set the value of the attribute x to the parameter
        public void SetX(int x)
        {
            this.x = x;
        }

        // The method gets one parameter which is the integer y
        // The method will set the value of the attribute y to the parameter
        public void SetY(int y)
        {
            this.y = y;
        }

        // The method gets one parameter which is the double score
        // The method will set the value of the attribute score to the parameter
        public void SetScore(double score)
        {
            this.score = score;
        }

        // The method gets one parameter which is the ConsoleColor color
        // The method will set the value of the attribute color to the parameter
        public void SetColor(ConsoleColor color)
        {
            this.color = color;
        }

        // The method gets one parameter which is the integer number
        // The method will set the value of the attribute number to the parameter
        public void SetNumber(int number)
        {
            this.number = number;
        }
        
        // The method gets one parameter which is the integer n
        // The method will increase the value of the attribute number by one
        // The method will set the value of the score by doubling it so that it'll use the whole number 
        // Devided by n * 100 (in order to show the values in the precents format)
        // So that we make it accessible to everyone
        public void PrecentsFormat(int n)
        {
            number += 1;
            score = (double)number / n * 100;
        }

        // The method gets two parameters which are the ConsoleColor color and the string str
        // The method will display if needed the specifically object (which is the score)
        public void Display(ConsoleColor color, string str)
        {
            Console.SetCursorPosition(this.x, this.y);
            Console.ForegroundColor = color;
            Console.WriteLine(score + "" + str);
        }

        // The method gets one parameter which is the string ch
        // The method will call another method by putting two parameters which are the attribute of the color and the char
        public void Draw(string ch)
        {
            Display(this.color, ch);
        }

        // The method doesn't get any parameters
        // The method will call another method by putting sorta "null" string (it is not null though)
        // It has a spacebar..
        // The method will give as another parameter the console's backgroundcolor and you can guess why
        // [in order to undraw, obviously]
        public void UnDraw()
        {
            Display(Console.BackgroundColor, " ");
        }

        // The method gets one parameter which is the integer n
        // The method will call 3 other methods which are undraw, by undrawing the score, then calling the
        // PrecentsFormat by putting the parameter n, then drawing it by making it look sort - of precents format
        public void IncreasePrecentsFormat(int n)
        {
            UnDraw();
            PrecentsFormat(n);
            Draw("%");
        }

        // The method doesn't get any parameters
        // The method will undraw the object then increase the value of the attribute score by one then drawing it
        // By giving it a dollar parameter so that it'll be as it mentioned, increasing the money.
        public void IncreaseMoneyFormat()
        {
            UnDraw();
            score += 1;
            Draw("$");
        }

        // The method doesn't get any parameters
        // The method will undraw the object then increase the value of the attribute score by one then drawing it 
        // By giving it a sort of "score" effect so that it'll appear
        public void IncreasePointsFormat()
        {
            UnDraw();
            score += 1;
            Draw("°");
        }

        // The method doesn't get any parameters
        // The method will undraw the object then decrease the value of the score by one and then draw it
        public void DecreasePointsFormat()
        {
            UnDraw();
            score -= 1;
            Draw("°");
        }

        // The method doesn't get any parameters
        // The method will increase the value of the attribute score but before that, it'll undraw and then re-draw it
        public void IncreaseOmegeFormat()
        {
            UnDraw();
            score += 1;
            Draw("Ω");
        }
    }
}
