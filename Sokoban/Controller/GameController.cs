using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class GameController
    {
        //Declarations
        private outputView _outputView { get; set; }
        private inputView _inputView { get; set; }

        private Game _gameModel { get; set; }

        private int _selectedLevel { get; set; }

        private Player _player { get; set; }


        // Constructor
        public GameController()
        {
            _outputView = new outputView();
            _inputView = new inputView();
            _gameModel = new Game(this);
            initGame();
        }

        public void initGame()
        {
            _outputView.printWelcome();
            selectLevel();
        }

        public void play()
        {
            this._player = _gameModel.getLevelModel().getPlayer();

            string direction = "";

            while (_gameModel.getFinished() != true)
            {
                _inputView.printQuestion();
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.UpArrow:
                        direction = "Up";
                        updateLevel(_player, _player.moveTo(this._player, direction, _gameModel.getLevelModel().getField()));
                        break;
                    case ConsoleKey.DownArrow:
                        direction = "Down";
                        updateLevel(_player, _player.moveTo(this._player, direction, _gameModel.getLevelModel().getField()));
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = "Left";
                        updateLevel(_player, _player.moveTo(this._player, direction, _gameModel.getLevelModel().getField()));
                        break;
                    case ConsoleKey.RightArrow:
                        direction = "Right";
                        updateLevel(_player, _player.moveTo(this._player, direction, _gameModel.getLevelModel().getField()));
                        break;
                    case ConsoleKey.R:
                        _gameModel.resetField(_selectedLevel);
                        _outputView.printLevel(_player, _gameModel.getLevelModel().getField());
                        this._player.X = _gameModel.getLevelModel().getPlayer().X;
                        this._player.Y = _gameModel.getLevelModel().getPlayer().Y;
                        break;
                    case ConsoleKey.S:
                        return;
                }
                
            }

            //# 1 locatie speler
            //# 2 bekijken of het mogelijk is om te verplaatsen naar gewenste richting
            //#   ~ bij floor = speler verplaatsen op die plek.
            //#      ~ vorige positie speler wordt floor

            // 3 verplaatsen van een chest
            //   ~ check of kist kan bewegen (andere kant van kist moet floor zijn)
            //      ~ vorige positie kist wordt speler
            //      ~ vorige positie speler wordt floor
        }

        public void updateLevel(Player player, Field[,] fieldArray)
        {
            _outputView.printLevel(_player, fieldArray);
        }

        // Vraagt aan gebruiker om een level te kiezen
        public void selectLevel()
        {
            Console.WriteLine("Kies een doolhof (1 - 4), s = stop");
            
            var note = Console.ReadLine();

            if (note.Length > 1) {
                selectLevel();
            } else if (note == "S" || note == "s") {
                Environment.Exit(0);
            }

            try {
                _selectedLevel = Int16.Parse(note);
                _gameModel.initField(_selectedLevel);
                _outputView.printLevel(_gameModel.getLevelModel().getPlayer(), _gameModel.getLevelModel().getField());
                play();
            } catch (FormatException e) {
                selectLevel();
            }
        }

    }
}