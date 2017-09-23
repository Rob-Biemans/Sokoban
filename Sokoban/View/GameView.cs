using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameView
    {

        public void printWelcome()
        {
            Console.WriteLine("╒═══════════════════════════════════════════════╕");
            Console.WriteLine("| Welkom bij Sokoban                            |");
            Console.WriteLine("|                                               |");
            Console.WriteLine("| Betekenis van symbolen  | doel van het spel   |");
            Console.WriteLine("|                         |                     |");
            Console.WriteLine("|  █ : muur               |  duw met de truck   |");
            Console.WriteLine("|  . : vloer              |  de krat(ten)       |");
            Console.WriteLine("|  O : krat               |  naar de bestemming |");
            Console.WriteLine("|  0 : krat op bestemming |                     |");
            Console.WriteLine("|  x : bestemming         |                     |");
            Console.WriteLine("|  @ : truck/speler       |                     |");
            Console.WriteLine("╘═══════════════════════════════════════════════╛");
        }
    }
}