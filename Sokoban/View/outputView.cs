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

        public void printLevel(int height, int width, Field[,] _fieldArray)
        {
            Console.Clear();
            printBanner();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.Write(_fieldArray[y, x].icon);
                }
                Console.WriteLine();
            }
        }

        public void printBanner()
        {
            Console.WriteLine("╒═════════════════════════╕");
            Console.WriteLine("| Sokoban                 |");
            Console.WriteLine("╘═════════════════════════╛");
        }
    }
}