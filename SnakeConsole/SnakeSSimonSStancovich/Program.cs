using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeSSimonSStancovich
{
    class Program
    {
        /// <summary>
        /// Main method is just kept simple. NICE AND CLEAR.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.PlayGame();
            Console.ReadKey();
        }
    }
}
