using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSSimonSStancovich
{
    /// <summary>
    /// Snake Logic and Snake rendering.
    /// </summary>
    class Snake
    {
        //fields for positioning
        public int[] X { private set; get; }
        public int[] Y { private set; get; }
        public int Length { set; get; }
        public enum Direction { LEFT, RIGHT, UP, DOWN }
        /// <summary>
        /// Sets spawn point for the snake.
        /// It will spawn at X[0] = width of game / 2 and;
        /// Y[0] = height of game / 2;
        /// Y[1] makes the snake move from the start of the game.
        /// Length provides the snakes start length, which is 1 square.
        /// </summary>
        public void Restart()
        {
            X = new int[50];
            Y = new int[50];

            X[0] = Settings.width / 2;
            Y[0] = Settings.height / 2;
            Y[1] = Settings.height / 2 + 1;

            Length = 1;
        }
        /// <summary>
        /// Draws the snake as it moves, so the placement of a coordinate
        /// adds a new square for the new coordinate 
        /// and removes the old square from the old coordinate.
        /// Also adds directionality in the switch using ENUM Direction.
        /// </summary>
        /// <param name="direction"></param>
        public void Shift(Direction direction)
        {
            for (int i = Length + 1; i > 1; i--)
            {
                X[i - 1] = X[i - 2];
                Y[i - 1] = Y[i - 2];
            }
            //Directionality for the snake movement
            switch (direction)
            {
                case Direction.UP:
                    Y[0]--;
                    break;
                case Direction.DOWN:
                    Y[0]++;
                    break;
                case Direction.LEFT:
                    X[0]--;
                    break;
                case Direction.RIGHT:
                    X[0]++;
                    break;

            }
        }
        /// <summary>
        /// Draws the snake, gives it a color, gives it a symbol
        /// </summary>
        void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(X[i], Y[i]);
                Console.Write("■");
            }
            //This part makes the old part of the snake become "invisible".
            Console.ForegroundColor = ConsoleColor.White;
            if (X[Length] != 0)
            {
                Console.SetCursorPosition(X[Length], Y[Length]);
                //If you wanted to you could also make the snake leave trails, like slime 
                Console.Write(" ");
            }
        }
        /// <summary>
        /// Sets conditions for loosing or winning based on collision;
        /// if the length of the snake is over 9000, you win.
        /// </summary>
        /// <param name="isLost"> If Collision is detected, you lose.</param>
        /// <param name="isWin"> You don't win.</param>
        public void SnakeLogic(ref bool isLost, ref bool isWin)
        {
            if (Length == 9000)
            {
                isWin = true;
            }
            else
            {
                Draw();

                if (X[0] <= 0 || X[0] >= Settings.width + 1 || Y[0] <= 0 || Y[0] >= Settings.height + 1)
                {
                    isLost = true;
                }

                for (int i = Length; i >= 2; i--)
                {
                    if (X[0] == X[i - 1] && Y[0] == Y[i - 1])
                    {
                        isLost = true;
                    }
                }
            }
        }
    }
}
