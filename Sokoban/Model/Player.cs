using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : Field
    {
        // Declarations
        private int prevY;
        private int prevX;

        // Constructor
        public Player(int y, int x)
        {
            this.type = "Player";
            this.icon = "@";
            this.walkAble = true;

            this.Y = y;
            this.X = x;
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            //Console.WriteLine("Player from - Y: " + Y + " X: " + X);
            this.prevY = Y;
            this.prevX = X;

            if (checkNextOfMe(player, direction, fieldArrayTop).icon == "#" || checkNextOfObjectTop(player, direction, fieldArrayTop).icon == "o" && checkNextOfMe(player, direction, fieldArrayTop).icon == "o" )
            {
                return fieldArray;
            }

            checkNextOfMe(player, direction, fieldArrayTop).moveTo(player, direction, fieldArray, fieldArrayTop);

            //Console.WriteLine("Player to - Y: " + Y + " X: " + X);
            Console.ReadKey();

            return fieldArray;
        }

        public int getPrevY()
        {
            return this.prevY;
        }

        public int getPrevX()
        {
            return this.prevX;
        }

    }
}