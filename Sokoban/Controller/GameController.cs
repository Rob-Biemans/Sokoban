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

        private outputView _outputView { get; set; }
        private inputView _inputView { get; set; }

        private Game _gameModel { get; set; }

        private int _playerX { get; set; }
        private int _playerY { get; set; }

        private int _selectedLevel { get; set; }

        
        // Constructor
        public GameController()
        {
            _outputView = new outputView();
            _inputView = new inputView();
            _gameModel = new Game();
            initGame();
        }

        public void initGame()
        {
            _outputView.printWelcome();
            selectLevel();
            //Console.ReadKey();
        }

        public void play()
        {
            this._playerX = _gameModel.getLevelModel().getPlayer().X;
            this._playerY = _gameModel.getLevelModel().getPlayer().Y;

            string direction = "";

            while (_gameModel.getFinished() != true)
            {
                _inputView.printQuestion();
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.UpArrow:
                        direction = "Up";
                        movePossible(_playerY, _playerX, direction);
                        break;
                    case ConsoleKey.DownArrow:
                        direction = "Down";
                        movePossible(_playerY, _playerX, direction);
                        break;
                    case ConsoleKey.LeftArrow:
                        direction = "Left";
                        movePossible(_playerY, _playerX, direction);
                        break;
                    case ConsoleKey.RightArrow:
                        direction = "Right";
                        movePossible(_playerY, _playerX, direction);
                        break;
                    case ConsoleKey.R:
                        _gameModel.resetField(_selectedLevel);
                        _outputView.printLevel(_gameModel.getLevelModel().getHeight(), _gameModel.getLevelModel().getWidth(), _gameModel.getLevelModel().getField());
                        this._playerX = _gameModel.getLevelModel().getPlayer().X;
                        this._playerY = _gameModel.getLevelModel().getPlayer().Y;
                        break;
                    case ConsoleKey.S:
                        return;
                }
                
            }

            _gameModel.getLevelModel().getField();
           

            //# 1 locatie speler
            //# 2 bekijken of het mogelijk is om te verplaatsen naar gewenste richting
            //#   ~ bij floor = speler verplaatsen op die plek.
            //#      ~ vorige positie speler wordt floor

            // 3 verplaatsen van een chest
            //   ~ check of kist kan bewegen (andere kant van kist moet floor zijn)
            //      ~ vorige positie kist wordt speler
            //      ~ vorige positie speler wordt floor
        }

        public void movePossible(int playerY, int playerX, string direction)
        {

            var veld = _gameModel.getLevelModel().getField();

            if (direction == "Up" && veld[playerY - 1, playerX].icon != "#")
            {

                checkForChest(direction, veld, playerY - 1, playerX);

                veld[playerY - 1, playerX].icon = "@";
                veld[playerY, playerX].icon = ".";

                playerY = playerY - 1;
                playerX = playerX;
                /*
                if (veld[playerY - 2, playerX].icon == "o")
                {
                    Console.WriteLine("Kist gevonden");
                }
                */
            } else if (direction == "Down" && veld[playerY + 1, playerX].icon != "#")
            {
                checkForChest(direction, veld, playerY + 1, playerX);

                veld[playerY + 1, playerX].icon = "@";
                veld[playerY, playerX].icon = ".";

                playerY = playerY + 1;
                playerX = playerX;
            } else if (direction == "Right" && veld[playerY, playerX + 1].icon != "#")
            {
                checkForChest(direction, veld, playerY, playerX + 1);

                veld[playerY, playerX + 1].icon = "@";
                veld[playerY, playerX].icon = ".";

                playerY = playerY;
                playerX = playerX + 1;
            } else if (direction == "Left" && veld[playerY, playerX - 1].icon != "#")
            {
                checkForChest(direction, veld, playerY, playerX - 1);

                veld[playerY, playerX - 1].icon = "@";
                veld[playerY, playerX].icon = ".";

                playerY = playerY;
                playerX = playerX - 1;
            }

            this._playerY = playerY;
            this._playerX = playerX;

            Console.WriteLine("Y: " + playerY + " X: " + playerX);
            Console.WriteLine(this._playerY);
            Console.WriteLine(this._playerX);
            
            _outputView.printLevel(_gameModel.getLevelModel().getHeight(), _gameModel.getLevelModel().getWidth(), _gameModel.getLevelModel().getField());
        }

        private void checkForChest(string direction, Field[,] veld, int y, int x)
        {
            if (veld[y, x].icon == "o")
            {
                switch (direction)
                {
                    case "Up":
                        Console.WriteLine("Boven kist");
                        break;
                    case "Down":
                        Console.WriteLine("Onder kist");
                        break;
                    case "Right":
                        Console.WriteLine("Rechts kist");
                        break;
                    case "Left":
                        Console.WriteLine("Links kist");
                        break;
                }
            }
            //# als het een kist is 
                // bekijk of de kist kan verplaatst worden
                
                // true
                    // verplaatsen kist
                    // verplaatsen speler naar kist
               // false
                    // return false en doe niks
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
                _selectedLevel = Int16.Parse(note);
                _gameModel.createField(_selectedLevel);
                _outputView.printLevel(_gameModel.getLevelModel().getHeight(), _gameModel.getLevelModel().getWidth(), _gameModel.getLevelModel().getField());
                play();
            } catch (FormatException e) {
                selectLevel();
            }
        }

    }
}