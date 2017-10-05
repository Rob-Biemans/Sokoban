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

            var obj = checkNextOfMe(player, direction, fieldArrayTop);

            switch (obj.icon)
            {
                case "x":
                    Console.WriteLine("destination");
                break;

                default:
                    Console.WriteLine(obj);
                    obj.moveTo(player, direction, fieldArray, fieldArrayTop);
                break;
            }

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