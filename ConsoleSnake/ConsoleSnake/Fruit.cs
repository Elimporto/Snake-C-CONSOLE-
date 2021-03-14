using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Fruit
    {

        //Creates a new random object.
        Random randomizer = new Random();

        /// <summary>
        /// Upon start spawns a fruit at a random location.
        /// Upon start sets score to 0;
        /// </summary>
        public void Restart()
        {
            Position.X = randomizer.Next(1, Settings.width);
            Position.Y = randomizer.Next(1, Settings.height);
            Score.score = 0;
        }

        /// <summary>
        /// Makes a new fruit spawn once the first one from Restart() and the consecutive from
        /// /// RandomFruitSpawner() has been eaten.
        /// </summary>
        void RandomFruitSpawner(int width, int height, Snake snake)
        {
            Position.X = randomizer.Next(1, width);
            Position.Y = randomizer.Next(1, height);

            for (int i = snake.Length; i >= 1; i--)
            {
                if (snake.X[i - 1] == Position.X && snake.Y[i - 1] == Position.Y)
                {
                    RandomFruitSpawner(width, height, snake);
                }
            }
        }
        /// <summary>
        /// Draws the fruit in the color red, I wanted to randomize it but no.
        /// </summary>
        void DrawFruit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(Position.X, Position.Y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Logic for the fruit score system. 
        /// When snake is at the position of the fruit;
        /// Snake will increase in length and score will increase by 12
        /// Why 12 you say? Everytime I watch Basketball or tennis i ask myself the same.
        /// </summary>
        /// <param name="snake">ref will actually use the snake object instead of making a new one.</param>
        public void LogicFruit(ref Snake snake)
        {
            DrawFruit();
            if (snake.X[0] == Position.X)
            {
                if (snake.Y[0] == Position.Y)
                {
                    snake.Length++;
                    Score.score += 12;
                    Console.SetCursorPosition(Settings.width / 2 - 4, Settings.height + 2);
                    Console.Write($"Score: {Score.score}");
                    RandomFruitSpawner(Settings.width, Settings.height, snake);
                }
            }
        }
    }
}
