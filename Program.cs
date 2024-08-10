using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using Unit4.DiceLib;

namespace Project
{
    internal class Program
    {
        // The method will not get any parameters
        // The method will return an array of ConsoleColor[] array that will be often used in the methods
        // The colors are changeable as well but I chose my most favorite among the 15 of them
        public static ConsoleColor[] ColorArrayMobs()
        {
            ConsoleColor[] array = new ConsoleColor[15];
            array[0] = ConsoleColor.Red;
            array[1] = ConsoleColor.Yellow;
            array[2] = ConsoleColor.Green;
            array[3] = ConsoleColor.Blue;
            array[4] = ConsoleColor.Green;
            array[5] = ConsoleColor.DarkCyan;
            array[6] = ConsoleColor.DarkGray;
            array[7] = ConsoleColor.DarkYellow;
            array[8] = ConsoleColor.DarkRed;
            array[9] = ConsoleColor.DarkBlue;
            array[10] = ConsoleColor.DarkGreen;
            array[11] = ConsoleColor.DarkMagenta;
            array[12] = ConsoleColor.Gray;
            array[13] = ConsoleColor.White;
            array[14] = ConsoleColor.Magenta;
            return array;
        }

        // The method will get the length of the array of the Mobs[] dtype and will return that array by the way
        // The method will also get two parameters which are maxcolor and mincolor (max color means the maximum color number that it has inside the ColorArrayMobs) and min means the opposite, minimum
        // The method will only return a Mobs[] array datatype
        public static Mobs[] Spawn(int length, int maxcolor, int mincolor)
        {
            ConsoleColor[] arr = ColorArrayMobs();
            Random rand = new Random();
            Mobs[] mob = new Mobs[length];
            for (int i = 0; i < length; i++)
            {
                mob[i] = new Mobs(rand.Next(3, 80), rand.Next(1, 20), '■', arr[rand.Next(mincolor, maxcolor)]);
                mob[i].Draw();
            }
            return mob;

        }

        // The method will return a dt of Score for many games that need this
        // The spawn will be default as usual and so the color, 0,0 so that it will be nicer to see
        // By the way, the method doesn't get any parameter as visible
        public static Score SpawnScore()
        {
            return new Score(0, 0, 0, ConsoleColor.Cyan, 0);
        }

        // The method will get only one parameter which is the length of the array
        // The method will return an array of Mobs[] dtype while drawing it and by doing this, this could be very helpful for the second game
        public static Mobs[] MovingMobs(int length)
        {
            ConsoleColor[] arr = ColorArrayMobs();
            Random rand = new Random();
            Mobs[] MovingMobs = new Mobs[length];
            for (int i = 0; i < length; i++)
            {
                MovingMobs[i] = new Mobs(rand.Next(1, 80), rand.Next(1, 25), '■', ConsoleColor.Red);
                MovingMobs[i].Draw();
            }
            return MovingMobs;
        }

        // The method will get ConsoleKeyInfo k (which is the key that was hitted)
        // The method will get as well Player datatype of the Player itself and then move it wherever the key says
        public static void KeyHit(ConsoleKeyInfo k, Player player)
        {
            switch (k.Key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    player.MoveUp();
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    player.MoveDown();
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    player.MoveLeft();
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    player.MoveRight();
                    break;
            }
        }

        // The method will check the position for each mob in the Mobs[] array for the Player p itself and change the Score for each thingy
        // These 3 parameters are changeable and due to that fact the method won't return anything but do the tasks by checking the positions
        public static void PosCheck(Player p, Mobs[] mobs, Score s)
        {
            foreach (Mobs m in mobs)
            {
                if (p.GetX() == m.GetX() && p.GetY() == m.GetY())
                {
                    m.Reset();
                    s.IncreasePrecentsFormat(mobs.Length);
                }
                else
                    if (m.GetX() != -1 && m.GetY() != -1)
                    m.Draw();
            }
        }

