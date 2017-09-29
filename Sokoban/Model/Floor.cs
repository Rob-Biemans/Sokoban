using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor : Field
    {
        // Constructor
        public Floor()
        {
            this.type = "Floor";
            this.moveAble = false;
            this.icon = ".";
        }

        public override void moveTo()
        {
            return;
        }
    }
}