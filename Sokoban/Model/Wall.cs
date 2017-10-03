using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Wall : Field
    {
        // Constructor
        public Wall()
        {
            this.type = "Wall";
            this.icon = "#";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] fieldArray)
        {
            return fieldArray;
        }
    }
}