        // The method gets only two parameters and is being connected with many other methods (the two parameters are as mentioned before and will be mentioned later on much more times)
        // Are the maximum's color integer inside the color array and the minimum's color array
        public static void FillBG(int colormax, int colormin)
        {
            //Spawn((int)Math.Pow(10, 4) * 2, colormax, colormin); // Optional
            Random rand = new Random();
            ConsoleColor[] arr = ColorArrayMobs();
            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 80; j++)
                {
                    Mobs mob = new Mobs(j, i, '█', arr[rand.Next(colormin, colormax)]);
                    mob.Draw();
                }
            }

        }

        // The method gets three parameters, the number of the regular game itself, the max color's integer (ranges) and the minimum color's integer
        // The method won't return anything but will be connected with the other method which is named FillBG in order to fill the background for each game
        // Keep in mind that the method will also ask the player to hit a button in order to continue to the next game and show fore hint for the colors that are going to be in the game
        public static void Introduction(int gamenum, int colormax, int colormin)
        {
            FillBG(colormax, colormin);
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Clear();
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("Mini Game " + gamenum + ", Insert Any Button To Continue");
            Console.ReadKey();
            Console.Clear();
        }

        // The method gets only the game's number then making based on it an introduction for only rare games that where chosen
        // The method won't return anything but print only for the rare games - aka secret
        public static void SecretGameIntroduction(int gamenum)
        {
            FillBG(13, 13);
            Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition(40, 12);
            Console.Write("ARRRRRRR...... LUCKY ");
            Console.SetCursorPosition(35, 14);
            Console.Write("Secret Game Was Chosen, Number " + gamenum);
            Console.ReadKey();
            Console.Clear();
        }

        // The method will get an Array of Mobs[] dtype
        // The method won't return anything but call another function by creating two random integers then using it for the precents method which is by the way moving them somewhere
        public static void MoveMobs(Mobs[] mobarr)
        {
            Random precents = new Random();
            Random rand = new Random();
            for (int i = 0; i < mobarr.Length; i++)
            {
                mobarr[i].UnDraw();
                mobarr[i].Precents(precents.Next(1, 115), rand);
                mobarr[i].Draw();
            }
        }

        // The method will move up the mob whenever being called, the method gets one parameter which is the dtype of Mobs
        // The method won't return anything but move up the mob by erasing it, moving it up then drawing it back
        public static void MoveUpMob(Mobs mob)
        {
            mob.UnDraw();
            mob.MoveUp();
            mob.Draw();
            Thread.Sleep(10);
        }

        // The method will move down the mob whenever being called, the method gets one parameter which is dtype of Mobs
        // The method won't return anything but move down the mob by Erasing it, moving it down then drawing it back
        public static void MoveDownMob(Mobs mob)
        {
            mob.UnDraw();
            mob.MoveDown();
            mob.Draw();
            Thread.Sleep(50);
        }

        // The method will be checking the position for each mob in the mobs array, the method gets two parameters (Mobs[] array dtype and Player dtype)
        // The method will return a boolean if they have the same position, true if the position is different, false if not
        public static bool Game2Checker(Player player, Mobs[] mobarrmoving)
        {
            foreach (Mobs m in mobarrmoving)
            {
                if (m.GetX() == player.GetX() && m.GetY() == player.GetY())
                    return false;
            }
            return true;
        }

        // The method will get ConsoleKeyInfo k which was being hitted and a Tetris dtype of player
        // The method won't return anything but move left or right the player itself by the k key
        public static void KeyBindGame3(ConsoleKeyInfo k, Tetris player)
        {
            switch (k.Key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    player.MoveLeft();
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    player.MoveRight();
                    break;
            }
        }

        // The method will get four parameters, minimum of the color where it has to begin and maximum of the color (which is connected with a game)
        // The method will get as well the position (x and y) in order to know where it'll be spawn, if the x == 0 & y == 0 it will do as it's own default thingy and spawn it randomly, otherwise it'll be spawned in the x 
        // And in the y that was requested
        public static Mobs SpawnOneMob(int min, int max, int x, int y) // x and y mean which format it should be, 0 to make their position random, otherwise they insert other numbers
        {
            if (x == 0 && y == 0)
            {
                Random rand = new Random();
                ConsoleColor[] arrcolor = ColorArrayMobs();
                Mobs mob = new Mobs(rand.Next(4, 79), 2, '■', arrcolor[rand.Next(min, max)]);
                mob.Draw();
                return mob;
            }
            else
            {
                Random rand = new Random();
                ConsoleColor[] arrcolor = ColorArrayMobs();
                Mobs mob = new Mobs(x, y, '■', arrcolor[rand.Next(min, max)]);
                mob.Draw();
                return mob;
            }
        }

        // The method will get two parameters (Tetris dtype player and Mobs mob dtype)
        // The method will return a boolean if the position of the Tetris is located somewhere near the mob
        public static bool Game3Checker(Tetris player, Mobs mob)
        {
            for (int i = 0; i < player.GetStr().Length; i++)
                if (player.GetY() == mob.GetY() && player.GetX() + i == mob.GetX())
                    return true;
            return false;
        }

        // This method is being used for the 5th Game in order to avoid duplicates inside the array itself
        // The method doesn't get any parameters but return a datatype value int[] array which will not contain any duplicates
        public static int[] Game5Array()
        {
            int[] arr = new int[4];
            Random rand = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rand.Next(1, 10);
                for (int j = 0; j < i; j++)
                {
                    while (arr[i] == arr[j])
                    {
                        arr[i] = rand.Next(1, 10);
                        j = 0;
                    }
                }
            }
            return arr;
        }

        // This method will print an integer[] datatype array (used it in the past in order to check bugs and more
        // The method gets one parameter which is int[] array and will print it, not returning anything though
        public static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.Write(arr[i] + " ");
        }

        // The method will check if the number is valid, the number which was as an input in the 5th game where he has to input a valid code
        // Without duplicates or 0 or bigger than 9999 or less than 1k, the method will return a boolean in order to show if it's valid
        // The method gets a number as well to manipulate it and do whatever is required to
        public static bool IsValid(int number)
        {
            int pnum = number;
            if (number / 1000 > 9 || number / 1000 < 1 || number < 0)
                return false;
            int[] numarr = new int[4];
            for (int i = 0; i < numarr.Length; i++)
            {
                numarr[i] = pnum % 10;
                if (numarr[i] == 0)
                    return false;
                pnum /= 10;
            }
            for (int i = 0; i < numarr.Length; i++)
            {
                for (int j = i + 1; j < numarr.Length; j++)
                {
                    if (numarr[i] == numarr[j])
                        return false;
                }
            }
            return true;
        }

        // This method might be confused, it gets one parameter and the point of it is to translate the numbers to hebrew
        // Although it sounds very dumb and useless I'll do that in order to ensure better experience so that people don't encount uncomfortable issues with reading
        // There's an issue with hebrew text and i'll just translate it
        public static string Hebrew(int num)
        {
            // 0 <= num <= 4
            switch (num)
            {
                case 0:
                    return "אפס";
                    break;
                case 1:
                    return "אחד";
                    break;
                case 2:
                    return "שתיים";
                    break;
                case 3:
                    return "שלוש";
                    break;
                case 4:
                    return "ארבע";
                    break;
                default:
                    return "Err";
                    break;
            }
        }

        // This method will play the 5th Game with the Hebrew version, gets one parameter which is the amount of the tries
        // The method won't do anything but play the 5th game which is suppose to work
        public static void HebrewVersion(int tries)
        {
            bool GameAvailable = true;
            int[] arr = Game5Array();
            int[] numarr = new int[4];
            int pnum = 0;
            int bulls = 0;
            int strike = 0;
            int counter = 0;
            Console.WriteLine("המשחק הוא - בול פגיעה");
            Console.WriteLine("המטרה היא לפצח מספר חוקי בעל ארבע ספרות שאותו המחשב מנחש");
            Thread.Sleep(3000);
            Console.Clear();

            while (GameAvailable)
            {
                counter++;
                bulls = 0;
                strike = 0;
                Console.WriteLine("אנא הזן את הקוד");
                int num = int.Parse(Console.ReadLine());
                while (!IsValid(num))
                {
                    Console.WriteLine("הקוד שהוזן אינו חוקי, נסה שוב");
                    num = int.Parse(Console.ReadLine());
                }
                pnum = num;
                for (int i = numarr.Length - 1; i >= 0; i--)
                {
                    numarr[i] = num % 10;
                    num /= 10;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (numarr[i] == arr[i])
                        bulls++;
                }
                for (int j = 0; j < arr.Length; j++)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i != j)
                            if (numarr[i] == arr[j])
                                strike++;
                    }
                }
                Console.WriteLine("מספר הבולים :" + Hebrew(bulls));
                Console.WriteLine("מספר הפגיעות :" + Hebrew(strike));
                Console.WriteLine();
                if (counter >= tries && bulls == 4)
                {
                    Console.WriteLine("ואני חשבתי שאני מזליסט");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                else
                    if (bulls == 4)
                {
                    Console.WriteLine("לא רע, לא רע, שאפו, אתה מתחיל בחמישי");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                else
                    if (counter >= tries)
                {
                    Console.WriteLine("מצטער לבאס אבל נראה שאזלו הנסיונות");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
            }
        }

        // This method will play the 5th Game with the English version, gets one parameter which is the amount of the tries
        // The method won't do anything but play the 5th game which is suppose to work
        public static void EnglishVersion(int tries)
        {
            bool GameAvailable = true;
            int[] arr = Game5Array();
            int[] numarr = new int[4];
            int pnum = 0;
            int bulls = 0;
            int strike = 0;
            int counter = 0;
            Console.WriteLine("The game is cows and bulls");
            Console.WriteLine("The essence of the game is to crack a code according to a random selection by the computer");
            Thread.Sleep(3000);
            Console.Clear();
            while (GameAvailable)
            {
                counter++;
                bulls = 0;
                strike = 0;
                Console.WriteLine("Insert your code");
                int num = int.Parse(Console.ReadLine());
                while (!IsValid(num))
                {
                    Console.WriteLine("Your code is invalid, please re-try");
                    num = int.Parse(Console.ReadLine());
                }
                pnum = num;
                for (int i = numarr.Length - 1; i >= 0; i--)
                {
                    numarr[i] = num % 10;
                    num /= 10;
                }
                for (int i = 0; i < arr.Length; i++)
                {
                    if (numarr[i] == arr[i])
                        bulls++;
                }
                for (int j = 0; j < arr.Length; j++)
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i != j)
                            if (numarr[i] == arr[j])
                                strike++;
                    }
                }
                Console.WriteLine("Amount of bulls :" + bulls); // English format is much easier because you don't have to convert it to string, Hebrew however makes it a little bit more complex
                Console.WriteLine("Amount of cows :" + strike);
                Console.WriteLine();
                if (counter >= tries && bulls == 4)
                {
                    Console.WriteLine("Mind help me in my math exam?");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                else
                    if (bulls == 4)
                {
                    Console.WriteLine("Not bad, not bad, have you seen Lucifer ?");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                else
                    if (counter >= tries)
                {
                    Console.WriteLine("Sorry buddy, you ran out of attempts");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
            }
        }

        // This method will aid the 6th game and ask the player to insert an answer for the Simon game
        // The method gets three parameters, an array of colors in order to work with the colors inside of it, an integer of the lvl that it is inside and a dt (data - type) of score in order to change it
        public static void InsertAnswer(ConsoleColor[] colors, int lvlindex, Score score)
        {
            for (int i = 1; i <= lvlindex; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Insert the " + i + " color [r - red, y - yellow, g - green, b - blue]");
                string str = Console.ReadLine();
                switch (str)
                {
                    case "r":
                    case "R":
                        if (colors[i - 1] != ConsoleColor.Red)
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.WriteLine("Wrong !");
                            score.DecreasePointsFormat();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Correct!");
                        }
                        break;
                    case "g":
                    case "G":
                        if (colors[i - 1] != ConsoleColor.Green)
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.WriteLine("Wrong !");
                            score.DecreasePointsFormat();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Correct!");
                        }
                        break;
                    case "y":
                    case "Y":
                        if (colors[i - 1] != ConsoleColor.Yellow)
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.WriteLine("Wrong !");
                            score.DecreasePointsFormat();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Correct!");
                        }
                        break;
                    case "b":
                    case "B":
                        if (colors[i - 1] != ConsoleColor.Blue)
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine();
                            Console.WriteLine("Wrong !");
                            score.DecreasePointsFormat();
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Correct!");
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Not a valid Guess");
                        score.DecreasePointsFormat();
                        break;
                }
                if (score.GetScore() == 0 || score.GetNumber() == 0)
                    break; // Not recommended but I used that in order to avoid unecessary bugs (unwanted) I could also make a boolean but that would require more stuff
                // The fastest way to get rid of it is by just breaking it
                Console.WriteLine();
                Thread.Sleep(500);
                Console.Clear();
            }
        }

        // This method will create a string array (return the string[] dtype value)
        // The method doesn't get any parameters but will return the Scissors, Paper, Rock array in order to make the secret game work
        public static string[] SecretGame1Arr()
        {
            string[] arr = new string[3];
            arr[0] = "Scissors";
            arr[1] = "Rock";
            arr[2] = "Paper";
            return arr;
        }

        // The method will get the input of the user (string basically) from the secret game and the bot's answer as well
        // Additionally, the method will get two other parameters (4 in total) that are the score themselves in order to change their values whenever needed
        // The method will do a few things and will take care of the logic, won't return anything though
        public static void LogisticGame1Secret(string strplayer, string strbot, Score PlayerScore, Score BotScore)
        {
            switch (strplayer)
            {
                case "s":
                case "S":
                    if (strbot == "Rock")
                        BotScore.IncreasePointsFormat();
                    else
                        if (strbot == "Paper")
                        PlayerScore.IncreasePointsFormat();
                    break;
                case "p":
                case "P":
                    if (strbot == "Scissors")
                        BotScore.IncreasePointsFormat();
                    else
                        if (strbot == "Rock")
                        PlayerScore.IncreasePointsFormat();
                    break;
                case "r":
                case "R":
                    if (strbot == "Scissors")
                        PlayerScore.IncreasePointsFormat();
                    else
                        if (strbot == "Paper")
                        BotScore.IncreasePointsFormat();
                    break;
                default:
                    Console.WriteLine("You didn't insert anything, as a result nothing will happen");
                    break;
            }
        }

        // This method will convert the player's choice of the string (basically a string but built by using only one char s - scissors, r - rock, p - paper)
        // The method will get one parameter which is the player's choice of the string and will return the player's original choice, I made it shortcut so that it will aid the player instead of inputting the same things
        public static string CharTranslator(string strplayer)
        {
            switch (strplayer)
            {
                case "s":
                case "S":
                    return "Scissors";
                    break;
                case "p":
                case "P":
                    return "Paper";
                    break;
                case "r":
                case "R":
                    return "Rock";
                    break;
                default:
                    return "Invalid Input";
                    break;
            }
        }

        // The method will not get any parameters but make a big array full of words (string[] array) in English for the English version (I was thinking about making Hebrew words nevertheless, c# doesn't support Hebrew)
        // The method will return the array that was created in the first place. the array is used for a few secret games inside the collection
        public static string[] ArrayDataBase()
        {
            string[] arr = new string[25];
            arr[0] = "PoliceStation";
            arr[1] = "Fight";
            arr[2] = "London";
            arr[3] = "Israel";
            arr[4] = "Unknown";
            arr[5] = "Glue";
            arr[6] = "Condition";
            arr[7] = "Shape";
            arr[8] = "Form";
            arr[9] = "Transparency";
            arr[10] = "Cookie";
            arr[11] = "Water";
            arr[12] = "Car";
            arr[13] = "Player";
            arr[14] = "Hacker";
            arr[15] = "User";
            arr[16] = "Eight";
            arr[17] = "Point";
            arr[18] = "Zero";
            arr[19] = "Five";
            arr[20] = "Family";
            arr[21] = "Lie";
            arr[22] = "Truth";
            arr[23] = "Jewish";
            arr[24] = "Russia";
            return arr;
        }

        // The method gets two parameters, a random rand dtype in order to create a random number and a string array in order to make the length the same
        // The method will return an array that contains random numbers between 1-len(array) (Length of the array that was being inserted) in order to make the game more interesting
        public static int[] RandIntArray(Random rand, string[] array)
        {
            int randnum;
            int[] randarr = new int[array.Length];
            for (int i = 0; i < randarr.Length; i++)
            {
                randnum = rand.Next(0, randarr.Length);
                while (Array.IndexOf(randarr, randnum, 0, i) != -1) 
                                                                    // Used it to ensure that the array doesn't contian any invalid values
                {
                    randnum = rand.Next(0, randarr.Length);
                }
                randarr[i] = randnum;
            }
            return randarr;
        }

        // The method gets one parameter of Player player data base using the oop of it, it gets this parameter in order to use it in the game itself
        // The method plays the first game where the players has to eat all the mobs that are randomly spawned
        public static void Game1(Player player)
        {
            bool GameAvailable = true;
            Introduction(1, 9, 7);
            Mobs[] mobarr = Spawn(10, 9, 7);
            Score score = SpawnScore();
            score.Draw("%");
            player.Draw();
            while (GameAvailable)
            {
                player.Erase();

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                        Console.ReadKey();
                    KeyHit(k, player);
                    PosCheck(player, mobarr, score);
                }
                player.Draw();
                Thread.Sleep(25);
                if (score.GetScore() == 100)
                    GameAvailable = false;
            }
        }

        // The method gets a parameter of Player player database where it is creating a player which is being set in the main itself and using it for the game itself
        // The game is similar to the first ones (original one) but you have to be careful to not being touch with the red mobs which are going to skip the game, the method plays the second game
        public static void Game2(Player player)
        {
            bool GameAvailable = true;
            Introduction(2, 4, 2);
            Mobs[] mobarr = Spawn(7, 4, 2);
            Mobs[] mobarrmoving = MovingMobs(3);
            Score score = SpawnScore();
            score.Draw("%");
            player.Draw();
            while (GameAvailable)
            {
                MoveMobs(mobarrmoving);
                if (!Game2Checker(player, mobarrmoving))
                    GameAvailable = false;
                if (Console.KeyAvailable)
                {
                    player.Erase();
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                        Console.ReadKey();
                    KeyHit(k, player);
                    PosCheck(player, mobarr, score);
                    player.Draw();
                }
                foreach (Mobs m in mobarrmoving)
                    m.Draw();
                Thread.Sleep(25);
                if (score.GetScore() == 100)
                    GameAvailable = false;
            }
        }

        // This method gets one parameter which is the amount of the tries that the player has and it'll set it
        // The player has to be careful and catch the random mobs that spawn somewhere in the sky and go down, the method will play the third game
        public static void Game3(int amount)
        {
            amount = Math.Abs(amount);
            bool GameAvailable = true;
            Introduction(3, 15, 0);
            Tetris player = new Tetris(4, 40, 24, "________", ConsoleColor.Cyan);
            Score score = SpawnScore();
            score.Draw("°");
            player.Draw();
            Mobs mob = SpawnOneMob(0, 15, 0, 0);
            while (GameAvailable)
            {
                MoveDownMob(mob);
                if (Game3Checker(player, mob))
                {
                    score.IncreasePointsFormat();
                    mob.UnDraw();
                    mob.Reset();
                    player.Draw();
                    mob = SpawnOneMob(0, 15, 0, 0);
                }
                else
                    if (mob.GetY() >= 24)
                {
                    score.DecreasePointsFormat();
                    mob.UnDraw();
                    mob.Reset();
                    mob = SpawnOneMob(0, 15, 0, 0);
                }
                if (Console.KeyAvailable)
                {
                    player.UnDraw();
                    if (score.GetScore() >= amount)
                        GameAvailable = false;
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                        Console.ReadKey();
                    KeyBindGame3(k, player);
                    player.Draw();
                }
                Thread.Sleep(25);
            }
        }

        // The method gets one parameter of amount, amount of the mobs that it has to kill
        // Reminds "space invadors" where random mobs are spawn and you have to shoot them in order to kill, the parameter is being used only for the amount of the mobs that will die, the method will play the 4th game
        public static void Game4(int amount)
        {
            bool GameAvailable = true;
            bool CanCreateBullet = true;
            amount = Math.Abs(amount);
            Introduction(4, 10, 4);
            Tetris player = new Tetris(1, 40, 25, "■■■", ConsoleColor.Cyan);
            Score score = SpawnScore();
            Mobs[] mobarr = Spawn(amount, 10, 4);
            player.Draw();
            score.Draw("$");
            Mobs mob = null;
            while (GameAvailable)
            {
                CanCreateBullet = false;
                if (mob != null)
                {
                    if (mob.GetY() > 1 && mob.GetX() > 1)
                    {
                        MoveUpMob(mob);
                        score.Draw("$");
                        foreach (Mobs m in mobarr)
                        {
                            if (m != null && m.GetY() == mob.GetY() && m.GetX() == mob.GetX())
                            {
                                m.Reset();
                                score.IncreaseMoneyFormat();
                            }
                        }
                    }
                    else
                    {
                        mob.UnDraw();
                        CanCreateBullet = true;
                    }
                }
                else
                    CanCreateBullet = true;
                Console.SetCursorPosition(0, 0);
                if (Console.KeyAvailable)
                {
                    player.UnDraw();
                    if (score.GetScore() >= amount)
                        GameAvailable = false;
                    ConsoleKeyInfo k = Console.ReadKey();
                    KeyBindGame3(k, player);
                    if (k.Key == ConsoleKey.Spacebar && CanCreateBullet)
                    {
                        mob = SpawnOneMob(4, 10, player.GetX() + 1, player.GetY() - 1);
                        CanCreateBullet = false;
                    }
                    player.Draw();
                }
            }
        }

        // The method gets the amount of the tries that the Player has until he will win / lose depends
        // The method will play the game 5 which is "MasterMind", aka "בול פגיעה" with introduction and additional information
        // It's important to note that this is the only game which is not built using oop because it has to do nothing with it (that's just a console write guesses code - game)
        // The only normal game * not secret, some of the secret games are not being used by oop as well
        public static void Game5(int tries)
        {
            tries = Math.Abs(tries);
            Introduction(5, 3, 3);
            Console.WriteLine("The game will be different than usual");
            Console.WriteLine("Please choose your language (1 - Hebrew, Otherwise - English)");
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            if (choice == 1)
            {
                HebrewVersion(tries);
            }
            else
            {
                EnglishVersion(tries);
            }
        }

        // The method will get one parameter which is the amount of the tries he has
        // The method will play the last game, 6th which is
        // alike memory game based upon colors
        public static void Game6(int amount)
        {
            bool GameAvailable = true;
            int lvlindex = 1;
            Introduction(6, 4, 0);
            Simon simon = new Simon(0, 5, 20);
            Score score = new Score(79, 0, Math.Abs(amount), ConsoleColor.White, Math.Abs(amount));
            score.Draw("°");
            while (GameAvailable)
            {
                simon.SetIt();
                ConsoleColor[] colors = simon.GetColors();
                Console.SetCursorPosition(0, 0);
                Console.Write("Level [" + lvlindex + "]");
                Thread.Sleep(1000);
                Console.Clear();
                simon.Display(lvlindex);
                lvlindex++;
                Console.Clear();
                InsertAnswer(colors, lvlindex, score);
                Console.Clear();
                if (score.GetNumber() <= 0 || score.GetScore() <= 0)
                    GameAvailable = false;
            }

        }

        // This method won't get any parameters, it's a secret fun simple game where you can play against a bot 
        // The method won't return anything but play the first secret game which is "Rock Paper Scissors"
        // Important to note that it is not a part of the project itself but just fun game that has very small chances to happen
        // The game has 5 maximum runs, in order to win the player will have to score 5 points of the bot so
        // This method is not - used by oop due to the fact that it is a secret based - bot - player fun game with the console
        public static void SecretGame1()
        {
            Score BotScore = new Score(80, 0, 0, ConsoleColor.Red, 0);
            Score PlayerScore = new Score(80, 2, 0, ConsoleColor.Cyan, 0);
            string[] Array = SecretGame1Arr();
            SecretGameIntroduction(1);
            bool GameAvailable = true;
            BotScore.Draw(" BOT");
            PlayerScore.Draw(" PLAYER");
            Random rand = new Random();
            while (GameAvailable)
            {
                BotScore.Draw(" BOT");
                PlayerScore.Draw(" PLAYER");
                string strbot = Array[rand.Next(0, Array.Length)];
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Insert [s - Scissors] , [r - Rock] , [p - Paper]");
                string strplayer = Console.ReadLine();
                Console.WriteLine("Player Input : " + CharTranslator(strplayer));
                Console.WriteLine("Computer Input : " + strbot);
                Thread.Sleep(2500);
                LogisticGame1Secret(strplayer, strbot, PlayerScore, BotScore);
                if (BotScore.GetScore() >= 5 || BotScore.GetNumber() >= 5)
                {
                    Console.Clear();
                    GameAvailable = false;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(60, 12);
                    Console.Write("The Bot Has Won");
                    Thread.Sleep(2500);
                }
                else
                    if (PlayerScore.GetScore() >= 5 || PlayerScore.GetNumber() >= 5)
                {
                    Console.Clear();
                    GameAvailable = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(60, 12);
                    Console.Write("You Have Won");
                    Thread.Sleep(2500);
                }
                Console.Clear();
            }
        }

        // This method gets one parameter, which is the amount of the tries that the player has, it's a secret 2nd game in the collection where you are getting a random word that is being chosen by a bot 
        // The word won't be the same as it is and it might be a little messy so you have to guess it in order to obtain points
        // The method won't return anything but play the second game which is a part of the Secret Games Collection
        // This method is not - used by object oriented programming because it is a secret game based being vs yourself while guessing a game (didn't make any class for it but score will be used in many other cases as well)
        public static void SecretGame2(int amount)
        {
            bool GameAvailable = true;
            string[] array;
            int ind = 0;
            Random rand = new Random();
            int randnum;
            string ans = ""; // Empty string because it will be the input of the user later on
            string word = ""; // Empty string in order to create valueable things later on
            int[] lettersrandarr;
            SecretGameIntroduction(2);
            Score score = new Score(80, 0, 0, ConsoleColor.Cyan, 0);
            array = ArrayDataBase();
            int[] randarr = RandIntArray(rand, array);
            while (GameAvailable)
            {
                score.Draw("°");
                word = "";
                lettersrandarr = new int[array[randarr[ind]].Length];
                for (int j = 0; j < array[randarr[ind]].Length; j++) 
                {
                    randnum = rand.Next(0, array[randarr[ind]].Length); 
                    while (Array.IndexOf(lettersrandarr, randnum, 0, j) != -1)
                    {
                        randnum = rand.Next(0, array[randarr[ind]].Length); 
                    }
                    lettersrandarr[j] = randnum; 
                }
                for (int i = 0; i < array[randarr[ind]].Length; i++) 
                {
                    word += array[randarr[ind]][lettersrandarr[i]]; 
                }
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Word That Was Chosen : " + word);
                Console.WriteLine("Insert The Word That You Think It Is");
                ans = Console.ReadLine();
                if (ans.Equals(array[randarr[ind]])) 
                {
                    score.IncreasePointsFormat();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Indeed, Correct");
                }
                else
                {
                    score.DecreasePointsFormat();
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Wrong Answer, The Word Is " + array[randarr[ind]]);
                }
                ind++;
                if (amount == score.GetScore() || amount == score.GetNumber())
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 12);
                    Console.WriteLine("You Should Be Proud, You Won, Good Job");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                if (ind >= array.Length - 1)
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 12);
                    Console.WriteLine("Unfortunately, You Have Lost, However, You Should Keep Try");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }
                Thread.Sleep(1500);
                Console.Clear();
            }
        }

        // This method gets two parameters, which is the amount of the tries that the player has for each run, and the amount of runs that he has.
        // It's a secret 3nd game in the collection where you have to guess the word right by putting chars, hang - man basically but without any pictures
        // The player has to guess a few chars in order to get the word right, the method won't return anything but play the hang-man game itself
        // Once again - This method is not - used by object oriented programm5ing because it is a secret game based being vs yourself while guessing
        // (didn't make any class for it but score will be used in many other cases as well), not only in this game
        public static void SecretGame3(int amount, int runs)
        {
            SecretGameIntroduction(3);
            bool GameAvailable = true;
            Random rand = new Random();
            int ind = 0;
            bool found = false;
            string underscoreword = "";
            string word = ""; 
            Score score = new Score(80, 0, 0, ConsoleColor.Cyan, 0);
            score.Draw("Ω");
            string[] array = ArrayDataBase();
            int[] randarr = RandIntArray(rand, array);
            while (GameAvailable)
            {
                found = false;
                Console.SetCursorPosition(0, 0);
                underscoreword = ""; 
                word = array[randarr[ind]];
                string pword = word;
                for (int n = 0; n < word.Length; n++)
                    underscoreword += "_";
                Console.WriteLine(underscoreword);
                for (int x = 0; x < amount && !found; x++)
                {
                    Console.WriteLine();
                    Console.WriteLine("Insert Your Guess");
                    char ch = char.Parse(Console.ReadLine());
                    for (int i = 0; i < word.Length && !found; i++)
                    {
                        if (ch == word[i] && underscoreword.IndexOf(ch, i) == -1)
                        {
                            underscoreword = underscoreword.Substring(0, i) + ch + underscoreword.Substring(i + 1);
                            Thread.Sleep(50);
                            Console.Clear();
                            score.IncreaseOmegeFormat(); 
                            Console.SetCursorPosition(0, 0);
                            Console.WriteLine(underscoreword);
                        }
                        if (pword.Equals(underscoreword))
                        {
                            found = true;
                            Console.Clear();
                        }
                    }
                }
                if (pword.Equals(underscoreword))
                {
                    Console.Write("You Got The Word Right");
                }

                else if (!(pword.Equals(underscoreword)) && ind < runs)
                {
                    Console.Write("Ran Out Of Tries, Word: [" + pword + "]");
                }

                Thread.Sleep(2500);
                Console.Clear();

                ind++;

                if (ind == runs)
                {
                    Console.WriteLine("Game Is Finished");
                    Thread.Sleep(2500);
                    GameAvailable = false;
                }

            }

        }

        // This method will get an integer (believe that it is around 1-6) because it is being rolled by the dice
        // This method won't return anything but play the game based on the player choice
        // In addition, the method gets a dtype of Player which is being used for a few games in order to make it work
        public static void GameManager(int n, Player player)
        {
            Random rand = new Random();
            int x = rand.Next(1, 5);
            int c = 0; 
            int r = 0; 
            Console.ForegroundColor = ConsoleColor.White;
            if (x == 1)
            {
                x = rand.Next(1, 4);
                switch (x)
                {
                    case 1:
                        Console.WriteLine("Depite The Fact That You Got The " + n + "TH Game In The Dice You Were Too Lucky");
                        Console.WriteLine("SECRET GAME CHOSEN - Rock, Paper And Scissors, Number " + x);
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        SecretGame1();
                        SecretGameResults(1);
                        break;
                    case 2:
                        Console.WriteLine("Depite The Fact That You Got The " + n + "TH Game In The Dice You Were Too Lucky");
                        Console.WriteLine("SECRET GAME CHOSEN - Messy Words, Guess The Word, Number " + x);
                        Console.WriteLine("Insert The Length Of Guesses");
                        Console.WriteLine("Ranges [1 - 20], Otherwise, Will Be Set To 10");
                        c = int.Parse(Console.ReadLine());
                        if (c < 1 || c > 20)
                            c = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        SecretGame2(c);
                        SecretGameResults(2);
                        break;
                    case 3:
                        Console.WriteLine("Depite The Fact That You Got The " + n + "TH Game In The Dice You Were Too Lucky");
                        Console.WriteLine("SECRET GAME CHOSEN - HANGMAN, Number " + x);
                        Console.WriteLine("Insert The Length Of Guesses & Runs (Guesses For Each Run)");
                        Console.WriteLine("Ranges [1 - 20] For Each Guess , Otherwise, Will Be Set To 10");
                        c = int.Parse(Console.ReadLine());
                        if (c < 1 || c > 20)
                            c = 10;
                        Console.WriteLine("Ranges [1 - 20] For The Runs , Otherwise, Will Be Set To 10");
                        if (r < 1 || r > 20)
                            r = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        SecretGame3(c, r);
                        SecretGameResults(3);
                        break;
                }
            }
            else
            {
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Game Chosen - Eat Mobs, Number " + n);
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game1(player);
                        GameResults(1);
                        break;
                    case 2:
                        Console.WriteLine("Game Chosen - Eat Mobs While Avoiding Obstacles, Number " + n);
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game2(player);
                        GameResults(2);
                        break;
                    case 3:
                        Console.WriteLine("Game Chosen - Catch The Mobs, Number " + n);
                        Console.WriteLine("Insert The Amount Of Mobs You Want To Catch");
                        Console.WriteLine("Ranges [1-10^3 (1000)] Otherwise, Will Be Set To 10");
                        c = int.Parse(Console.ReadLine());
                        if (c < 0 || c > 1000)
                            c = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game3(c);
                        GameResults(3);
                        break;
                    case 4:
                        Console.WriteLine("Game Chosen - Shooting Game (Sort Of), Number " + n);
                        Console.WriteLine("Insert An Integer Between [5 - 30]");
                        Console.WriteLine("Keep In Mind That If You Will Choose Invalid Number It Will Be Automatically 10");
                        c = int.Parse(Console.ReadLine());
                        if (c < 5 || c > 30)
                            c = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game4(c);
                        GameResults(4);
                        break;
                    case 5:
                        Console.WriteLine("Game Chosen - MasterMind (בול פגיעה), Number " + n);
                        Console.WriteLine("Insert The Amount Of The Tries You Want To Have");
                        Console.WriteLine("Ranges [1-10^3 (1000)] Otherwise, Will Be Set To 10");
                        c = int.Parse(Console.ReadLine());
                        if (c > 1000 || c < 1)
                            c = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game5(c);
                        GameResults(5);
                        break;
                    case 6:
                        Console.WriteLine("Game Chosen - Simon, Number " + n);
                        Console.WriteLine("Insert The Amount Of The Tries You Want To Have");
                        Console.WriteLine("Ranges [1-10^3 (1000)] Otherwise, Will Be Set To 10");
                        c = int.Parse(Console.ReadLine());
                        if (c > 1000 || c < 1)
                            c = 10;
                        Console.WriteLine("Please Prepare, Enlarge The Screen Then Insert A Key In Order To Continue");
                        Console.ReadKey();
                        Console.Clear();
                        Game6(c);
                        GameResults(6);
                        break;

                        // No Default Due To The Fact The Ranges (1 - 6)
                }
            }
        }

        // This method will get one parameter which is the number of the game
        // The method won't return anything but will make sort of "game results" with feedbacks using the console so that it will be cleaner
        public static void GameResults(int game)
        {
            Thread.Sleep(500);
            Console.Clear();
            Console.SetCursorPosition((int)80 / 35 + 37, 12); 
            Console.ForegroundColor = ConsoleColor.Red;
            Thread.Sleep(1000);
            Console.WriteLine("Game " + game + " Finished, Insert Any Button To Continue");
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.Clear();
        }

        // The method is similar to the original ones which is the "Game Results" but the difference is that it is using the secretgame results
        // Will get one integer in order to give a feedback of the secret's game number
        // The method won't return anything because it's a "static void" but will print the information that is required
        public static void SecretGameResults(int game)
        {
            Thread.Sleep(500);
            Console.Clear();
            Console.SetCursorPosition((int)80 / 35 + 37, 12); 
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            Console.WriteLine("SECRET Game " + game + " Finished, Insert Any Button To Continue");
            Thread.Sleep(1000);
            Console.ReadKey();
            Console.Clear();
        }

        // That's the main method, has to do nothing with it but running all the programs / function / methods that are mentioned above and much more
        // Uses the Game Manager and a library that is named "Unit4" ('Unit4.DiceLib') 
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player player = new Player(1, 10, 10, '■', ConsoleColor.Cyan);
            Die dice = new Die("game");
            dice.Roll();
            while (true) 
            {
                GameManager(dice.GetNum(), player);
                dice.Roll();
            }
            //SecretGame1();
            //Console.CursorVisible = false;
            //Player player = new Player(1, 10, 10, '■', ConsoleColor.Cyan);
            //Game6(3);
            //GameResults(6);
            //SecretGame1();
            //SecretGameResults(1);
            //SecretGame2(5);
            //SecretGameResults(2);
            //SecretGame3(5, 2);
            //SecretGameResults(3);
        }
    }
}
