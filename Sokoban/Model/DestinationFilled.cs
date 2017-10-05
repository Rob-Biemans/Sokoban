using System;
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
            return fieldArray;
        }
    }
}