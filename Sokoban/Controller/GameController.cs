using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameController
    {
        //Declarations
        private Game _gameModel { get; set; }
        private Level _levelModel { get; set; }
        private Player _playerModel { get; set; }

        private GameView _gameView { get; set; }


        // Constructor
        public GameController()
        {
            _gameView = new GameView();
            _gameModel = new Game();
            _playerModel = new Player();
            _levelModel = new Level(this);
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
            } else if (note == "S" || note == "s") {
                Console.WriteLine("Stopt!");
                Console.ReadKey();
            }

            try {
                int getal = Int16.Parse(note);
                _levelModel.setField(getal);
                _gameView.printLevel(_levelModel.getHeight(), _levelModel.getWidth(), _levelModel.getField());
            } catch (FormatException e) {
                selectLevel();
            }
        }

    }
}