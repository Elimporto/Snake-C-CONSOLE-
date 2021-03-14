using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    public class GameBoard
    {
        /// <summary>
        /// Draws the board based on input height and width from the GameManager Class.
        /// </summary>
        /// <param name="height"></param>
        /// <param name="width"></param
        static public void Draw(int height, int width)
        {
            //Randomizes board color scheme
            var random = new Random();
            for (var i = 0; i < 100; i++)
            {
                Console.ForegroundColor = (ConsoleColor)random.Next((int)ConsoleColor.Black, (int)ConsoleColor.Yellow);
                Console.BackgroundColor = (ConsoleColor)random.Next((int)ConsoleColor.Black, (int)ConsoleColor.Yellow);
                //If ForegroundColor is equal to BackgroundColor then keep changing BackgroundColor.
                while (Console.ForegroundColor == Console.BackgroundColor)
                {
                    Console.BackgroundColor = (ConsoleColor)random.Next((int)ConsoleColor.Black, (int)ConsoleColor.Yellow);
                }
            }
            Console.Clear();

            //Draws the vertical parts of the frame surrounding the gameboard.
            //width+1 avoids snake running inside frame.
            for (int i = 1; i <= height; i++)
            {
                //Draws [i][0], so all the Ys for X = 0.
                DrawingTool(i, 0, '║');
                //Draws [i][width+1], so all the Ys for X = width+1.
                DrawingTool(i, (width + 1), '║');
            }
            //Draws the Horizontal parts of the frame surrounding the gameboard.
            //width+1 avoids snake running inside frame.
            for (int i = 1; i <= width; i++)
            {
                //Draws [0][i], so all the Xs for Y = 0.
                DrawingTool(0, i, '═');
                //Draws [0][height+1], so all the Xs for Y = height+1.
                DrawingTool((height + 1), i, '═');
            }
            //DrawingTool below are just to draw the corners of the frame.
            DrawingTool(0, 0, '╔');
            DrawingTool((height + 1), 0, '╚');
            DrawingTool(0, (width + 1), '╗');
            DrawingTool((height + 1), (width + 1), '╝');
        }

        /// <summary>
        /// Will draw on the console based on x and y coordinates, char will be used as the "brush".
        /// Like using an array matrix, but less confusing.
        /// Eg. DrawingTool(10, 5, ">");
        /// Will act as [10][5];
        /// </summary>
        /// <param name="y">The Y coordinate at which you want the char to be drawn. "Height".</param>
        /// <param name="x">The X coordinate at which you want the char to be drawn "Width".</param>
        /// <param name="chars">The character or symbol you want drawn</param>
        static void DrawingTool(int y, int x, char chars)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(chars);
        }
    }
}
