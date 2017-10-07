using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Pitfall : Field
    {

        // Constructor
        public Pitfall(int lives)
        {
            this.type = "Pitfall";
            this.icon = "~";
            this.walkAble = true;
            this.lives = lives;
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            this.lives--;

            if (this.lives == 0)
            {

                this.icon = " ";

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
            }

            return fieldArray;
        }
    }
}