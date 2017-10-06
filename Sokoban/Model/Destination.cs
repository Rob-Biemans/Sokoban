using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Destination : Field
    {

        // Constructor
        public Destination()
        {
            this.type = "Destination";
            this.icon = "x";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray, Field[,] fieldArrayTop)
        {
            return fieldArray;
        }
    }
}