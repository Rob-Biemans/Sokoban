using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class outputView
    { 

        public void printWelcome()
        {
            Console.WriteLine("╒═══════════════════════════════════════════════╕");
            Console.WriteLine("| Welkom bij Sokoban                            |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| Betekenis van symbolen  | doel van het spel   |");
            Console.WriteLine("|                         |                     |");
            Console.WriteLine("|  # : muur               |  duw met de truck   |");
            Console.WriteLine("|  . : vloer              |  de krat(ten)       |");
            Console.WriteLine("|  o : krat               |  naar de bestemming |");
            Console.WriteLine("|  0 : krat op bestemming |                     |");
            Console.WriteLine("|  x : bestemming         |                     |");
            Console.WriteLine("|  @ : truck/speler       |                     |");
            Console.WriteLine("╘═══════════════════════════════════════════════╛");
        }

        public void printLevel(Player player, Field[,] _fieldArray, Field[,] _fieldArrayTop)
        {
            Console.Clear();
            printBanner();
            for (int y = 0; y < _fieldArray.GetLength(0); y++)
            {
                for (int x = 0; x < _fieldArray.GetLength(1); x++)
                {
                    if (_fieldArrayTop[y, x].icon == ".")
                        Console.Write(_fieldArray[y, x].icon);
                    //if chest is NOT ontop of destination OR is destination OR is player use fieldArrayTop
                    else if (_fieldArrayTop[y, x].icon == "0" || _fieldArrayTop[y, x].icon == "@" || _fieldArrayTop[y, x].icon == "o" && _fieldArray[y, x].icon != "0")
                        Console.Write(_fieldArrayTop[y, x].icon);
                    else
                        Console.Write(_fieldArray[y, x].icon);
                }
                Console.WriteLine();
            }

            //debug purpose
            //for (int y = 0; y < _fieldArrayTop.GetLength(0); y++)
            //{
            //    for (int x = 0; x < _fieldArrayTop.GetLength(1); x++)
            //    {
            //        Console.Write(_fieldArrayTop[y, x].icon);
            //    }
            //    Console.WriteLine();
            //}
        }

        public void printBanner()
        {
            Console.WriteLine("╒═════════════════════════╕");
            Console.WriteLine("| Sokoban                 |");
            Console.WriteLine("╘═════════════════════════╛");
        }

        public void printWin()
        {
            Console.Clear();
            Console.WriteLine("╒═════════════════════════╕");
            Console.WriteLine("| You finished the game!  |");
            Console.WriteLine("╘═════════════════════════╛");
        }
    }
}