using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor : Field
    {
        // Constructor
        public Floor()
        {
            this.type = "Floor";
            this.icon = ".";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray)
        {
            switch (direction)
            {
                case "Up":
                    fieldArray[player.Y - 1, player.X] = player;
                    fieldArray[player.Y, player.X] = this;
                    player.Y = player.Y - 1;
                    return fieldArray;
                case "Down":
                    fieldArray[player.Y + 1, player.X] = player;
                    fieldArray[player.Y, player.X] = this;
                    player.Y = player.Y + 1;
                    return fieldArray;
                case "Right":
                    fieldArray[player.Y, player.X + 1] = player;
                    fieldArray[player.Y, player.X] = this;
                    player.X = player.X + 1;
                    return fieldArray;
                case "Left":
                    fieldArray[player.Y, player.X - 1] = player;
                    fieldArray[player.Y, player.X] = this;
                    player.X = player.X - 1;
                    return fieldArray;
            }

            return fieldArray;
        }
        
    }
}