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

                if (ch == ConsoleKey.UpArrow) {
                    direction = "Up";
                } else if (ch == ConsoleKey.DownArrow) {
                    direction = "Down";
                } else if (ch == ConsoleKey.LeftArrow) {
                    direction = "Left";
                } else if (ch == ConsoleKey.RightArrow) {
                    direction = "Right";
                } else if (ch == ConsoleKey.R) {
                    _gameModel.resetField(_selectedLevel);
                    _outputView.printLevel(_player, _gameModel.getLevelModel().getField(), _gameModel.getLevelModel().getFieldTop());
                    this._player.X = _gameModel.getLevelModel().getPlayer().X;
                    this._player.Y = _gameModel.getLevelModel().getPlayer().Y;
                } else if (ch == ConsoleKey.S) {
                    Environment.Exit(0);
                } else {
                    play();
                }

                updateLevel(_player, _player.moveTo(this._player, direction, _gameModel.getLevelModel().getField(), _gameModel.getLevelModel().getFieldTop()), _gameModel.getLevelModel().getFieldTop());

            }

        }

        public void updateLevel(Player player, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            checkForDestinationsFilled(fieldArray, fieldArrayTop);

            _outputView.printLevel(_player, fieldArray, fieldArrayTop);
        }

        public void checkForDestinationsFilled(Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            int destinations = 0;
            int destinationsFilled = 0;

            for (int y = 0; y < fieldArray.GetLength(0); y++)
            {
                for (int x = 0; x < fieldArray.GetLength(1); x++)
                {
                    
                    if (fieldArray[y, x].icon == "x" && fieldArrayTop[y, x].icon == "o")
                    {
                        fieldArray[y, x] = new DestinationFilled();
                    }

                    if (fieldArray[y, x].icon == "0" && fieldArrayTop[y, x].icon == "@")
                    {
                        fieldArray[y, x] = new Destination();
                    }

                    if (fieldArray[y, x].icon == "0")
                        destinationsFilled++;
                    
                    if (fieldArray[y, x].icon == "x")
                        destinations--;
                    
                }
                Console.WriteLine();
            }

            if (destinations == 0)
            {
                _gameModel.setFinished();
                _outputView.printWin();
                Console.ReadKey();
            }

        }

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
                _outputView.printLevel(_gameModel.getLevelModel().getPlayer(), _gameModel.getLevelModel().getField(), _gameModel.getLevelModel().getFieldTop());
                play();
            } catch (FormatException e) {
                selectLevel();
            }
        }

    }
}