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
        public bool walkAble = false;
        public int X { get; set; }
        public int Y { get; set; }
        public int lives { get; set; }

        // Constructor
        public Field()
        {

        }

        // Move the object to different tile
        // If theres room to walk to and other conditions are met.
        public abstract Field[,] moveTo(Player player, string direction, Field[,] field, Field[,] fieldTop);

        // Check what object is on the tile next of the player
        // lower layer
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

        // Check previous tile (object) on the lower layer
        public Field checkPreviousOfMe(Player player, string direction, Field[,] fieldArray)
        {
            return fieldArray[player.Y, player.X];
        }

        // Check whats next of the object
        // lower layer
        public Field checkNextOfObject(Player player, string direction, Field[,] fieldArray)
        {

            if (direction == "Up")
            {
                return fieldArray[player.Y - 2, player.X];
            }
            else if (direction == "Down")
            {
                return fieldArray[player.Y + 2, player.X];
            }
            else if (direction == "Right")
            {
                return fieldArray[player.Y, player.X + 2];
            }
            else if (direction == "Left")
            {
                return fieldArray[player.Y, player.X - 2];
            }

            throw new Exception();
        }

        // Check what the tile previous had
        public Field checkPreviousOfObject(Player player, Field[,] fieldArray)
        {
            return fieldArray[player.Y, player.X];
        }

        // Check whats next of the object
        // top layer
        public Field checkNextOfObjectTop(Player player, string direction, Field[,] fieldArrayTop)
        {

            if (direction == "Up")
            {
                return fieldArrayTop[player.Y - 2, player.X];
            }
            else if (direction == "Down")
            {
                return fieldArrayTop[player.Y + 2, player.X];
            }
            else if (direction == "Right")
            {
                return fieldArrayTop[player.Y, player.X + 2];
            }
            else if (direction == "Left")
            {
                return fieldArrayTop[player.Y, player.X - 2];
            }

            throw new Exception();
        }

    }
}