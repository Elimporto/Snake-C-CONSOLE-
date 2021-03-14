using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleSnake
{
    /// <summary>
    /// GameManager, this is where all the parts come together.
    /// </summary>
    class GameManager : Settings
    {
        //Stores a char with pressed key
        ConsoleKeyInfo keyInfo;
        //Gets input
        ConsoleKey consoleKey;
        //Makes a snake and a fruit object.
        Snake snake;
        Fruit fruit;

        bool isLost;
        bool isWin;


        public GameManager()
        {
            Console.CursorVisible = false;
            Console.Title = "DISCO SNAKE UDZ";
            snake = new Snake();
            fruit = new Fruit();
        }
        /// <summary>
        /// Loop for when the game restarts1
        /// </summary>
        void RestartGame()
        {
            GameBoard.Draw(width, height);
            MenuGame();
            Console.Clear();

            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();

            isLost = false;
            isWin = false;

            snake.Restart();
            fruit.Restart();
            GameBoard.Draw(width, height);
        }
        /// <summary>
        /// Game Constrols, make sure the snake wont go inside itself, to autocollide.
        /// If the snake is going down and player presses up, it wont change direction.
        /// The right way would be down, left and up, or down, right and up.
        /// Uses the Shift Method we created in snake.
        /// </summary>
        void ControlGame()
        {
            //If the key is avaliable
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }
            //Will move snake in a direction as long as the direction opposite isnt already the direction.
            switch (consoleKey)
            {
                //Moves snake up UNLESS down is currently active.
                case ConsoleKey.UpArrow:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.DownArrow;
                    else snake.Shift(Snake.Direction.UP);
                    break;
                //Moves snake down UNLESS up is currently active.
                case ConsoleKey.DownArrow:
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.UpArrow;
                    else snake.Shift(Snake.Direction.DOWN);
                    break;
                //Moves snake right UNLESS left is currently active.
                case ConsoleKey.RightArrow:
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.LeftArrow;
                    else snake.Shift(Snake.Direction.RIGHT);
                    break;
                //Moves snake left UNLESS right is currently active.
                case ConsoleKey.LeftArrow:
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.RightArrow;
                    else snake.Shift(Snake.Direction.LEFT);
                    break;
                default:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.DownArrow;
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.UpArrow;
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.RightArrow;
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.LeftArrow;
                    break;
            }
        }
        /// <summary>
        /// Just the logic loop, incorporates the controls and logics from the fruit and snake classes.
        /// </summary>
        void LogicGame()
        {
            ControlGame();
            fruit.LogicFruit(ref snake);
            snake.SnakeLogic(ref isLost, ref isWin);
        }

        /// <summary>
        /// Menu;
        /// Console.SetCursorPosition(Settings.width / 2 - 9, 1); sets the position of the text.
        /// Meny loop, while no choice is made you will have to make a choice.
        /// </summary>
        void MenuGame()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey consoleKey = new ConsoleKey();
            Console.SetCursorPosition(Settings.width / 2 - 9, 1);
            Console.Write("SNAKE DISCO UDZ UDZ");
            Console.SetCursorPosition(Settings.width / 2 - 11, 2);
            Console.Write("[1] to start a game");
            Console.SetCursorPosition(Settings.width / 2 - 11, 3);
            Console.Write("[ESC] to be a quitter.");
            bool choice = false;
            while (choice == false)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                        choice = true;
                        break;
                    case ConsoleKey.Escape:
                        choice = true;
                        Environment.Exit(0);
                        break;

                }
            }

        }
        /// <summary>
        /// Play game loop with win and loss conditions.
        /// Thread.Sleep sets the speed at which snake will move.
        /// </summary>
        public void PlayGame()
        {
            while (true)
            {
                RestartGame();
                while (isLost == false && isWin == false)
                {
                    LogicGame();
                    Thread.Sleep(100);
                }
            }
        }
    }
}
