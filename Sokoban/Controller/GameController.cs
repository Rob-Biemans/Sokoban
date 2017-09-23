using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameController
    {
        //Declarations
        private Game _game { get; set; }
        private Level _level { get; set; }
        private Player _player { get; set; }

        private GameView _gameView { get; set; }


        // Constructor
        public GameController()
        {
            _gameView = new GameView();
            _game = new Game();
            _player = new Player();
            initGame();
        }

        public void initGame()
        {
            _gameView.printWelcome();
            selectLevel();
            //Console.ReadKey();
        }

        public void play()
        {
            /*
            while (_finished != true)
            {

            }

            // nieuwe level of bij dood/vast lopen playAgain()
            */
        }

        public void playAgain()
        {
            selectLevel();
        }

        // Vraagt aan gebruiker om een level te kiezen
        public void selectLevel()
        {
            Console.WriteLine("Kies een doolhof (1 - 4), s = stop");
            
            var note = Console.ReadLine();

            if (note.Length > 1) {
                selectLevel();
            } else if (note == "S") {
                Console.WriteLine("Stopt!");
                Console.ReadKey();
            }

            try {
                int getal = Int16.Parse(note);
                generateLevel(getal);
            } catch (FormatException e) {
                selectLevel();
            }
        }

        public void generateLevel(int val)
        {
            Console.WriteLine("GETAL: " + val);
            Console.ReadKey();
        }
    }
}