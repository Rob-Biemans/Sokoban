using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor : Field
    {
        private Field _obj;

        // Constructor
        public Floor()
        {
            this.type = "Floor";
            this.icon = ".";
            this.walkAble = true;
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            if (checkPreviousOfMe(player, direction, fieldArray).icon == "x") {
                _obj = new Destination();
            } else {
                _obj = this;
            }

            switch (direction)
            {
                case "Up":
                    fieldArrayTop[player.Y, player.X] = this;
                    fieldArrayTop[player.Y - 1, player.X] = player;

                    fieldArray[player.Y, player.X] = _obj;
                    player.Y = player.Y - 1;
                    return fieldArray;
                case "Down":
                    fieldArrayTop[player.Y, player.X] = this;
                    fieldArrayTop[player.Y + 1, player.X] = player;

                    fieldArray[player.Y, player.X] = _obj;
                    player.Y = player.Y + 1;
                    return fieldArray;
                case "Right":
                    fieldArrayTop[player.Y, player.X] = this;
                    fieldArrayTop[player.Y, player.X + 1] = player;

                    fieldArray[player.Y, player.X] = _obj;
                    player.X = player.X + 1;
                    return fieldArray;
                case "Left":
                    fieldArrayTop[player.Y, player.X] = this;
                    fieldArrayTop[player.Y, player.X - 1] = player;

                    fieldArray[player.Y, player.X] = _obj;
                    player.X = player.X - 1;
                    return fieldArray;
            }

            return fieldArray;
        }
        
    }
}