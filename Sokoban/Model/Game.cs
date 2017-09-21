using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Sokoban
{
    public class Game
    {
        // Declarations
        private bool _finished;
        private Player _player { get; set; }
        public Level Level { get; set; }

        // Constructor
        public Game()
        {
            _player = new Player();
            //play(); // TODO
            playAgain(); // TODO
        }

        public void play()
        {
            printWelcome();
            Console.ReadKey();
            /*
            while (_finished != true)
            {
                
            }

            // nieuwe level of bij dood/vast lopen playAgain()
            */
        }

        public void playAgain()
        {
            Console.WriteLine("Kies een doolhof (1 - 4), s = stop");
            var note = Console.ReadLine();
            
            if (note.Length > 1) {
                playAgain();
            } else {
                // TODO
            }
        }

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