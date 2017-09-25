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
        private bool _finished = false; 
        private GameController _GameController { get; set; }

        private Level _levelModel { get; set; }

        // Constructor
        public Game()
        {
            _levelModel = new Level();
        }

        public bool getFinished()
        {
            return this._finished;
        }

        public void setFinished()
        {
            this._finished = true;
        }

        public void createField(int getal)
        {
            _levelModel.setField(getal);
        }

        public Level getLevelModel()
        {
            return _levelModel;
        }

        public void resetField(int getal)
        {
            _levelModel.setField(getal);
        }
    }
}