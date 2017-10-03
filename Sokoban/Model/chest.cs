using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : Field
    {

        // Constructor
        public Chest()
        {
            this.type = "Chest";
            this.icon = "o";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray)
        {
            //TODO
            // bekijk of de kist kan verplaatst worden
            /*
            switch (direction)
            {
                case "Up":
                    fieldArray[player.Y - 1, player.X] = new Floor();
                    fieldArray[player.Y - 2, player.X] = this;
                    player.Y = player.Y - 1;
                    return fieldArray;
                case "Down":
                    fieldArray[player.Y + 1, player.X] = new Floor();
                    fieldArray[player.Y + 2, player.X] = this;
                    player.Y = player.Y + 1;
                    return fieldArray;
                case "Right":
                    fieldArray[player.Y, player.X + 1] = new Floor();
                    fieldArray[player.Y, player.X + 2] = this;
                    player.X = player.X + 1;
                    Console.WriteLine(fieldArray[player.Y, player.X + 1]);
                    Console.WriteLine(fieldArray[player.Y, player.X + 2]);
                    Console.WriteLine(player.Y);
                    Console.WriteLine(player.X);
                    return fieldArray;
                case "Left":
                    fieldArray[player.Y, player.X - 1] = new Floor();
                    fieldArray[player.Y, player.X - 2] = this;
                    player.X = player.X - 1;
                    return fieldArray;
            }*/

            return fieldArray;

            //# als het een kist is 
            // bekijk of de kist kan verplaatst worden

            // true
                // verplaatsen kist
                // verplaatsen speler naar kist
            // false
                // return false en doe niks
        }
    }
}