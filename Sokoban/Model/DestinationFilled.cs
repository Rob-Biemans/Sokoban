﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class DestinationFilled : Field
    {
        public DestinationFilled()
        {
            this.type = "DestinationFilledWithChest";
            this.icon = "0";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            if (checkNextOfObject(player, direction, fieldArray).icon == "#")
            {
                return fieldArray;
            }

            switch (direction)
            {
                case "Up":
                    fieldArrayTop[player.Y, player.X] = new Floor();
                    fieldArrayTop[player.Y - 1, player.X] = player;
                    fieldArrayTop[player.Y - 2, player.X] = this;
                    player.Y = player.Y - 1;
                    return fieldArray;
                case "Down":
                    fieldArrayTop[player.Y, player.X] = new Floor();
                    fieldArrayTop[player.Y + 1, player.X] = player;
                    fieldArrayTop[player.Y + 2, player.X] = this;
                    player.Y = player.Y + 1;
                    return fieldArray;
                case "Right":
                    fieldArrayTop[player.Y, player.X] = new Floor();
                    fieldArrayTop[player.Y, player.X + 1] = player;
                    fieldArrayTop[player.Y, player.X + 2] = this;
                    player.X = player.X + 1;
                    return fieldArray;
                case "Left":
                    fieldArrayTop[player.Y, player.X] = new Floor();
                    fieldArrayTop[player.Y, player.X - 1] = player;
                    fieldArrayTop[player.Y, player.X - 2] = this;
                    player.X = player.X - 1;
                    return fieldArray;
            }

            return fieldArray;
        }
    }
}