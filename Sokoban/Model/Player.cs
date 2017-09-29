using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : Field
    {
        // Declarations

        // Constructor
        public Player(int y, int x)
        {
            this.type = "Player";
            this.moveAble = true;
            this.icon = "@";

            this.Y = y;
            this.X = x;
        }

        public override void moveTo()
        {

        }

        
    }
}