using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Field
    {
        // Declarations
        private Game _gameModel { get; set; }
        public string type;
        public string icon;
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor
        public Field()
        {

        }

        public abstract Field[,] moveTo(Player player, string direction, Field[,] field);

        public Field checkNextOfMe(Player player, string direction, Field[,] fieldArray)
        {

            if (direction == "Up")
            {
                return fieldArray[player.Y - 1, player.X];
            }
            else if (direction == "Down")
            {
                return fieldArray[player.Y + 1, player.X];
            }
            else if (direction == "Right")
            {
                return fieldArray[player.Y, player.X + 1];
            }
            else if (direction == "Left")
            {
                return fieldArray[player.Y, player.X - 1];
            }

            throw new Exception();
        }


    }
}