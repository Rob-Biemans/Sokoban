using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Void : Field
    {
        public Void()
        {
            this.type = "Void";
            this.icon = " ";
        }

        public override Field[,] moveTo(Player player, string direction, Field[,] field)
        {
            throw new Exception();
        }
    }
}