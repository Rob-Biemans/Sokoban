using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameController
    {
        //Declarations
        private Level _levelModel { get; set; }
        private Player _playerModel { get; set; }

        private GameView _gameView { get; set; }

        private Game _gameModel { get; set; }


        // Constructor
        public GameController()
        {
            _gameView = new GameView();
            _gameModel = new Game();
            _playerModel = new Player();
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
            while (_gameModel.getFinished() != true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.UpArrow:
                        Console.WriteLine("pijl omhoog");
                        break;
                    case ConsoleKey.DownArrow:
                        Console.WriteLine("pijl omlaag");
                        break;
                    case ConsoleKey.LeftArrow:
                        Console.WriteLine("pijl links");
                        break;
                    case ConsoleKey.RightArrow:
                        Console.WriteLine("pijl rechts");
                        break;
                }
            }

            _gameModel.getLevelModel().getField();

            // 1 locatie speler
            // 2 bekijken of het mogelijk is om te verplaatsen naar gewenste richting
            //   ~ bij floor = speler verplaatsen op die plek.
            //      ~ vorige positie speler wordt floor

            // 3 verplaatsen van een chest
            //   ~ check of kist kan bewegen (andere kant van kist moet floor zijn)
            //      ~ vorige positie kist wordt speler
            //      ~ vorige positie speler wordt floor
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
            } else if (note == "S" || note == "s") {
                Console.WriteLine("Stopt!");
                Console.ReadKey();
            }

            try {
                int getal = Int16.Parse(note);
                _gameModel.createField(getal);
                _gameView.printLevel(_gameModel.getLevelModel().getHeight(), _gameModel.getLevelModel().getWidth(), _gameModel.getLevelModel().getField());
                play();
            } catch (FormatException e) {
                selectLevel();
            }
        }

    }
}