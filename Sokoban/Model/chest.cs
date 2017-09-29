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
            this.moveAble = true;
            this.icon = "o";
        }

        public override void moveTo()
        {

        }
    }
}