using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Level
    {
        private Field _FieldModel { get; set; }

        private GameController GameController { get; set; }

        private Field[,] _fieldArray { get; set; }
        private Field[,] _fieldArrayTop { get; set; }
        private int _height { get; set; }
        private int _width { get; set; }
        private string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
        private Player _player { get; set; }


        // Constructor
        public Level()
        {

        }

        public int getHeightOfLevel(string[] lines)
        {
            int count = 0;

            foreach (string line in lines) {
                count++;
            }

            return count;
        }

        public int getWidthofLevel(string[] lines)
        {
            int count = 0;

            foreach (string line in lines)
            {

                foreach (char Char in line)
                {
                    count++;
                }
                break;
            }

            return count;
        }

        public void setField(int value)
        {
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            _filePath += @"\Levels\doolhof" + value +".txt";

            string[] lines = System.IO.File.ReadAllLines(_filePath);

            this._height = getHeightOfLevel(lines);
            this._width = getWidthofLevel(lines);

            this._fieldArray = new Field[_height, _width];

            int y = 0; // row
            int x = 0; // colomn

            foreach (string line in lines)
            {
                foreach(char Char in line)
                {
                    switch (Char)
                    {
                        case '#':
                            _fieldArray[y,x] = new Wall();
                        break;

                        case '.':
                            _fieldArray[y, x] = new Floor();
                        break;

                        case 'o':
                            _fieldArray[y, x] = new Chest();
                        break;

                        case 'x':
                            _fieldArray[y, x] = new Destination();
                        break;

                        case ' ':
                            _fieldArray[y, x] = new Void();
                        break;

                        case '@':
                            this._player = new Player(y, x);
                            _fieldArray[y, x] = this._player;
                        break;
                    }
                    x++;
                }
                y++;
                x = 0;
            }
        }

        public Field[,] getField()
        {
            return _fieldArray;
        }

        public Player getPlayer()
        {
            return _player;
        }

        public Field getFieldModel()
        {
            return _FieldModel;
        }


    }
}